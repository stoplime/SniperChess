using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace SniperChess
{
    public static class GameStat
    {
        public const int bgShift = 230;
        public const int GridSize = 52;
        public static Vector2 Shift = new Vector2(42,42);

        public static List<GamePiece> WhitePieces;
        public static List<GamePiece> BlackPieces;

        public static bool select = false;

        public static MouseState mouseState;
        public static Vector2 MousePos;
        public static Vector2 MousePosGrid;
        public static bool MouseClick;

        public static Vector2 GridToPos(Vector2 gridPos)
        {
            Vector2 p = new Vector2(gridPos.X, gridPos.Y);
            p *= GameStat.GridSize;
            p += GameStat.Shift;
            p.X += bgShift;

            return p;
        }

        public static Vector2 PosToGrid(Vector2 pos)
        {
            Vector2 p = new Vector2(pos.X, pos.Y);
            p.X -= bgShift;
            p -= GameStat.Shift; 
            p /= GameStat.GridSize;
            p.X = (float)Math.Floor(p.X);
            p.Y = (float)Math.Floor(p.Y);

            return p;
        }

        public static Rectangle gr { get; set; }
    }
}
