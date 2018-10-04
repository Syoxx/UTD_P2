using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace UTD_P2
{
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
