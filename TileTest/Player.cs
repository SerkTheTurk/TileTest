using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace TileTest.Desktop
{
    public class Player
    {
        Texture2D texture;
        Vector2 position;
        Rectangle rectangle;
        KeyboardState ks, lastks;
        float speed;

        public Player(Vector2 p)
        {
            position = p;
            speed = 3f;
        }

        public Rectangle Rect
        {
            get { return rectangle; }
        }

        bool stopMove;
        public bool StopMovement
        {
            set { stopMove = value; }
        }

        public void LoadContent(ContentManager content)
        {
            texture = content.Load<Texture2D>("player");
        }

        public void Update(GameTime gameTime)
        {
            ks = Keyboard.GetState();
            rectangle = new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height);

            if (ks.IsKeyDown(Keys.Right))
            {
                if (position.X + texture.Width >= Game1.WIDTH || stopMove == true)
                    position.X += 0;
                else
                    position.X += speed;
            }
            if (ks.IsKeyDown(Keys.Left))
            {
                if (position.X <= 0 || stopMove == true)
                    position.X += 0;
                else
                    position.X -= speed;
            }
            if (ks.IsKeyDown(Keys.Up))
            {
                if (position.Y <= 0 || stopMove == true)
                    position.Y += 0;
                else
                    position.Y -= speed;
            }
            if (ks.IsKeyDown(Keys.Down))
            {
                if (position.Y + texture.Height >= Game1.HEIGHT || stopMove == true)
                    position.Y += 0;
                else
                    position.Y += speed;
            }

        }

        public bool KeyPressed(Keys key)
        {
            return ks.IsKeyDown(key) && lastks.IsKeyUp(key);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, rectangle, Color.White);
        }
    }
}
