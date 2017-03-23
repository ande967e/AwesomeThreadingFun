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
                    Renderer.Color = Color.DarkRed;
                else
                    Renderer.Color = Color.DarkBlue;
            }
            else
                Renderer.Color = Color.White;
        }

        public void Draw(SpriteBatch sb)
        {
            Other.Vector pos = new Other.Vector((int)this.Transform.Position.X, (int)(this.Transform.Position.Y - 10));
            sb.DrawString(Gameworld.Instance.Font, PresentString(), pos, Color.White);
        }

        private string PresentString()
        {
            string s = type.ToString();
            Shop sh = Gameworld.Instance.GetGameobject(g => g.GetComponent<Shop>() != null).GetComponent<Shop>();

            switch(type)
            {
                case ButtonType.CounterUpgrade:
                    s += $" ${sh.CounterCost}";
                    break;
                case ButtonType.LoadingbayUpgrade:
                    s += $" ${sh.LoadingbayCost}";
                    break;
                case ButtonType.PopularityUpgrade:
                    s += $" ${sh.PopularityCost}";
                    break;
            }

            return s;
        }
    }
}
