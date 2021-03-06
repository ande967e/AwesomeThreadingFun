﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using AwesomeThreadingFun.Components;
using AwesomeThreadingFun.ShopItems;

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
        Loadingbay Interact();
    }

    interface IBuilder
    {
        void BuildGameobject();
        GameObject GetGameobject();
    }
}
