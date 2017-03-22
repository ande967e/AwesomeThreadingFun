using AwesomeThreadingFun.Components;
using AwesomeThreadingFun.Other;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;

namespace AwesomeThreadingFun.Components
{
    class Slider : Component, IUpdateable, IDrawable
    {
        private BoxCollider pointerCol;
        private GameObject pointer;
        private bool pointMove;
        private int maxValue;

        public int GetCurrentValue
        {
            get
            {
                return (int)(maxValue * (pointer.Transform.Position.X - this.Gameobject.Transform.Position.X) /
                    (this.Gameobject.GetComponent<BoxCollider>().CollisionRectangle.Width - pointer.GetComponent<BoxCollider>().CollisionRectangle.Width));
            }
        }

        public Slider(GameObject go, int maxValue) : base(go)
        {
            pointMove = false;
            this.maxValue = maxValue;
        }

        public void LoadContent()
        {
            //Changes the sliders picture
            this.Gameobject.Renderer.SourceRectangle = new Rectangle(0, 0, this.Gameobject.Renderer.Sprite.Width, 1);
            this.Gameobject.Scale *= 10;

            //Creates the pointer.
            pointer = new GameObject(1f);
            pointer.AddComponent(new Transform(pointer, VectorF.Zero));
            pointer.AddComponent(new Renderer(pointer, "Building"));
            pointer.AddComponent(new BoxCollider(pointer));
            pointerCol = pointer.GetComponent<BoxCollider>();
            Gameworld.Instance.Add(pointer);

            //Places the pointer at the right start position.
            pointer.Transform.Position = new Vector(this.Gameobject.Transform.Position);
        }

        public void Update(TimeSpan time)
        {
            //Moves the pointer
            MovePointer();
        }

        public void MovePointer()
        {
            //Checks if the pointer can be moved
            if (pointerCol.CollisionRectangle.Contains(InputManager.GetMouseBounds()) && InputManager.GetIsMouseButtonPressed(MouseButton.Left))
                pointMove = true;

            if (InputManager.GetIsMouseButtonPressed(MouseButton.Left) && pointMove)
            {
                //Moves the pointer along the slider acording to the mouse position.
                pointer.Transform.Position.X = InputManager.GetMousePosition().X;

                //Makes sure the pointer doesn't move beyound the slider, in both the right and left direction.
                if (pointer.Transform.Position.X > (this.Gameobject.Transform.Position.X + this.Gameobject.GetComponent<BoxCollider>().CollisionRectangle.Width - pointerCol.CollisionRectangle.Width))
                    pointer.Transform.Position.X = this.Gameobject.Transform.Position.X + this.Gameobject.GetComponent<BoxCollider>().CollisionRectangle.Width
                        - pointerCol.CollisionRectangle.Width;
                else if (pointer.Transform.Position.X < this.Gameobject.Transform.Position.X)
                    pointer.Transform.Position.X = this.Gameobject.Transform.Position.X;
            }
            else
                pointMove = false;
        }

        public void Draw(SpriteBatch sb)
        {
            //Writes the minimum value
            Vector pos = new Vector((int)this.Gameobject.Transform.Position.X - 10, (int)this.Gameobject.Transform.Position.Y);
            sb.DrawString(Gameworld.Instance.Font, "0", pos, Color.White);

            //Writes the maximum value
            pos = new Vector((int)(this.Gameobject.Transform.Position.X + this.Gameobject.GetComponent<BoxCollider>().CollisionRectangle.Width) + 10, (int)this.Gameobject.Transform.Position.Y);
            sb.DrawString(Gameworld.Instance.Font, maxValue.ToString(), pos, Color.White);

            //Writes the current value
            pos = new Vector((int)(pointer.Transform.Position.X), (int)pointer.Transform.Position.Y - 10);
            sb.DrawString(Gameworld.Instance.Font, GetCurrentValue.ToString(), pos, Color.White);
        }
    }
}
