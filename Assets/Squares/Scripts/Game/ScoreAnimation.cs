using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

namespace Squares
{
    /// <summary>
    /// スコアアニメーション
    /// </summary>
    public class ScoreAnimation : MonoBehaviour
    {
        [SerializeField] Text text;
        [SerializeField] string format = "{0}";
        [SerializeField, ReadOnly] bool isPlaying;
        [SerializeField, ReadOnly] int nowPoint;
        Tweener tweener;

        public bool IsPlaying => isPlaying;
        
        public void Play(int totalPoint)
        {
            // 現在ポイントからトータルポイントへカウントアップ
            isPlaying    = true;
            var duration = Game.Data.ScoreCountupDuration;
            tweener?.Kill();
            tweener = DOTween.To(() => nowPoint, UpdatePoint, totalPoint, duration).OnComplete(() => isPlaying = false);
        }

        void UpdatePoint(int point)
        {
            nowPoint  = point;
            text.text = string.Format(format, point);
        }
    }
}
