// Auto-generated files
using G2U4S;
using Squares;
using UnityEngine;
using System;

namespace Squares
{
    /// <summary>
    /// ゲームデータ
    /// </summary>
    public class GameData : ScriptableObject
    {
        /// <summary>
        /// マップ横幅
        /// </summary>
        public int MapWidth;
        /// <summary>
        /// マップ縦幅
        /// </summary>
        public int MapHeight;
        /// <summary>
        /// マップ奥行き
        /// </summary>
        public int MapDepth;
        /// <summary>
        /// 消去可能連結数
        /// </summary>
        public int VanishableCount;
        /// <summary>
        /// 制限時間
        /// </summary>
        public int LimitTime;
        /// <summary>
        /// 自動落下速度
        /// </summary>
        public float AutoFallingSpeed;
        /// <summary>
        /// 高速自動落下速度
        /// </summary>
        public float FastAutoFallingSpeed;
        /// <summary>
        /// タイルカラー
        /// </summary>
        public Color[] TileColors;
        /// <summary>
        /// タイルオフセットY
        /// </summary>
        public float TileOffsetY;
        /// <summary>
        /// スクエアカラー
        /// </summary>
        public Color[] SquareColors;
        /// <summary>
        /// スクエア開始位置
        /// </summary>
        public Vector3Int SquareStartPosition;
        /// <summary>
        /// 落下ポイントα
        /// </summary>
        public float FallingPointAlpha;
        /// <summary>
        /// 消去ポイント係数
        /// </summary>
        public int ScoreVanishingPointBase;
        /// <summary>
        /// 連鎖ボーナス
        /// </summary>
        public int[] ScoreChainBonuses;
        /// <summary>
        /// 連結数ボーナス
        /// </summary>
        public int[] ScoreConnectingBonuses;
        /// <summary>
        /// 色数ボーナス
        /// </summary>
        public int[] ScoreColorBonuses;
        /// <summary>
        /// 総ボーナス下限値
        /// </summary>
        public int ScoreTotalBonusMin;
        /// <summary>
        /// ホールド開始時間
        /// </summary>
        public float HoldTime;
        /// <summary>
        /// スワイプ開始距離
        /// </summary>
        public int SwipeDistance;
        /// <summary>
        /// タッチスタートα
        /// </summary>
        public float TouchStartAlpha;
        /// <summary>
        /// タッチスタートアニメ時間
        /// </summary>
        public float TouchStartDuration;
        /// <summary>
        /// 消去アニメフラッシュレンジ
        /// </summary>
        public Vector2 VanishingFlashRange;
        /// <summary>
        /// 消去アニメフラッシュ時間
        /// </summary>
        public float VanishingFlashDuration;
        /// <summary>
        /// 連鎖アニメ開始連鎖数
        /// </summary>
        public int ChainAnimationStartCount;
        /// <summary>
        /// 連鎖テキスト
        /// </summary>
        public string ChainText;
        /// <summary>
        /// 連鎖アニメ移動Y
        /// </summary>
        public float ChainMovingY;
        /// <summary>
        /// 連鎖アニメ移動時間
        /// </summary>
        public float ChainMovingDuration;
        /// <summary>
        /// 連鎖アニメフェイド時間
        /// </summary>
        public float ChainFadeDuration;
        /// <summary>
        /// 落下アニメ時間
        /// </summary>
        public float FallingDuration;
        /// <summary>
        /// スクエア作成ディレイ
        /// </summary>
        public float SquareCreationDelay;
        /// <summary>
        /// スコアカウントアップ時間
        /// </summary>
        public float ScoreCountupDuration;
    }
}