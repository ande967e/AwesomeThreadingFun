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
        public Rectangle UIRect;
        private string assetName;
        public float Layer { get; set; }
        

        public string AssetName
        {
            get{return assetName;}
            set{assetName = value;}
        }

        public delegate void ElementClicked(string element);

        public UI(string assetName, float Layer)
        {
            this.AssetName = assetName;
            this.Layer = Layer;
            UITexture = Other.Picture.GetImage(assetName);
        }

        public void Update()
        {
            if(UIRect.Contains(new Point(Mouse.GetState().X, Mouse.GetState().Y)) && Mouse.GetState().LeftButton == ButtonState.Pressed)
            {
                if(assetName == "menu")
                {
                    return;
                }
                ButtonEventHandler.FireEvent(assetName == "Play" ? ButtonType.startbutton:ButtonType.exitbutton);
                
            }
            
        }

        public void Draw(SpriteBatch spritebatch)
        {
            spritebatch.Draw(UITexture, UIRect, null, Color.White, 0, Vector2.Zero, SpriteEffects.None, Layer);
        }

        public void CenterElement(int width, int height)
        {
            UIRect = new Rectangle((width / 2) - (this.UITexture.Width / 2), (height / 2) - (this.UITexture.Height / 2), this.UITexture.Width, this.UITexture.Height);
        }

        public void MoveElement(int x, int y)
        {
            UIRect = new Rectangle(UIRect.X += x, UIRect.Y += y, UIRect.Width, UIRect.Height);
        }
    }
}
