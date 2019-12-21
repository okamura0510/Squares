using UnityEngine;

namespace Squares
{
    /// <summary>
    /// 連鎖
    /// </summary>
    public class Chain : MonoBehaviour
    {
        [SerializeField] new ChainAnimation animation;
        [SerializeField, ReadOnly] int count;

        public ChainAnimation Animation => animation;
        public int Count { get { return count; } set { count = value; } }
	}
}