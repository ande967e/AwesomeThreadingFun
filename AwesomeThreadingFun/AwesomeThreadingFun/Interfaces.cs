using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;

namespace AwesomeThreadingFun
{
    interface IUpdateable
    {
        void Update(DateTime time);
    }

    interface IDrawable
    {
        void Draw(SpriteBatch sb);
    }
}
