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

            resumeButtonTexture = ContentConverter.Convert("Content/Assets/MenuButtons/MenuResume.png", graphicsDevice);
            quitButtonTexture = ContentConverter.Convert("Content/Assets/MenuButtons/MenuQuit.png", graphicsDevice);
            mainMenuButtonTexture = ContentConverter.Convert("Content/Assets/MenuButtons/MainMenu.png", graphicsDevice);
            overlayTexture = ContentConverter.Convert("Content/Assets/MenuButtons/Overlay.png", graphicsDevice);

            posMainMenuButton = new Vector2(1920 / 2 - mainMenuButtonTexture.Width / 2, 1080 / 2 - mainMenuButtonTexture.Height / 2);
            posResumeButton = posMainMenuButton - new Vector2(0, resumeButtonTexture.Height * 1.5f);
            posQuitButton = posMainMenuButton + new Vector2(0, quitButtonTexture.Height * 1.5f);

            posOverlay = posResumeButton - new Vector2(resumeButtonTexture.Width / 2, resumeButtonTexture.Height);
            overlayDimensions = new Rectangle(0, 0, resumeButtonTexture.Width * 2, (int)(posQuitButton.Y - posResumeButton.Y) + resumeButtonTexture.Height * 2);

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
