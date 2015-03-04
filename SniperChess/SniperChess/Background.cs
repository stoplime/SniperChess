using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SniperChess
{
    public class Background
    {
        SpriteBatch spriteBatch;
        Vector2 pos;
        Texture2D tex;

        public Background(SpriteBatch sb, Texture2D bgTexure, Vector2 bgPos)
        {
            spriteBatch = sb;
            tex = bgTexure;
            pos = bgPos;

        }

        public void Draw()
        {
            spriteBatch.Draw(tex,pos,Color.White);
        }

    }
}
