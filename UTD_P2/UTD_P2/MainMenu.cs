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
	class MainMenu
	{
		Texture2D background;
		Texture2D playMenuButton;
		Texture2D exitMenuButton;
        public bool isActive = false;

		public MainMenu(Texture2D background, Texture2D playMenuButton, Texture2D exitMenuButton)
		{
			this.background = background;
			this.playMenuButton = playMenuButton;
			this.exitMenuButton = exitMenuButton;
            isActive = true;
		}

        public void Update(GameTime gameTime)
        {

        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(background,new Rectangle(0,0,800,480), Color.White);
        }
    }
}
