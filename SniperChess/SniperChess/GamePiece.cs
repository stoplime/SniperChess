using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SniperChess
{
    public abstract class GamePiece
    {
        private SpriteBatch spriteBatch;
        private Texture2D texture;
        private bool selected;

        protected List<Vector2> moves;
        protected int value;
        public int Value
        {
            get { return value; }
        }

        public Vector2 gridPos;

        public GamePiece(SpriteBatch sb, Texture2D tex, Vector2 gridPos)
        {
            spriteBatch = sb;
            texture = tex;
            selected = false;
            this.gridPos = gridPos;
        }

        public abstract void MovePotential();


        public virtual void Update()
        {
            select();

            if (selected)
            {
                if (GameStat.MouseClick && !gridPos.Equals(GameStat.MousePosGrid) && containInGrid(GameStat.MousePosGrid))
                {
                    gridPos = GameStat.MousePosGrid;
                    selected = false;
                }
            }
        }

        public virtual void Draw()
        {
            if (selected)
            {
                spriteBatch.Draw(texture, GameStat.GridToPos(gridPos), Color.LawnGreen);
            }
            else 
            {
                spriteBatch.Draw(texture, GameStat.GridToPos(gridPos), Color.White);
            }
            
        }

        private void select()
        {
            if (GameStat.MousePosGrid.Equals(gridPos))
            {
                if (GameStat.MouseClick)
                {
                    if (!selected)
                    {
                        selected = true;
                    }
                    else
                    {
                        selected = false;
                    }

                }
            }
        }

        private bool containInGrid(Vector2 posGrid)
        {
            if (posGrid.X >=0 && posGrid.X < 8)
            {
                if (posGrid.Y >= 0 && posGrid.Y < 8)
                {
                    return true;
                }
            }
            return false;
        }

    }
}
