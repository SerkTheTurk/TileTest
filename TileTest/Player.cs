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

        public Player(Vector2 p)
        {
            position = p;
        }

        public Vector2 Position
        {
            get { return position; }
        }

        public void LoadContent(ContentManager content)
        {
            texture = content.Load<Texture2D>("player");
        }

        public void Update(GameTime gameTime)
        {
            lastks = ks;
            ks = Keyboard.GetState();
            rectangle = new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height);
        }

        public void MoveRight()
        {
            position.X += 64;
        }
        public void MoveLeft()
        {
            position.X -= 64;
        }
        public void MoveDown()
        {
            position.Y += 64;
        }
        public void MoveUp()
        {
            position.Y -= 64;
        }
        public void DoNothing()
        {
            //lel
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
