using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SniperChess
{
    public class Knight : GamePiece
    {

        public Knight(SpriteBatch sb, Texture2D tex, Vector2 gridPos, bool white)
            : base(sb, tex, gridPos, white)
        {
            value = 1000000;//one million


        }

        public override void MovePotential()
        {
            //list of moves
            moves.Add(new Vector2(1, 0));
            moves.Add(new Vector2(1, 1));
            moves.Add(new Vector2(0, 1));
            moves.Add(new Vector2(-1, 1));
            moves.Add(new Vector2(-1, 0));
            moves.Add(new Vector2(-1, -1));
            moves.Add(new Vector2(0, -1));
            moves.Add(new Vector2(1, -1));

            for (int i = moves.Count - 1; i >= 0; i--)
            {
                Vector2 tempPos = this.gridPos + moves[i];
                for (int j = 0; j < GameStat.WhitePieces.Count; j++)
                {
                    if (tempPos.Equals(GameStat.WhitePieces[j].gridPos))
                    {
                        moves.RemoveAt(i);
                    }
                }
                for (int j = 0; j < GameStat.BlackPieces.Count; j++)
                {
                    if (tempPos.Equals(GameStat.BlackPieces[j].gridPos))
                    {
                        moves.RemoveAt(i);
                    }
                }
            }
        }

        public override void Draw()
        {

            base.Draw();
        }

    }
}
