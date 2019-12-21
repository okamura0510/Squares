using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using DG.Tweening;
using static DG.Tweening.Ease;

namespace Squares
{
    /// <summary>
    /// 連鎖アニメーション
    /// </summary>
    public class ChainAnimation : MonoBehaviour
    {
        [SerializeField] new Camera camera;
        [SerializeField] Text text;
        [SerializeField] Outline outline;
        [SerializeField, ReadOnly] bool isPlaying;

        public bool IsPlaying => isPlaying;

        public void Play(int chainCount, List<Square> vanishedSquares)
        {
            // 連鎖数を設定
            text.text = string.Format(Game.Data.ChainText, chainCount);

            // 消去スクエアの最大/最小座標を取得
            int minX = int.MaxValue, maxX = -int.MaxValue;
            int minY = int.MaxValue, maxY = -int.MaxValue;
            int minZ = int.MaxValue, maxZ = -int.MaxValue;
            foreach(var square in vanishedSquares)
            {
                if(square.X < minX) minX = square.X;
                if(square.X > maxX) maxX = square.X;

                if(square.Y < minY) minY = square.Y;
                if(square.Y > maxY) maxY = square.Y;

                if(square.Z < minZ) minZ = square.Z;
                if(square.Z > maxZ) maxZ = square.Z;
            }

            // 消去スクエアの中央座標に移動
            var centerX        = minX + (maxX - minX) / 2;
            var centerY        = minY + (maxY - minY) / 2;
            var centerZ        = minZ + (maxZ - minZ) / 2;
            var center         = new Vector3(centerX, centerY, centerZ);
            transform.position = RectTransformUtility.WorldToScreenPoint(camera, center);
            
            // 上に移動しながらフェイドして消える
            isPlaying          = true;
            var movingY        = Game.Data.ChainMovingY;
            var movingDuration = Game.Data.ChainMovingDuration;
            var fadeDuration   = Game.Data.ChainFadeDuration;
            DOTween.Sequence()
                   .Append(transform.DOLocalMoveY(movingY, movingDuration).SetEase(OutQuad).SetRelative(true))
                   .Append(text.DOFade(0, fadeDuration)).Join(outline.DOFade(0, fadeDuration))
                   .OnComplete(() =>
            {
                gameObject.SetActive(false);
                text.SetColorA(1);
                outline.SetColorA(1);
                isPlaying = false;
            });
            gameObject.SetActive(true);
        }
    }
}
