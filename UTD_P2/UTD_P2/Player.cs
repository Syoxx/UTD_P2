using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace UTD_P2
{
    public class Player
    {
        public int money;
        public int life;
        public Vector2 position, drawPosition;
        Texture2D texture;

        public int Money
        {
            get { return money; }
            set { money = value; }
        }
        
        public int Lives
        {
            get { return life; }
            set { life = value; }
        }

        public Player(GraphicsDevice graphicsDevice)
        {
			money = 15;
			life = 30;
            position = new Vector2(150, 150);
            texture = ContentConverter.Convert("Content/Assets/TD/UI/number9.png", graphicsDevice);
        }


        public void Update(GameTime gameTime)
        {
            Console.WriteLine(life);
            drawPosition = position - new Vector2(texture.Width / 2, texture.Height / 2);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, drawPosition, new Rectangle(0, 0, texture.Width, texture.Height), Color.White);
        }
    }
}
