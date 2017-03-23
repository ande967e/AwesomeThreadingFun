using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace AwesomeThreadingFun
{
    class Menu
    {
        List<UI> main = new List<UI>();

        public Menu()
        {
            /*main.Add(new UI("menu"));
            main.Add(new UI("play"));
            main.Add(new UI("exit"));*/
        }

        public void LoadContent(ContentManager content)
        {
            foreach(UI element in main)
            {
                element.LoadContent(content);
                element.CenterElement(600, 800);
                element.clickEvent += OnClick;
            }
            main.Find(x => x.AssetName == "play").MoveElement(0, -100);
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
            if(element == "play")
            {
                //Starts game
            }

            if(element == "exit")
            {
                //Exits game
            }
        }
    }
}
