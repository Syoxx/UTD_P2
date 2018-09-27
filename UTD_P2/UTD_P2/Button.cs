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
    public class Button
    {
        int buttonX, buttonY;
        private string Name;
        private Texture2D Texture;
        MouseState mouseState;
        MouseState oldState;
        Color currentColor;

        public int ButtonX
        {
            get
            {
                return buttonX;
            }
        }

        public int ButtonY
        {
            get
            {
                return buttonY;
            }
        }

        public Button(string name, Texture2D texture, int buttonX, int buttonY)
        {
            this.Name = name;
            this.Texture = texture;
            this.buttonX = buttonX;
            this.buttonY = buttonY;
        }

        /**
         * @return true: If a player enters the button with mouse
         */
        public bool enterButton()
        {
            if (mouseState.X < buttonX + Texture.Width &&
                    mouseState.X > buttonX &&
                    mouseState.Y < buttonY + Texture.Height &&
                    mouseState.Y > buttonY)
            {
                currentColor = Color.Gray;
                return true;
            }
            currentColor = Color.White;
            return false;
        }

        public void Update(GameTime gameTime, MainMenu mainMenu)
        {
            mouseState = Mouse.GetState();
            if (enterButton() && oldState.LeftButton == ButtonState.Released && mouseState.LeftButton == ButtonState.Pressed)
            {
                switch (Name)
                {
                    case "startGame":
                        mainMenu.StartGame();
                        break;
                    case "quitGame":
                        mainMenu.ExitGame();
                        break;
                }
            }
            oldState = mouseState;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, new Rectangle((int)ButtonX, (int)ButtonY, Texture.Width, Texture.Height), currentColor);
        }
    }
}
