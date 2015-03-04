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
        private bool isWhite;
        private bool clickedColor;

        protected List<Vector2> moves;
        protected int value;
        public int Value
        {
            get { return value; }
        }

        public Vector2 gridPos;

        public GamePiece(SpriteBatch sb, Texture2D tex, Vector2 gridPos, bool white)
        {
            spriteBatch = sb;
            texture = tex;
            selected = false;
            this.gridPos = gridPos;
            this.isWhite = white;
        }

        public abstract void MovePotential();


        public virtual void Update()
        {
            select();

            if (selected)
            {
                if (GameStat.MouseClick && !gridPos.Equals(GameStat.MousePosGrid))
                {
                    if (containInGrid(GameStat.MousePosGrid))
                    {
                        if (OnPiece())
                        {
                            if (clickedColor != isWhite)
                            {
                                if (isWhite)
                                {
                                    Capture(GameStat.BlackPieces, GameStat.MousePosGrid);
                                }
                                else {
                                    Capture(GameStat.WhitePieces, GameStat.MousePosGrid);
                                }
                            }
                        }
                        else
                        {
                            gridPos = GameStat.MousePosGrid;
                        }
                    }
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

        private bool OnPiece()
        {
            foreach (GamePiece p in GameStat.WhitePieces)
            {
                if (p.gridPos.Equals(GameStat.MousePosGrid))
                {
                    clickedColor = true;
                    return true;
                }
            }
            foreach (GamePiece p in GameStat.BlackPieces)
            {
                if (p.gridPos.Equals(GameStat.MousePosGrid))
                {
                    clickedColor = false;
                    return true;
                }
            }
            return false;
        }

        private bool Capture(List<GamePiece> pieces, Vector2 posGrid)
        {
            for (int i = pieces.Count - 1; i >= 0; i--)
            {
                if (pieces[i].gridPos.Equals(posGrid))
                {
                    pieces.RemoveAt(i);
                    return true;
                }
            }
            return false;
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
