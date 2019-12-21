using UnityEngine;
using UnityEngine.UI;

namespace Squares
{
    /// <summary>
    /// 制限時間
    /// </summary>
    public class LimitTimer : MonoBehaviour
    {
        [SerializeField] Text text;
        [SerializeField, ReadOnly] bool isPlaying;
        [SerializeField, ReadOnly] float time;
        [SerializeField, ReadOnly] int lastSecond;

        public bool IsPlaying => isPlaying;

        void Start() => text.text = Game.Data.LimitTime.ToString();

        void Update()
        {
            if(isPlaying)
            {
                time -= Time.deltaTime;

                var second = (int)time;
                if(second != lastSecond)
                {
                    lastSecond = second;
                    if(second <= 0)
                    {
                        second    = 0;
                        text.text = second.ToString();
                        isPlaying = false;
                    }
                    else
                    {
                        text.text = (second + 1).ToString();
                    }
                }
            }
        }

        public void Play()
        {
            isPlaying  = true;
            time       = Game.Data.LimitTime;
            lastSecond = (int)time;
        }

        public void Stop()
        {
            text.text  = "0";
            isPlaying  = false;
        }
    }
}
