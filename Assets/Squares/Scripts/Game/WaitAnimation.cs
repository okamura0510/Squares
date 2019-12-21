using UnityEngine;

namespace Squares
{
    /// <summary>
    /// ウェイトアニメーション
    /// </summary>
    public class WaitAnimation : MonoBehaviour
    {
        [SerializeField, ReadOnly] bool isPlaying;
        [SerializeField, ReadOnly] float waitTime;

        public bool IsPlaying => isPlaying;

        void Update()
        {
            if(isPlaying)
            {
                waitTime -= Time.deltaTime;
                if(waitTime <= 0) isPlaying = false;
            }
        }

        public void Play(float waitTime)
        {
            this.waitTime = waitTime;
            isPlaying     = true;
        }
    }
}