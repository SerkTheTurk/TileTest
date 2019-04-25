using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace TileTest.Desktop
{
    public class Tile
    {
        Texture2D texture;
        Vector2 position;
        Rectangle rectangle;
        char type;

        public Tile(Vector2 p, char b)
        {
            position = p;
            type = b;
        }

        public Rectangle Rect
        {
            get { return rectangle; }
        }

        public void LoadContent(ContentManager content)
        {
            switch (type)
            {
                case 'g':
                    texture = content.Load<Texture2D>("grass");
                    break;
                case 'w':
                    texture = content.Load<Texture2D>("water");
                    break;
                case 'b':
                    texture = content.Load<Texture2D>("brick");
                    break;
            }
            rectangle = new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height);
        }

        public char Type
        {
            get { return type; }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, rectangle, Color.White);
        }
    }
}
