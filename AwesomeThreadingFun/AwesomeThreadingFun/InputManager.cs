using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwesomeThreadingFun
{
    public static class InputManager
    {
        //Stores the mouse state
        private static MouseState previousMouseState;
        private static MouseState currentMouseState;

        /// <summary>
        /// Updates the states so that they contain the right data.
        /// </summary>
        /// <param name="time"></param>
        public static void Update(TimeSpan time)
        {
            previousMouseState = currentMouseState;
            currentMouseState = Mouse.GetState();
        }

        /// <summary>
        /// Returns a small rectangle at the mouse's location.
        /// </summary>
        /// <returns></returns>
        public static Rectangle GetMouseBounds()
        {
            return new Rectangle(currentMouseState.X, currentMouseState.Y, 1, 1);
        }

        /// <summary>
        /// Returns a booltrue if the given mouse button is released.
        /// </summary>
        /// <param name="btn"></param>
        /// <returns></returns>
        public static bool GetIsMouseButtonReleased(MouseButton btn)
        {
            switch(btn)
            {
                case MouseButton.Left:
                    if (currentMouseState.LeftButton == ButtonState.Released && previousMouseState.LeftButton == ButtonState.Pressed)
                        return true;
                    break;
                case MouseButton.Middle:
                    if (currentMouseState.MiddleButton == ButtonState.Released && previousMouseState.MiddleButton == ButtonState.Pressed)
                        return true;
                    break;
                case MouseButton.Right:
                    if (currentMouseState.RightButton == ButtonState.Released && previousMouseState.RightButton == ButtonState.Pressed)
                        return true;
                    break;
            }
            return false;
        }

    }
}
