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
    class PauseMenu
    {
        private Game1 game;
        private Vector2 posOverlay, posResumeButton, posQuitButton, posMainMenuButton;
        private Texture2D resumeButtonTexture, quitButtonTexture, mainMenuButtonTexture, overlayTexture;
        private Rectangle overlayDimensions;
        private MenuButton resumeButton, mainMenuButton, quitButton;

        public PauseMenu(Game1 game, GraphicsDevice graphicsDevice)
        {
            this.game = game;

            resumeButtonTexture = ContentConverter.Convert("Content/Assets/Menu/ContinueButton.png", graphicsDevice);
            quitButtonTexture = ContentConverter.Convert("Content/Assets/Menu/QuitButton.png", graphicsDevice);
            mainMenuButtonTexture = ContentConverter.Convert("Content/Assets/Menu/MainMenuButton.png", graphicsDevice);
            overlayTexture = ContentConverter.Convert("Content/Assets/Menu/PauseMenu.png", graphicsDevice);

            posOverlay = new Vector2(960 - overlayTexture.Width / 2, 540 - overlayTexture.Height / 2);
            overlayDimensions = new Rectangle(0, 0, overlayTexture.Width, overlayTexture.Height);

            posResumeButton = posOverlay + new Vector2(32, resumeButtonTexture.Height * 2);
            posMainMenuButton = posResumeButton + new Vector2(0, mainMenuButtonTexture.Height * 2);
            posQuitButton = posMainMenuButton + new Vector2(0, quitButtonTexture.Height * 2);

            resumeButton = new MenuButton("resumeButtonPause", resumeButtonTexture, (int)posResumeButton.X, (int)posResumeButton.Y);
            mainMenuButton = new MenuButton("mainMenuButtonPause", mainMenuButtonTexture, (int)posMainMenuButton.X, (int)posMainMenuButton.Y);
            quitButton = new MenuButton("quitButtonPause", quitButtonTexture, (int)posQuitButton.X, (int)posQuitButton.Y);
        }

        public void Update(GameTime gameTime)
        {
            resumeButton.Update(gameTime, game);
            mainMenuButton.Update(gameTime, game);
            quitButton.Update(gameTime, game);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(overlayTexture, posOverlay, overlayDimensions, Color.White);
            resumeButton.Draw(spriteBatch);
            mainMenuButton.Draw(spriteBatch);
            quitButton.Draw(spriteBatch);
        }
    }
}
