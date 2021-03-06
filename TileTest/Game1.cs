﻿using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace TileTest.Desktop
{
    public class Game1 : Game
    {
        float frameRate;
        SpriteFont sf;
        public const int WIDTH = 896;
        public const int HEIGHT = 640;
        int blockX;
        int blockY;
        int tileSize;

        Player player;

        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Tile[,] tiles;

        string[] line;
        char[,] mapT;


        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsFixedTimeStep = true;
            TargetElapsedTime = TimeSpan.FromSeconds(1d / 60d);
            graphics.PreferredBackBufferWidth = WIDTH;
            graphics.PreferredBackBufferHeight = HEIGHT;
            graphics.ApplyChanges();
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            tileSize = 64;
            blockX = 14;
            blockY = 10;
            tiles = new Tile[blockX, blockY];
            mapT = new char[blockY, blockX];
            using (StreamReader reader = new StreamReader("map1.csv"))
            {
                while (!reader.EndOfStream)
                {
                    for (int i = 0; i < blockY; i++)
                    {
                        line = reader.ReadLine().Split(',');
                        for (int j = 0; j < blockX; j++)
                        {
                            mapT[i, j] = Convert.ToChar(line[j]);
                        }
                    }
                }
            }
            for (int y = 0; y < blockY; y++)
            {
                for (int x = 0; x < blockX; x++)
                { 
                    tiles[x, y] = new Tile(new Vector2(x * tileSize, y * tileSize), mapT[y,x]);
                }
            }

            player = new Player(Vector2.Zero);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            sf = Content.Load<SpriteFont>("FPS");
            player.LoadContent(Content);

            foreach (Tile tile in tiles)
            {
                tile.LoadContent(Content);
            }
        }

        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            frameRate = (int)(1 / (float)gameTime.ElapsedGameTime.TotalSeconds);

            player.Update(gameTime);
            foreach (Tile tile in tiles)
            {
                if (player.Rect.Intersects(tile.Rect))
                {
                    if (tile.Type == 'w')
                    {
                        player.StopMovement = true;
                    }
                    else player.StopMovement = false;
                }
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();

            foreach (Tile tile in tiles)
                tile.Draw(spriteBatch);
            player.Draw(spriteBatch);
            spriteBatch.DrawString(sf, frameRate.ToString(), new Vector2(WIDTH - 30, 0), Color.White);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
