﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using AwesomeThreadingFun.Other;

namespace AwesomeThreadingFun
{
    class Menu
    {
        List<UI> main = new List<UI>();

        public Menu()
        {
            main.Add(new UI("menu"));
            main.Add(new UI("Play"));
            main.Add(new UI("Exit"));
        }

        public void LoadContent(ContentManager content)
        {
            foreach(UI element in main)
            {
                element.LoadContent(content);
                element.CenterElement(GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width, GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height);
                element.clickEvent += OnClick;
            }
            main.Find(x => x.AssetName == "Play").MoveElement(0, -50);
            main.Find(x => x.AssetName == "Exit").MoveElement(0, 50);
        }

        public void Update()
        {
            foreach(UI element in main)
            {
                element.Update();
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach(UI element in main)
            {
                element.Draw(spriteBatch);
            }
        }

        public void OnClick(string element)
        {
            if(element == "Play")
            {
                //Starts game
            }

            if(element == "Exit")
            {
                //Exits game
            }
        }
    }
}
