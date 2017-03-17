using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace AwesomeThreadingFun.Components
{
    class Renderer : Component, IDrawable
    {
        #region Properties
        private Texture2D sprite;
        private Rectangle sourceRectangle;
        private Color color;
        #endregion

        #region Constructors
        public Renderer(GameObject go, string texture) 
            : this(go, Other.Picture.GetImage(texture), Color.White)
        { }

        public Renderer(GameObject go, Texture2D texture) 
            : this(go, texture, Color.White)
        { }

        public Renderer(GameObject go, string texture, Color color) 
            : this(go, Other.Picture.GetImage(texture), Color.White)
        { }

        public Renderer(GameObject go, Texture2D texture, Color color)
            : base(go)
        {
            this.sprite = texture;
            this.color = color;
            this.sourceRectangle = new Rectangle(0, 0, sprite.Width, sprite.Height);
        }

        public Renderer(GameObject go, string texture, Rectangle sourceRectangle) 
            : this(go, Other.Picture.GetImage(texture), sourceRectangle, Color.White)
        { }

        public Renderer(GameObject go, Texture2D texture, Rectangle sourceRectangle) 
            : this(go, texture, sourceRectangle, Color.White)
        { }

        public Renderer(GameObject go, string texture, Rectangle sourceRectangle, Color color)
            : this(go, Other.Picture.GetImage(texture), sourceRectangle, color)
        { }

        public Renderer(GameObject go, Texture2D texture, Rectangle sourceRectangle, Color color) : base(go)
        {
            this.sprite = texture;
            this.sourceRectangle = sourceRectangle;
            this.color = color;
        }
        #endregion

        #region Methods
        public void Draw(SpriteBatch sb)
        {
            sb.Draw(sprite, new Rectangle((Point)Transform.Position, new Point((int)(sourceRectangle.Width * Gameobject.Scale), 
                (int)(sourceRectangle.Height * Gameobject.Scale))), Color.White);
        }
        #endregion
    }
}
