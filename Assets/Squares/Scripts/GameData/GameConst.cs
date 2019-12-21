// Auto-generated files
using G2U4S;
using Squares;
using UnityEngine;
using System;

namespace Squares
{
    /// <summary>
    /// ゲーム定数
    /// </summary>
    public static class GameConst
    {
        /// <summary>
        /// ゲームバージョン
        /// </summary>
        public const string Version = "3.2.1";
        /// <summary>
        /// エディタか
        /// </summary>
        public static readonly bool IsEditor = Application.isEditor;
        /// <summary>
        /// Androidか
        /// </summary>
        public static readonly bool IsAndroid = Application.platform == RuntimePlatform.Android;
        /// <summary>
        /// iOSか
        /// </summary>
        public static readonly bool IsIOS = Application.platform == RuntimePlatform.IPhonePlayer;
        /// <summary>
        /// モバイルか
        /// </summary>
        public static readonly bool IsMobile = IsAndroid || IsIOS;
        /// <summary>
        /// WebGLか
        /// </summary>
        public static readonly bool IsWebGL = Application.platform == RuntimePlatform.WebGLPlayer;
        /// <summary>
        /// 画面横幅
        /// </summary>
        public static readonly int ScreenWidth = Screen.width;
        /// <summary>
        /// 画面縦幅
        /// </summary>
        public static readonly int ScreenHeight = Screen.height;
        /// <summary>
        /// キャンバス横幅
        /// </summary>
        public const int CanvasWidth = 1080;
        /// <summary>
        /// キャンバス縦幅
        /// </summary>
        public const int CanvasHeight = 1920;
        /// <summary>
        /// Prefabパス
        /// </summary>
        public const string PrefabPath = "Prefabs/{0}";
        /// <summary>
        /// Materialパス
        /// </summary>
        public const string MaterialPath = "Materials/{0}";
        /// <summary>
        /// ScriptableObjectパス
        /// </summary>
        public const string ScriptableObjectPath = "ScriptableObjects/{0}";
    }
}