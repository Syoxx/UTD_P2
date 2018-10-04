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


        public Player(GraphicsDevice graphicsDevice)
        {
			money = 30;
			life = 0;
        }


        public void Update(GameTime gameTime)
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {

        }
    }
}
