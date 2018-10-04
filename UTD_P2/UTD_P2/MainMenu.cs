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
    /// Main Menu Class
    /// </summary>
	public class MainMenu
	{
		Texture2D background;
		Texture2D playMenuButton;
		Texture2D exitMenuButton;
        Button playButton;
        Button exitButton;
        public bool isActive = false;
        private bool startGame = false;
        private bool exitGame = false;

        public MainMenu(Texture2D background, Texture2D playMenuButton, Texture2D exitMenuButton)
		{
			this.background = background;
			this.playMenuButton = playMenuButton;
			this.exitMenuButton = exitMenuButton;
            isActive = true;
            playButton = new MenuButton("startGame", playMenuButton, 960 - (playMenuButton.Width / 2), 500 - (playMenuButton.Height / 2));
            exitButton = new MenuButton("quitGame", exitMenuButton, 960 - (exitMenuButton.Width / 2), 580 - (exitMenuButton.Height / 2));
		}

        public void StartGame()
        {
            startGame = true;
        }

        public void ExitGame()
        {
            exitGame = true;
        }

        /// <summary>
        /// starts the game after Start button is presse and quits after quit button ist pressed
        /// </summary>
        /// <param name="gameTime"></param>
        /// <param name="game"></param>
        public void Update(GameTime gameTime, Game1 game)
        {
            if (startGame)
            {
                game.LoadLevel(1);
                isActive = false;
                startGame = false;
            }

            if (exitGame)
                game.Quit();

            playButton.Update(gameTime, this);
            exitButton.Update(gameTime, this);
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(background,new Rectangle(0,0,1920,1080), Color.White);
            playButton.Draw(spriteBatch);
            exitButton.Draw(spriteBatch);
        }
    }
}
