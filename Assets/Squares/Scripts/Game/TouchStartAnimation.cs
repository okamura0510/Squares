using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using static DG.Tweening.LoopType;

namespace Squares
{
    /// <summary>
    /// タッチスタートアニメーション
    /// </summary>
    public class TouchStartAnimation : MonoBehaviour
    {
        [SerializeField] Text text;
        [SerializeField] Outline outline;
        [SerializeField, ReadOnly] bool isPlaying;
        Tweener textTweener;
        Tweener outlineTweener;

        public bool IsPlaying => isPlaying;

        public void Play()
        {
            // アルファをフェイドさせてフワフワさせる
            isPlaying      = true;
            var a          = Game.Data.TouchStartAlpha;
            var duration   = Game.Data.TouchStartDuration;
            textTweener    = text.DOFade(a,    duration).SetLoops(-1, Yoyo);
            outlineTweener = outline.DOFade(a, duration).SetLoops(-1, Yoyo);
        }

        public void Stop()
        {
            textTweener?.Kill();
            outlineTweener?.Kill();
            gameObject.SetActive(false);
            isPlaying = false;
        }
	}
}