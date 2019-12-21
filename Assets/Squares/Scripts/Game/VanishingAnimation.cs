using UnityEngine;
using System.Collections.Generic;
using DG.Tweening;

namespace Squares
{
    /// <summary>
    /// 消去アニメーション
    /// </summary>
    public class VanishingAnimation : MonoBehaviour
    {
        [SerializeField, ReadOnly] bool isPlaying;
        [SerializeField, ReadOnly] List<Square> vanishedSquares;

        public bool IsPlaying => isPlaying;

        public void Play(List<Square> vanishedSquares)
        {
            this.vanishedSquares = vanishedSquares;

            // 2回フラッシュさせる
            isPlaying    = true;
            var range    = Game.Data.VanishingFlashRange;
            var duration = Game.Data.VanishingFlashDuration;
            DOTween.Sequence()
                   .Append(DOTween.To(UpdateAlpha, range.y, range.x, duration))
                   .Append(DOTween.To(UpdateAlpha, range.x, range.y, duration))
                   .Append(DOTween.To(UpdateAlpha, range.y, range.x, duration))
                   .Append(DOTween.To(UpdateAlpha, range.x, range.y, duration))
                   .OnComplete(() => isPlaying = false);
        }

        void UpdateAlpha(float a)
        {
            foreach(var square in vanishedSquares) square.Alpha = a;
        }
    }
}
