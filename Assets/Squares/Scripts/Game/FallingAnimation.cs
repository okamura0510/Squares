using UnityEngine;
using System.Collections.Generic;
using DG.Tweening;

namespace Squares
{
    /// <summary>
    /// 落下アニメーション
    /// </summary>
    public class FallingAnimation : MonoBehaviour
    {
        [SerializeField, ReadOnly] bool isPlaying;

        public bool IsPlaying => isPlaying;

        public void Play(List<Square> fallenSquares)
        {
            // 等速落下
            isPlaying = true;
            for(var i = 0; i < fallenSquares.Count; i++)
            {
                var square  = fallenSquares[i];
                var tweener = square.transform.DOLocalMoveY(square.FallenY, Game.Data.FallingDuration);
                if(i == 0) tweener.OnComplete(() => isPlaying = false);
            }
        }
    }
}
