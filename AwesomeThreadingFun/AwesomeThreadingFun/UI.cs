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
    class UI
    {
        private Texture2D UITexture;
        private Rectangle UIRect;
        private string assetName;

        public delegate void ElementClicked(string element);
        public event ElementClicked clickEvent;

        public UI(string assetName)
        {
            this.assetName = assetName;
        }

        public void LoadContent(ContentManager content)
        {
            UITexture = content.Load<Texture2D>(assetName);
            UIRect = new Rectangle(0, 0, UITexture.Width, UITexture.Height);
        }

        public void Update()
        {
            if(UIRect.Contains(new Point(Mouse.GetState().X, Mouse.GetState().Y)) && Mouse.GetState().LeftButton == ButtonState.Pressed)
            {
                clickEvent(assetName);
            }
        }

        public void Draw(SpriteBatch spritebatch)
        {
            spritebatch.Draw(UITexture, UIRect, Color.White);
        }

        public void CenterElement(int height, int width)
        {
            UIRect = new Rectangle((width / 2) - (this.UITexture.Width / 2), (height / 2) - (this.UITexture.Height / 2), this.UITexture.Width, this.UITexture.Height);
        }
    }
}
