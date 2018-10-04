using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace UTD_P2
{
    /// <summary>
    /// Parent Class for different Buttons, with different Update Methods
    /// </summary>
    public abstract class Button
    {
        protected int buttonX, buttonY;
        protected string name;
        protected Texture2D texture;
        protected MouseState mouseState;
        protected MouseState oldState;
        protected Color currentColor = Color.White;

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

        /// <summary>
        /// Checks if the Mouse Cursor is on the Button. Changes its display Color to grey and returns true if Mouse is over the button 
        /// </summary>
        /// <returns></returns>
        public bool EnterButton()
        {
            if (mouseState.X < buttonX + texture.Width &&
                    mouseState.X > buttonX &&
                    mouseState.Y < buttonY + texture.Height &&
                    mouseState.Y > buttonY)
            {
                if (currentColor == Color.White)
                    currentColor = Color.Gray;
                return true;
            }
            else
            {
                if (currentColor != Color.Red)
                    currentColor = Color.White;
                return false;
            }
        }

        public virtual void Update(GameTime gameTime)
        {
            mouseState = Mouse.GetState();
            if (EnterButton() && oldState.LeftButton == ButtonState.Released && mouseState.LeftButton == ButtonState.Pressed)
            {
                OnButtonClick();
            }
            oldState = mouseState;
        }

        public virtual void Update(GameTime gameTime, MainMenu mainMenu)
        {
            mouseState = Mouse.GetState();
            if (EnterButton() && oldState.LeftButton == ButtonState.Released && mouseState.LeftButton == ButtonState.Pressed)
            {
                OnButtonClickMenu(mainMenu);
            }
            oldState = mouseState;
        }

        public virtual void Update(GameTime gameTime, Game1 game)
        {
            mouseState = Mouse.GetState();
            if (EnterButton() && oldState.LeftButton == ButtonState.Released && mouseState.LeftButton == ButtonState.Pressed)
            {
                OnButtonClickMenu(game);
            }
            oldState = mouseState;
        }

        protected abstract void OnButtonClick();

        protected abstract void OnButtonClickMenu(MainMenu mainMenu);

        protected abstract void OnButtonClickMenu(Game1 game);

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, new Rectangle((int)ButtonX, (int)ButtonY, texture.Width, texture.Height), currentColor);
        }
    }
}
