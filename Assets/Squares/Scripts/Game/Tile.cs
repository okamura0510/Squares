using UnityEngine;
using System;

namespace Squares
{
    /// <summary>
    /// タイル
    /// </summary>
    public class Tile : MonoBehaviour
    {
        [SerializeField] new MeshRenderer renderer;
        [SerializeField] TouchEventTrigger touch;
        [SerializeField, ReadOnly] int x;
        [SerializeField, ReadOnly] int y;
        [SerializeField, ReadOnly] int z;

        public static Tile Create(
            int x, int y, int z, Transform parent, 
            Action<int, int, int> onTap = null, Action<int, int, int> onBeginHold = null, Action<int, int, int> onEndHold = null)
        {
            var tile               = Resource.LoadPrefab<Tile>(parent);
            tile.renderer.material = Resource.LoadMaterial<Tile>();

            tile.name = $"{nameof(Tile)}_{x}_{y}_{z}";
            tile.x    = x;
            tile.y    = y;
            tile.z    = z;
            tile.transform.localPosition = new Vector3(x, y + Game.Data.TileOffsetY, z);
            tile.renderer.material.color = Game.Data.TileColors[(x + z) % 2];

            if(onTap       != null) tile.touch.OnTap.AddListener(_       => onTap(      tile.x, tile.y, tile.z));
            if(onBeginHold != null) tile.touch.OnBeginHold.AddListener(_ => onBeginHold(tile.x, tile.y, tile.z));
            if(onEndHold   != null) tile.touch.OnEndHold.AddListener(_   => onEndHold(  tile.x, tile.y, tile.z));
            return tile;
        }
    }
}
