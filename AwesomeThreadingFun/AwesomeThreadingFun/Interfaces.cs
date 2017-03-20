using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using AwesomeThreadingFun.Components;

namespace AwesomeThreadingFun
{
    interface IUpdateable
    {
        void Update(TimeSpan time);
    }

    interface IDrawable
    {
        void Draw(SpriteBatch sb);
    }

    interface IInteractable
    {
        void Interact(Truck sender);
    }

    interface IBuilder
    {
        void BuildGameobject();
        GameObject GetGameobject();
    }
}
