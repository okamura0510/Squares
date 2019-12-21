using UnityEngine;
using System.Collections.Generic;

namespace Squares
{
    /// <summary>
    /// スコア
    /// </summary>
    public class Score : MonoBehaviour
    {
        [SerializeField] new ScoreAnimation animation;
        [SerializeField, ReadOnly] int point;
        [SerializeField, ReadOnly] bool[] canVanishColors;

        public int Point => point;

        void Start() => canVanishColors = new bool[Game.Data.SquareColors.Length];
        
        public void SetPoint(int point)
        {
            this.point = point;
            animation.Play(point);
        }

        public void AddPoint(int chainCount, List<Square> vanishedSquares, List<int> vanishedConnectingCounts)
        {
            // 消去ポイント(消去スクエアの数 × 10)
            var vanishingPoint = vanishedSquares.Count * Game.Data.ScoreVanishingPointBase;

            // 連鎖ボーナス
            var chainBonus = Game.Data.ScoreChainBonuses[chainCount - 1];
            
            // 連結数ボーナス(上限値あり)
            var connectingBonus   = 0;
            var connectingBonuses = Game.Data.ScoreConnectingBonuses;
            var vanishableCount   = Game.Data.VanishableCount;
            foreach(var connectingCount in vanishedConnectingCounts)
            {
                var idx = Mathf.Max(
                    connectingCount - vanishableCount, connectingBonuses.Length - 1);
                connectingBonus += connectingBonuses[idx];
            }
            
            // 色数ボーナス
            for(var i = 0; i < canVanishColors.Length; i++)
            {
                canVanishColors[i] = false;
            }

            var vanishedColorCount = 0;
            foreach(var square in vanishedSquares)
            {
                var colorIdx = (int)square.ColorType;
                if(!canVanishColors[colorIdx])
                {
                    canVanishColors[colorIdx] = true;
                    vanishedColorCount++;
                }
            }
            var colorBonus = Game.Data.ScoreColorBonuses[vanishedColorCount - 1];

            // 総ボーナス(下限値あり)
            var totalBonus = Mathf.Max(
                chainBonus + connectingBonus + colorBonus, Game.Data.ScoreTotalBonusMin);

            // ポイント追加
            point += vanishingPoint * totalBonus;
            animation.Play(point);
        }
    }
}