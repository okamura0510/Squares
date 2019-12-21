using UnityEngine;
using static Squares.GameConst;

namespace Squares
{
    /// <summary>
    /// リソースマネージャ
    /// </summary>
    public class Resource : MonoBehaviour
    {
        static Resource instance => App.Resource;

        public static T LoadPrefab<T>(Transform parent = null) where T : Component
        {
            return LoadPrefab<T>(typeof(T).Name, parent);
        }

        public static T LoadPrefab<T>(string fileName, Transform parent = null) where T : Component
        {
            return LoadPrefab(fileName, parent).GetComponent<T>();
        }

        public static GameObject LoadPrefab(string fileName, Transform parent = null)
        {
            var path = string.Format(PrefabPath, fileName);
            var go   = Instantiate(Resources.Load<GameObject>(path), parent);
            go.name  = fileName;
            return go;
        }

        public static Material LoadMaterial<T>() where T : Component
        {
            return LoadMaterial(typeof(T).Name);
        }

        public static Material LoadMaterial(string fileName)
        {
            var path = string.Format(MaterialPath, fileName);
            return Instantiate(Resources.Load<Material>(path));
        }
    }
}