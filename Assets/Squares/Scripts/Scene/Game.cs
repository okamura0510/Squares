using UnityEngine;
using UnityEngine.SceneManagement;
using static Squares.GameSequence;

namespace Squares
{
    /// <summary>
    /// ゲームシーン
    /// </summary>
    public class Game : MonoBehaviour 
    {
        [SerializeField] Map map;
        [SerializeField] Square fallingPoint;
        [SerializeField] LimitTimer limitTimer;
        [SerializeField] Score highScore;
        [SerializeField] Score score;
        [SerializeField] Chain chain;
        [SerializeField] TouchStartAnimation touchStartAnimation;
        [SerializeField] VanishingAnimation vanishingAnimation;
        [SerializeField] FallingAnimation fallingAnimation;
        [SerializeField] WaitAnimation waitAnimation;
        [SerializeField] GameObject gameEnd;
        [SerializeField, ReadOnly] GameSequence sq;
        [SerializeField, ReadOnly] Square autoFallingSquare;
        [SerializeField, ReadOnly] bool isFastAutoFalling;
        
        public static GameData Data => App.GameData;

        void Start()
        {
            map.Init(OnMapTap, OnMapBeginHold, OnMapEndHold);
            
            touchStartAnimation.Play();
            sq = TouchStart;
        }

        void Update()
        {
            if(sq == UserInput)
            {
                // ユーザ入力
                if(limitTimer.IsPlaying && map.CanPutSquareStartPosition())
                {
                    // ゲーム中
                    var speed   = isFastAutoFalling ? Game.Data.FastAutoFallingSpeed : Game.Data.AutoFallingSpeed;
                    var movingY = autoFallingSquare.transform.localPosition.y - Time.deltaTime * speed;
                    if(movingY > fallingPoint.Y)
                    {
                        // 落下中
                        var pos = autoFallingSquare.transform.localPosition;
                        autoFallingSquare.SetPosition(pos.x, movingY, pos.z);
                    }
                    else
                    {
                        // 落下した
                        isFastAutoFalling = false;
                        fallingPoint.gameObject.SetActive(false);

                        autoFallingSquare.SetPosition(fallingPoint.X, fallingPoint.Y, fallingPoint.Z);
                        map[fallingPoint.X, fallingPoint.Y, fallingPoint.Z] = autoFallingSquare;
                        autoFallingSquare.ColliderEnabled = true;

                        // 消去スクエア判定へ
                        sq = VanishedSquareSearch;
                    }
                }
                else
                {
                    // ゲームエンド
                    limitTimer.Stop();
                    autoFallingSquare?.gameObject.SetActive(false);
                    fallingPoint.gameObject.SetActive(false);

                    if(score.Point > SaveData.HighScore)
                    {
                        SaveData.HighScore = score.Point;
                        SaveData.Save();
                    }

                    gameEnd.SetActive(true);
                    sq = GameEnd;
                }
            }
            else if(sq == VanishedSquareSearch)
            {
                // 消去スクエア判定
                var (vanishedSquares, _) = map.SearchVanishedSquares();
                if(vanishedSquares.Count > 0)
                {
                    // 消去アニメーション再生
                    chain.Count++;
                    vanishingAnimation.Play(vanishedSquares);
                    sq = VanishingAnimationPlaying;
                }
                else
                {
                    // スクエア作成へ(すぐに移行するとテンポが悪いのでディレイを入れる)
                    chain.Count = 0;
                    waitAnimation.Play(Game.Data.SquareCreationDelay);
                    sq = SquareCreation;
                }
            }
            else if(sq == VanishingAnimationPlaying)
            {
                // 消去アニメーション再生中
                if(!vanishingAnimation.IsPlaying)
                {
                    if(chain.Count >= Game.Data.ChainAnimationStartCount)
                    {
                        chain.Animation.Play(chain.Count, map.VanishedSquares);
                    }
                    score.AddPoint(chain.Count, map.VanishedSquares, map.VanishedConnectingCounts);

                    foreach(var square in map.VanishedSquares)
                    {
                        map[square.X, square.Y, square.Z] = null;
                        square.gameObject.SetActive(false);
                    }

                    // 落下スクエア判定
                    var fallenSquares = map.SearchFallenSquares();
                    if(fallenSquares.Count > 0)
                    {
                        // 落下アニメーション再生
                        fallingAnimation.Play(fallenSquares);
                        sq = FallingAnimationPlaying;
                    }
                    else
                    {
                        // 再度、消去スクエア判定へ
                        sq = VanishedSquareSearch;
                    }
                }
            }
            else if(sq == FallingAnimationPlaying)
            {
                // 落下アニメーション再生中
                if(!fallingAnimation.IsPlaying)
                {
                    // 再度、消去スクエア判定へ
                    foreach(var square in map.FallenSquares)
                    {
                        map[square.X, square.Y,       square.Z] = null;
                        map[square.X, square.FallenY, square.Z] = square;
                        square.SetPosition(square.X, square.FallenY, square.Z);
                    }
                    sq = VanishedSquareSearch;
                }
            }
            else if(sq == SquareCreation)
            {
                // スクエア作成
                if(!waitAnimation.IsPlaying)
                {
                    autoFallingSquare = map.CreateSquare();

                    fallingPoint.ColorType = autoFallingSquare.ColorType;
                    fallingPoint.Alpha     = Game.Data.FallingPointAlpha;
                    fallingPoint.gameObject.SetActive(true);

                    sq = UserInput;
                    OnMapTap(autoFallingSquare.X, autoFallingSquare.Y, autoFallingSquare.Z);
                }
            }
        }
        
        public void OnTouchStartTap()
        {
            touchStartAnimation.Stop();
            
            // ゲーム開始！
            highScore.SetPoint(SaveData.HighScore);
            limitTimer.Play();
            sq = SquareCreation;
        }

        public void OnMapTap(int x, int y, int z)
        {
            if(!sq.IsUserInput()) return;

            // 落下ポイント移動
            map.SearchFallingPointPosition(x, ref y, z);
            if(y < Game.Data.MapHeight)
            {
                var squareY = autoFallingSquare.transform.localPosition.y;
                autoFallingSquare.SetPosition(x, squareY, z);
                fallingPoint.SetPosition(x, y, z);
            }
        }

        public void OnMapBeginHold(int x, int y, int z)
        {
            if(!sq.IsUserInput()) return;

            // 落下ポイントと同じ位置をホールドしたら高速自動落下
            if(x == fallingPoint.X && z == fallingPoint.Z) isFastAutoFalling = true;
        }

        public void OnMapEndHold(int x, int y, int z) => isFastAutoFalling = false;

        // ゲームエンド後、タップで今回はゲームリスタート
        public void OnGameEndTap() => SceneManager.LoadScene(nameof(Game));
    }
}