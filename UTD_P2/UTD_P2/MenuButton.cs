using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace UTD_P2
{
    /// <summary>
    /// Implementation of the buttons used in the Main Menu, Pause Menu and Game Over Screen
    /// </summary>
    class MenuButton : Button
    {
        public MenuButton(string name, Texture2D texture, int buttonX, int buttonY)
        {
            this.name = name;
            this.texture = texture;
            this.buttonX = buttonX;
            this.buttonY = buttonY;
        }

        public override void Update(GameTime gameTime, MainMenu mainMenu)
        {
            base.Update(gameTime, mainMenu);
        }

        public override void Update(GameTime gameTime, Game1 game)
        {
            base.Update(gameTime, game);
        }

        protected override void OnButtonClick()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Implementation of the Main Menu buttons
        /// </summary>
        /// <param name="mainMenu"></param>
        protected override void OnButtonClickMenu(MainMenu mainMenu)
        {
            switch (name)
            {
                case "startGame":
                    mainMenu.StartGame();
                    break;
                case "quitGame":
                    mainMenu.ExitGame();
                    break;
            }
        }

        /// <summary>
        /// implementation of the Pause Menu and GameOver Buttons
        /// </summary>
        /// <param name="game"></param>
        protected override void OnButtonClickMenu(Game1 game)
        {
            switch (name)
            {
                case "resumeButtonPause":
                    game.gamePaused = false;
                    break;
                case "mainMenuButtonPause":
                    game.SetMainMenuActive(true);
                    break;
                case "quitButtonPause":
                    game.Exit();
                    break;
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }
    }
}
