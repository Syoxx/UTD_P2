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
    public abstract class Button
    {
        protected int buttonX, buttonY;
        protected string name;
        protected Texture2D texture;
        protected MouseState mouseState;
        protected MouseState oldState;
        protected Color currentColor;

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

        /**
         * @return true: If a player enters the button with mouse
         */
        public bool enterButton()
        {
            if (mouseState.X < buttonX + texture.Width &&
                    mouseState.X > buttonX &&
                    mouseState.Y < buttonY + texture.Height &&
                    mouseState.Y > buttonY)
            {
                currentColor = Color.Gray;
                return true;
            }
            currentColor = Color.White;
            return false;
        }

        public virtual void Update(GameTime gameTime)
        {
            mouseState = Mouse.GetState();
            if (enterButton() && oldState.LeftButton == ButtonState.Released && mouseState.LeftButton == ButtonState.Pressed)
            {
                OnButtonClick();
            }
            oldState = mouseState;
        }

        public virtual void Update(GameTime gameTime, MainMenu mainMenu)
        {
            mouseState = Mouse.GetState();
            if (enterButton() && oldState.LeftButton == ButtonState.Released && mouseState.LeftButton == ButtonState.Pressed)
            {
                OnButtonClickMenu(mainMenu);
            }
            oldState = mouseState;
        }

        protected abstract void OnButtonClick();

        protected abstract void OnButtonClickMenu(MainMenu mainMenu);

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, new Rectangle((int)ButtonX, (int)ButtonY, texture.Width, texture.Height), currentColor);
        }
    }
}
