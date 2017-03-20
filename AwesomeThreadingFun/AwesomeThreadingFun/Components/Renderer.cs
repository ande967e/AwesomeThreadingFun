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
        public Texture2D Sprite { get; set; }
        public Rectangle SourceRectangle { get; set; }

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
            this.Sprite = texture;
            this.color = color;
            this.SourceRectangle = new Rectangle(0, 0, Sprite.Width, Sprite.Height);
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
            this.Sprite = texture;
            this.SourceRectangle = sourceRectangle;
            this.color = color;
        }
        #endregion

        #region Methods
        public void Draw(SpriteBatch sb)
        {
            sb.Draw(Sprite, new Rectangle((Point)Transform.Position, new Point((int)(SourceRectangle.Width * Gameobject.Scale), 
                (int)(SourceRectangle.Height * Gameobject.Scale))), Color.White);
        }
        #endregion
    }
}
