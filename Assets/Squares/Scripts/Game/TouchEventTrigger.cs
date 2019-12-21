using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using System;
using GodTouches;
using static Squares.TouchState;

namespace Squares
{
    [Serializable] public class OnTouchEvent : UnityEvent<GameObject> { }

    /// <summary>
    /// タッチイベントトリガー
    /// </summary>
    public class TouchEventTrigger : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        [SerializeField] bool isScreenTouch;
        [SerializeField, ReadOnly] TouchState state;
        [SerializeField, ReadOnly] float time;
        [SerializeField, ReadOnly] Vector3 startPosition;
        [SerializeField] OnTouchEvent onTap;
        [SerializeField] OnTouchEvent onBeginHold;
        [SerializeField] OnTouchEvent onHold;
        [SerializeField] OnTouchEvent onEndHold;
        [SerializeField] OnTouchEvent onBeginSwipe;
        [SerializeField] OnTouchEvent onSwipe;
        [SerializeField] OnTouchEvent onEndSwipe;

        public OnTouchEvent OnTap        => onTap;
        public OnTouchEvent OnBeginHold  => onBeginHold;
        public OnTouchEvent OnHold       => onHold;
        public OnTouchEvent OnEndHold    => onEndHold;
        public OnTouchEvent OnBeginSwipe => onBeginSwipe;
        public OnTouchEvent OnSwipe      => onSwipe;
        public OnTouchEvent OnEndSwipe   => onEndSwipe;

        void Update()
        {
            if(state == Swiping)
            {
                // スワイプ中
                onSwipe?.Invoke(gameObject);
            }
            else if(state != None)
            {
                // 押下中
                time += Time.deltaTime;

                var deltaPosition = GodTouch.GetPosition() - startPosition;
                var distanceX     = Mathf.Abs(deltaPosition.x);
                var distanceY     = Mathf.Abs(deltaPosition.y);
                if(state == Pressing && time >= Game.Data.HoldTime)
                {
                    // 同じところを一定時間押し続けたらホールドへ
                    state = Holding;
                    onBeginHold?.Invoke(gameObject);
                }
                else if(distanceX >= Game.Data.SwipeDistance || distanceY >= Game.Data.SwipeDistance)
                {
                    // 一定距離を超えたらスワイプへ
                    state = Swiping;
                    onBeginSwipe?.Invoke(gameObject);
                }
                else if(state == Holding)
                {
                    // ホールド中
                    onHold?.Invoke(gameObject);
                }
            }

            // 画面タッチの場合は直接タッチ状態を見る
            if(isScreenTouch)
            {
                switch(GodTouch.GetPhase())
                {
                    case GodPhase.Began: OnPointerDown(null); break;
                    case GodPhase.Ended: OnPointerUp(null);   break;
                }
            }
        }
        
        public void OnPointerDown(PointerEventData e)
        {
            state         = Pressing;
            time          = 0;
            startPosition = GodTouch.GetPosition();
        }

        public void OnPointerUp(PointerEventData e)
        {
            switch(state)
            {
                case Pressing: onTap?.Invoke(gameObject);      break;
                case Holding:  onEndHold?.Invoke(gameObject);  break;
                case Swiping:  onEndSwipe?.Invoke(gameObject); break;
            }
            state = None;
        }
    }
}