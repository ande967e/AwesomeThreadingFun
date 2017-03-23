using System;
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
        public bool MenuVisible = true;

        public Menu()
        {
            main.Add(new UI("menu", 0.2f));
            main.Add(new UI("Play", 0));
            main.Add(new UI("Exit", 0));
        }

        public void LoadContent(ContentManager content)
        {
            foreach(UI element in main)
            {
                element.CenterElement(Gameworld.Instance.GraphicsDevice.Viewport.Width, Gameworld.Instance.GraphicsDevice.Viewport.Height);
                ButtonEventHandler.SubscribeToEvent(OnClick);
            }
            main.Find(x => x.AssetName == "Play").MoveElement(0, 50);
            main.Find(x => x.AssetName == "Exit").MoveElement(0, 100);
        }

        public void Update()
        {
            if(MenuVisible == true)
            {
                foreach (UI element in main)
                {
                    element.Update();
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (MenuVisible == true)
            {
                foreach (UI element in main)
                {
                    element.Draw(spriteBatch);
                }
            }
        }

        public void OnClick(ButtonType element)
        {
            if(element == ButtonType.startbutton)
            {
                MenuVisible = false;
            }

            if(element == ButtonType.exitbutton)
            {
                Gameworld.Instance.Exit();
            }
        }
    }
}
