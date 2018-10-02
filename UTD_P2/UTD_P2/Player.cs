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
        }


        public void Update(GameTime gameTime)
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {

        }
    }
}
