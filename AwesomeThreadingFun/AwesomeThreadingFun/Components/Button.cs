using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace AwesomeThreadingFun.Components
{
    class Button : Component, IUpdateable, IDrawable
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
                if (InputManager.GetHasMouseButtonBeenReleased(MouseButton.Left))
                    ButtonEventHandler.FireEvent(type);
                else if (InputManager.GetIsMouseButtonPressed(MouseButton.Left))
                    Renderer.Color = Microsoft.Xna.Framework.Color.DarkRed;
                else
                    Renderer.Color = Microsoft.Xna.Framework.Color.DarkBlue;
            }
            else
                Renderer.Color = Microsoft.Xna.Framework.Color.White;
        }

        public void Draw(SpriteBatch sb)
        {
            Other.Vector pos = new Other.Vector((int)this.Transform.Position.X, (int)(this.Transform.Position.Y - 10));
            sb.DrawString(Gameworld.Instance.Font, type.ToString(), pos, Color.White);
        }
    }
}
