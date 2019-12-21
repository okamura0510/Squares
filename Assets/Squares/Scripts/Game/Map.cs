using UnityEngine;
using System;
using System.Collections.Generic;
using Random = UnityEngine.Random;

namespace Squares
{
    /// <summary>
    /// マップ。スクエアやタイルの操作を行う。
    /// </summary>
    public class Map : MonoBehaviour
    {
        [SerializeField, ReadOnly] List<Square> connectingSquares     = new List<Square>();
        [SerializeField, ReadOnly] List<Square> vanishedSquares       = new List<Square>();
        [SerializeField, ReadOnly] List<int> vanishedConnectingCounts = new List<int>();
        [SerializeField, ReadOnly] List<Square> fallenSquares         = new List<Square>();
        Square[,,] squares;
        Action<int, int, int> onTap;
        Action<int, int, int> onBeginHold;
        Action<int, int, int> onEndHold;

        public Square this[int x, int y, int z]
        {
            get
            {
                if(x < 0 || x >= Game.Data.MapWidth)  return null;
                if(y < 0 || y >= Game.Data.MapHeight) return null;
                if(z < 0 || z >= Game.Data.MapDepth)  return null;
                return squares[x, y, z];
            }
            set
            {
                if(x < 0 || x >= Game.Data.MapWidth)  return;
                if(y < 0 || y >= Game.Data.MapHeight) return;
                if(z < 0 || z >= Game.Data.MapDepth)  return;
                squares[x, y, z] = value;
            }
        }
        public List<Square> VanishedSquares       => vanishedSquares;
        public List<int> VanishedConnectingCounts => vanishedConnectingCounts;
        public List<Square> FallenSquares         => fallenSquares;

        public void Init(Action<int, int, int> onTap, Action<int, int, int> onBeginHold, Action<int, int, int> onEndHold)
        {
            this.onTap       = onTap;
            this.onBeginHold = onBeginHold;
            this.onEndHold   = onEndHold;

            squares = new Square[Game.Data.MapWidth, Game.Data.MapHeight, Game.Data.MapDepth];

            for(var x = 0; x < Game.Data.MapWidth; x++)
            {
                for(var z = 0; z < Game.Data.MapDepth; z++)
                {
                    Tile.Create(x, 0, z, transform, onTap, onBeginHold, onEndHold);
                }
            }
        }
        
        Square GetSquare(int x, int y, int z) => this[x, y, z];
        
        public Square CreateSquare()
        {
            var colorType = (SquareColorType)Random.Range(0, Game.Data.SquareColors.Length);
            var startPos  = Game.Data.SquareStartPosition;
            return Square.Create(colorType, startPos.x, startPos.y, startPos.z, transform, onTap, onBeginHold, onEndHold);
        }
        
        public void SearchFallingPointPosition(int x, ref int y, int z)
        {
            // Yは空いてる位置を探す
            for(y = 0; y < Game.Data.MapHeight; y++)
            {
                if(GetSquare(x, y, z) == null) break;
            }
        }

        public bool CanPutSquareStartPosition()
        {
            var startPos = Game.Data.SquareStartPosition;
            return CanPutSquare(startPos.x, startPos.y, startPos.z);
        }

        public bool CanPutSquare(int x, int y, int z) => (GetSquare(x, y, z) == null);

        public (List<Square> vanishedSquares, List<int> vanishedConnectingCounts) SearchVanishedSquares()
        {
            vanishedSquares.Clear();
            vanishedConnectingCounts.Clear();
            foreach(var square in squares)
            {
                if(square == null) continue;
                square.ConnectingId = 0;
            }

            var connectingId = 1;
            foreach(var square in squares)
            {
                if(square == null) continue;

                // 連結IDごとの連結スクエア判定
                connectingSquares.Clear();
                SearchConnectingSquares(connectingId, square.ColorType, square.X, square.Y, square.Z);
                if(connectingSquares.Count >= Game.Data.VanishableCount)
                {
                    // 連結数ボーナスのために連結数を保存
                    vanishedConnectingCounts.Add(connectingSquares.Count);

                    // 消去スクエアを保存
                    foreach(var connectingSquare in connectingSquares)
                    {
                        vanishedSquares.Add(connectingSquare);
                    }
                }
                connectingId++;
            }
            return (vanishedSquares, vanishedConnectingCounts);
        }
        
        List<Square> SearchConnectingSquares(int connectingId, SquareColorType colorType, int x, int y, int z)
        {
            var square = GetSquare(x, y, z);
            if(square == null || square.ConnectingId != 0) return connectingSquares;

            if(square.ColorType == colorType)
            {
                square.ConnectingId = connectingId;
                connectingSquares.Add(square);

                SearchConnectingSquares(connectingId, colorType, x + 1, y,     z);
                SearchConnectingSquares(connectingId, colorType, x - 1, y,     z);
                SearchConnectingSquares(connectingId, colorType, x,     y + 1, z);
                SearchConnectingSquares(connectingId, colorType, x,     y - 1, z);
                SearchConnectingSquares(connectingId, colorType, x,     y,     z + 1);
                SearchConnectingSquares(connectingId, colorType, x,     y,     z - 1);
            }
            return connectingSquares;
        }

        public List<Square> SearchFallenSquares()
        {
            fallenSquares.Clear();
            for(var x = 0; x < Game.Data.MapWidth; x++)
            {
                for(var z = 0; z < Game.Data.MapDepth; z++)
                {
                    var canFall     = false;
                    var fallenCount = 0;
                    for(var y = 0; y < Game.Data.MapHeight; y++)
                    {
                        var square = GetSquare(x, y, z);
                        if(square == null)
                        {
                            // 下に空きがあれば落ちる
                            canFall = true;
                            fallenCount++;
                        }
                        else if(canFall)
                        {
                            // 空き数だけ落下させる
                            square.FallenY = y - fallenCount;
                            fallenSquares.Add(square);
                        }
                    }
                }
            }
            return fallenSquares;
        }
    }
}
