using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwesomeThreadingFun.Components
{
    class Button : Component, IUpdateable
    {
        private ButtonType type;
        private BoxCollider col;

        public Button(GameObject go, ButtonType type) : base(go)
        {
            this.type = type;
            this.col = Gameobject.GetComponent<BoxCollider>();
        }

        public void Update(TimeSpan ts)
        {
            if (col.CollisionRectangle.Contains(InputManager.GetMouseBounds()))
            {
                if (InputManager.GetIsMouseButtonReleased(MouseButton.Left))
                    ButtonEventHandler.FireEvent(type);
                else if (InputManager.GetIsMouseButtonPressed(MouseButton.Left))
                    Renderer.Color = Microsoft.Xna.Framework.Color.DarkRed;
                else
                    Renderer.Color = Microsoft.Xna.Framework.Color.DarkBlue;
            }
            else
                Renderer.Color = Microsoft.Xna.Framework.Color.White;
        }
    }
}
