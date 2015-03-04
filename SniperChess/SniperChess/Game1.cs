using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace SniperChess
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        
        Background chessBoard;
        MouseState mouseState;
        Vector2 mousePos;
        Vector2 mousePosGrid;
        bool mouseClick;
        bool preMouseClick;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            graphics.PreferredBackBufferWidth = 960;
            graphics.PreferredBackBufferHeight = 544;

        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            this.IsMouseVisible = true;

            GameStat.BlackPieces = new List<GamePiece>();
            GameStat.WhitePieces = new List<GamePiece>();
            mousePos = new Vector2();
            mousePosGrid = new Vector2();
            mouseClick = false;
            preMouseClick = false;

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            Vector2 bgPos = new Vector2(230,0);
            Texture2D bgTex = Content.Load<Texture2D>("ChessBoard");
            chessBoard = new Background(spriteBatch,bgTex,bgPos);

            Texture2D B_KingTex = Content.Load<Texture2D>("piece/B_King");
            Texture2D B_QueenTex = Content.Load<Texture2D>("piece/B_Queen");
            Texture2D B_BishopTex = Content.Load<Texture2D>("piece/B_Bishop");
            Texture2D B_KnightTex = Content.Load<Texture2D>("piece/B_Knight");
            Texture2D B_RookTex = Content.Load<Texture2D>("piece/B_Rook");
            Texture2D B_PawnTex = Content.Load<Texture2D>("piece/B_Pawn");

            Texture2D W_KingTex = Content.Load<Texture2D>("piece/W_King");
            Texture2D W_QueenTex = Content.Load<Texture2D>("piece/W_Queen");
            Texture2D W_BishopTex = Content.Load<Texture2D>("piece/W_Bishop");
            Texture2D W_KnightTex = Content.Load<Texture2D>("piece/W_Knight");
            Texture2D W_RookTex = Content.Load<Texture2D>("piece/W_Rook");
            Texture2D W_PawnTex = Content.Load<Texture2D>("piece/W_Pawn");

            King bk = new King(spriteBatch, B_KingTex, new Vector2(4, 0), false);
            Queen bq = new Queen(spriteBatch, B_QueenTex, new Vector2(3, 0), false);
            Bishop bb1 = new Bishop(spriteBatch, B_BishopTex, new Vector2(2, 0), false);
            Bishop bb2 = new Bishop(spriteBatch, B_BishopTex, new Vector2(5, 0), false);
            Knight bk1 = new Knight(spriteBatch, B_KnightTex, new Vector2(1, 0), false);
            Knight bk2 = new Knight(spriteBatch, B_KnightTex, new Vector2(6, 0), false);
            Rook br1 = new Rook(spriteBatch, B_RookTex, new Vector2(0, 0), false);
            Rook br2 = new Rook(spriteBatch, B_RookTex, new Vector2(7, 0), false);
            Pawn bp1 = new Pawn(spriteBatch, B_PawnTex, new Vector2(0, 1), false);
            Pawn bp2 = new Pawn(spriteBatch, B_PawnTex, new Vector2(1, 1), false);
            Pawn bp3 = new Pawn(spriteBatch, B_PawnTex, new Vector2(2, 1), false);
            Pawn bp4 = new Pawn(spriteBatch, B_PawnTex, new Vector2(3, 1), false);
            Pawn bp5 = new Pawn(spriteBatch, B_PawnTex, new Vector2(4, 1), false);
            Pawn bp6 = new Pawn(spriteBatch, B_PawnTex, new Vector2(5, 1), false);
            Pawn bp7 = new Pawn(spriteBatch, B_PawnTex, new Vector2(6, 1), false);
            Pawn bp8 = new Pawn(spriteBatch, B_PawnTex, new Vector2(7, 1), false);
            GameStat.BlackPieces.Add(bk);
            GameStat.BlackPieces.Add(bq);
            GameStat.BlackPieces.Add(bb1);
            GameStat.BlackPieces.Add(bb2);
            GameStat.BlackPieces.Add(bk1);
            GameStat.BlackPieces.Add(bk2);
            GameStat.BlackPieces.Add(br1);
            GameStat.BlackPieces.Add(br2);
            GameStat.BlackPieces.Add(bp1);
            GameStat.BlackPieces.Add(bp2);
            GameStat.BlackPieces.Add(bp3);
            GameStat.BlackPieces.Add(bp4);
            GameStat.BlackPieces.Add(bp5);
            GameStat.BlackPieces.Add(bp6);
            GameStat.BlackPieces.Add(bp7);
            GameStat.BlackPieces.Add(bp8);

            King wk = new King(spriteBatch, W_KingTex, new Vector2(4, 7), true);
            Queen wq = new Queen(spriteBatch, W_QueenTex, new Vector2(3, 7), true);
            Bishop wb1 = new Bishop(spriteBatch, W_BishopTex, new Vector2(2, 7), true);
            Bishop wb2 = new Bishop(spriteBatch, W_BishopTex, new Vector2(5, 7), true);
            Knight wk1 = new Knight(spriteBatch, W_KnightTex, new Vector2(1, 7), true);
            Knight wk2 = new Knight(spriteBatch, W_KnightTex, new Vector2(6, 7), true);
            Rook wr1 = new Rook(spriteBatch, W_RookTex, new Vector2(0, 7), true);
            Rook wr2 = new Rook(spriteBatch, W_RookTex, new Vector2(7, 7), true);
            Pawn wp1 = new Pawn(spriteBatch, W_PawnTex, new Vector2(0, 6), true);
            Pawn wp2 = new Pawn(spriteBatch, W_PawnTex, new Vector2(1, 6), true);
            Pawn wp3 = new Pawn(spriteBatch, W_PawnTex, new Vector2(2, 6), true);
            Pawn wp4 = new Pawn(spriteBatch, W_PawnTex, new Vector2(3, 6), true);
            Pawn wp5 = new Pawn(spriteBatch, W_PawnTex, new Vector2(4, 6), true);
            Pawn wp6 = new Pawn(spriteBatch, W_PawnTex, new Vector2(5, 6), true);
            Pawn wp7 = new Pawn(spriteBatch, W_PawnTex, new Vector2(6, 6), true);
            Pawn wp8 = new Pawn(spriteBatch, W_PawnTex, new Vector2(7, 6), true);
            GameStat.WhitePieces.Add(wk);
            GameStat.WhitePieces.Add(wq);
            GameStat.WhitePieces.Add(wb1);
            GameStat.WhitePieces.Add(wb2);
            GameStat.WhitePieces.Add(wk1);
            GameStat.WhitePieces.Add(wk2);
            GameStat.WhitePieces.Add(wr1);
            GameStat.WhitePieces.Add(wr2);
            GameStat.WhitePieces.Add(wp1);
            GameStat.WhitePieces.Add(wp2);
            GameStat.WhitePieces.Add(wp3);
            GameStat.WhitePieces.Add(wp4);
            GameStat.WhitePieces.Add(wp5);
            GameStat.WhitePieces.Add(wp6);
            GameStat.WhitePieces.Add(wp7);
            GameStat.WhitePieces.Add(wp8);
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            mouseState = Mouse.GetState();
            mousePos.X = mouseState.X;
            mousePos.Y = mouseState.Y;
            mousePosGrid = GameStat.PosToGrid(mousePos);
            mouseClick = false;
            if (mouseState.LeftButton != 0) 
                mouseClick = true;
            if (mouseClick == true && preMouseClick == false){
                GameStat.MouseClick = true;
            }else{
                GameStat.MouseClick = false;
            }
            GameStat.mouseState = mouseState;
            GameStat.MousePos = mousePos;
            GameStat.MousePosGrid = mousePosGrid;
            preMouseClick = mouseClick;

            foreach (GamePiece p in GameStat.BlackPieces)
            {
                p.Update();
            }
            foreach (GamePiece p in GameStat.WhitePieces)
            {
                p.Update();
            }

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin(SpriteSortMode.Immediate,BlendState.AlphaBlend);

            chessBoard.Draw();
            foreach(GamePiece p in GameStat.BlackPieces)
            {
                p.Draw();
            }
            foreach (GamePiece p in GameStat.WhitePieces)
            {
                p.Draw();
            }

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
