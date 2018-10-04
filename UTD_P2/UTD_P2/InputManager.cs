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
    public static class InputManager
    {
        /// <summary>
        /// Input Manager for Keyboard, if only a single press is needed
        /// </summary>
        /// <param name="previousState"></param>
        /// <param name="currentState"></param>
        /// <param name="keys"></param>
        /// <returns></returns>
        public static bool CheckInputKeyboard(KeyboardState previousState, KeyboardState currentState, Keys keys)
        {
            if (!previousState.IsKeyDown(keys) && currentState.IsKeyDown(keys))
                return true;
            else
                return false;
        }

        /// <summary>
        /// Input Manager for Mouse, if only a single press is needed
        /// </summary>
        /// <param name="previousState"></param>
        /// <param name="currentState"></param>
        /// <param name="mouseButton"></param>
        /// <returns></returns>
        public static bool CheckInputMouse(MouseState previousState, MouseState currentState, string mouseButton)
        {
            switch (mouseButton)
            {
                case "left":
                    if (previousState.LeftButton == ButtonState.Released && currentState.LeftButton == ButtonState.Pressed)
                        return true;
                    else
                        return false;
                case "right":
                    if (previousState.RightButton == ButtonState.Released && currentState.LeftButton == ButtonState.Pressed)
                        return true;
                    else
                        return false;
                case "middle":
                    if (previousState.MiddleButton == ButtonState.Released && currentState.MiddleButton == ButtonState.Pressed)
                        return true;
                    else
                        return false;
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
