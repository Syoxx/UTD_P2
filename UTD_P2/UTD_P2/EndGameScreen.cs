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
    /// <summary>
    /// Game over screen class
    /// </summary>
    public class EndGameScreen
    {
        #region Variables

        Texture2D background;
        Texture2D mainMenuButton;
        Texture2D exitMenuButton;
        Button menuButton;
        Button exitButton;
        public bool isActive = false;
        private bool mainMenu = false;
        private bool exitGame = false;

        #endregion
        

        public EndGameScreen(Texture2D background, Texture2D mainMenuButton, Texture2D exitMenuButton)
        {
            this.background = background;
            this.mainMenuButton = mainMenuButton;
            this.exitMenuButton = exitMenuButton;
            isActive = true;
            menuButton = new MenuButton("mainMenuButtonPause", mainMenuButton, 960 - (mainMenuButton.Width / 2), 500 - (mainMenuButton.Height / 2));
            exitButton = new MenuButton("quitButtonPause", exitMenuButton, 960 - (exitMenuButton.Width / 2), 580 - (exitMenuButton.Height / 2));
        }
        
        public void Update(GameTime gameTime, Game1 game)
        {
            menuButton.Update(gameTime, game);
            exitButton.Update(gameTime, game);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(background, new Rectangle(0, 0, 1920, 1080), Color.White);
            menuButton.Draw(spriteBatch);
            exitButton.Draw(spriteBatch);
        }

    }
}
