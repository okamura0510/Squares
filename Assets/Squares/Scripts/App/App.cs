using UnityEngine;

namespace Squares
{
    /// <summary>
    /// アプリのグローバルデータを保持するクラス。アプリ起動時に生成され、ずっと常駐する(Singleton)。
    /// </summary>
    public class App : MonoBehaviour
    {
        static App instance;
        
        [SerializeField] Resource resource;
        [SerializeField] SaveData saveData;
        [SerializeField] GameData gameData;
        
        public static Resource Resource => instance.resource;
        public static SaveData SaveData => instance.saveData;
        public static GameData GameData => instance.gameData;
        
        // シーンロード前にアプリを作成することで、いつでもインスタンスアクセス可能に
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        static void Create()
        {
            instance = Resource.LoadPrefab<App>();
            DontDestroyOnLoad(instance.gameObject);
            SaveData.Load();
        }
    }
}