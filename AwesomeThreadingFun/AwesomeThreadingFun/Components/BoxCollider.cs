using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace AwesomeThreadingFun.Components
{
    class BoxCollider : Component
    {
        public Rectangle CollisionRectangle { get
            {
                return new Rectangle(0, 0, (int)(Renderer.SourceRectangle.Width * Gameobject.Scale), 
                    (int)(Renderer.SourceRectangle.Height * Gameobject.Scale));
            } }

        public BoxCollider(GameObject go) : base(go)
        { }
    }
}
