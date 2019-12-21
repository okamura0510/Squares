using UnityEngine;
using System;

namespace Squares
{
    /// <summary>
    /// スクエア
    /// </summary>
    public class Square : MonoBehaviour
    {
        [SerializeField] new MeshRenderer renderer;
        [SerializeField] new BoxCollider collider;
        [SerializeField] TouchEventTrigger touch;
        [SerializeField, ReadOnly] SquareColorType colorType;
        [SerializeField, ReadOnly] int x;
        [SerializeField, ReadOnly] int y;
        [SerializeField, ReadOnly] int z;
        [SerializeField, ReadOnly] int connectingId;
        [SerializeField, ReadOnly] int fallenY;

        public SquareColorType ColorType
        {
            get { return colorType; }
            set
            {
                colorType               = value;
                renderer.material.color = Game.Data.SquareColors[(int)value];
            }
        }
        public int X => x;
        public int Y => y;
        public int Z => z;
        public int ConnectingId     { get { return connectingId;              } set { connectingId     = value;  } }
        public int FallenY          { get { return fallenY;                   } set { fallenY          = value;  } }
        public bool ColliderEnabled { get { return collider.enabled;          } set { collider.enabled = value;  } }
        public float Alpha          { get { return renderer.material.color.a; } set { renderer.SetColorA(value); } }
        
        public static Square Create(
            SquareColorType colorType, int x, int y, int z, Transform parent, 
            Action<int, int, int> onTap = null, Action<int, int, int> onBeginHold = null, Action<int, int, int> onEndHold = null)
        {
            var square               = Resource.LoadPrefab<Square>(parent);
            square.renderer.material = Resource.LoadMaterial<Square>();

            square.name      = $"{nameof(Square)}_{colorType}";
            square.ColorType = colorType;
            square.SetPosition(x, y, z);

            if(onTap       != null) square.touch.OnTap.AddListener(_       => onTap(      square.x, square.y, square.z));
            if(onBeginHold != null) square.touch.OnBeginHold.AddListener(_ => onBeginHold(square.x, square.y, square.z));
            if(onEndHold   != null) square.touch.OnEndHold.AddListener(_   => onEndHold(  square.x, square.y, square.z));
            return square;
        }

        public void SetPosition(int x, int y, int z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            transform.localPosition = new Vector3(x, y, z);
        }

        public void SetPosition(float x, float y, float z)
        {
            this.x = (int)x;
            this.y = (int)y;
            this.z = (int)z;
            transform.localPosition = new Vector3(x, y, z);
        }
    }
}