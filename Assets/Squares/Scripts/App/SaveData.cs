using UnityEngine;

namespace Squares
{
    /// <summary>
    /// セーブデータマネージャ
    /// </summary>
    public class SaveData : MonoBehaviour
    {
        static SaveData instance => App.SaveData;

        [SerializeField, ReadOnly] int highScore;

        public static int HighScore { get { return instance.highScore; } set { instance.highScore = value; } }

        public static void Save()
        {
            PlayerPrefs.SetInt(nameof(highScore), HighScore);
            PlayerPrefs.Save();
        }

        public static void Load()
        {
            HighScore = PlayerPrefs.GetInt(nameof(highScore), 0);
        }
    }
}