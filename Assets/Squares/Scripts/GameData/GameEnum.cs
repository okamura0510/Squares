// Auto-generated files
using G2U4S;
using Squares;
using UnityEngine;
using System;

namespace Squares
{
    /// <summary>
    /// ゲームシーケンス
    /// </summary>
    public enum GameSequence : int
    {
        /// <summary>
        /// なし
        /// </summary>
        None,
        /// <summary>
        /// タッチスタート
        /// </summary>
        TouchStart,
        /// <summary>
        /// ユーザ入力
        /// </summary>
        UserInput,
        /// <summary>
        /// 消去スクエア判定
        /// </summary>
        VanishedSquareSearch,
        /// <summary>
        /// 消去アニメーション再生中
        /// </summary>
        VanishingAnimationPlaying,
        /// <summary>
        /// 落下アニメーション再生中
        /// </summary>
        FallingAnimationPlaying,
        /// <summary>
        /// スクエア作成
        /// </summary>
        SquareCreation,
        /// <summary>
        /// ゲームエンド
        /// </summary>
        GameEnd,
    }
    /// <summary>
    /// タッチ状態
    /// </summary>
    public enum TouchState : int
    {
        /// <summary>
        /// なし
        /// </summary>
        None,
        /// <summary>
        /// 押下中
        /// </summary>
        Pressing,
        /// <summary>
        /// ホールド中
        /// </summary>
        Holding,
        /// <summary>
        /// スワイプ中
        /// </summary>
        Swiping,
    }
    /// <summary>
    /// スクエアカラータイプ
    /// </summary>
    public enum SquareColorType : int
    {
        /// <summary>
        /// 赤
        /// </summary>
        Red,
        /// <summary>
        /// 青
        /// </summary>
        Blue,
        /// <summary>
        /// 緑
        /// </summary>
        Green,
        /// <summary>
        /// 黄
        /// </summary>
        Yellow,
        /// <summary>
        /// 紫
        /// </summary>
        Purple,
    }

    public static partial class G2U4Subenum
	{
        /// <summary>
        /// なし
        /// </summary>
        public static bool IsNone(this GameSequence value) { return value == GameSequence.None; }
        /// <summary>
        /// タッチスタート
        /// </summary>
        public static bool IsTouchStart(this GameSequence value) { return value == GameSequence.TouchStart; }
        /// <summary>
        /// ユーザ入力
        /// </summary>
        public static bool IsUserInput(this GameSequence value) { return value == GameSequence.UserInput; }
        /// <summary>
        /// 消去スクエア判定
        /// </summary>
        public static bool IsVanishedSquareSearch(this GameSequence value) { return value == GameSequence.VanishedSquareSearch; }
        /// <summary>
        /// 消去アニメーション再生中
        /// </summary>
        public static bool IsVanishingAnimationPlaying(this GameSequence value) { return value == GameSequence.VanishingAnimationPlaying; }
        /// <summary>
        /// 落下アニメーション再生中
        /// </summary>
        public static bool IsFallingAnimationPlaying(this GameSequence value) { return value == GameSequence.FallingAnimationPlaying; }
        /// <summary>
        /// スクエア作成
        /// </summary>
        public static bool IsSquareCreation(this GameSequence value) { return value == GameSequence.SquareCreation; }
        /// <summary>
        /// ゲームエンド
        /// </summary>
        public static bool IsGameEnd(this GameSequence value) { return value == GameSequence.GameEnd; }

        /// <summary>
        /// なし
        /// </summary>
        public static bool IsNone(this TouchState value) { return value == TouchState.None; }
        /// <summary>
        /// 押下中
        /// </summary>
        public static bool IsPressing(this TouchState value) { return value == TouchState.Pressing; }
        /// <summary>
        /// ホールド中
        /// </summary>
        public static bool IsHolding(this TouchState value) { return value == TouchState.Holding; }
        /// <summary>
        /// スワイプ中
        /// </summary>
        public static bool IsSwiping(this TouchState value) { return value == TouchState.Swiping; }
        /// <summary>
        /// タッチ中
        /// </summary>
        public static bool IsTouching(this TouchState value) { return value == TouchState.Pressing || value == TouchState.Holding || value == TouchState.Swiping; }

        /// <summary>
        /// 赤
        /// </summary>
        public static bool IsRed(this SquareColorType value) { return value == SquareColorType.Red; }
        /// <summary>
        /// 青
        /// </summary>
        public static bool IsBlue(this SquareColorType value) { return value == SquareColorType.Blue; }
        /// <summary>
        /// 緑
        /// </summary>
        public static bool IsGreen(this SquareColorType value) { return value == SquareColorType.Green; }
        /// <summary>
        /// 黄
        /// </summary>
        public static bool IsYellow(this SquareColorType value) { return value == SquareColorType.Yellow; }
        /// <summary>
        /// 紫
        /// </summary>
        public static bool IsPurple(this SquareColorType value) { return value == SquareColorType.Purple; }
	}
}