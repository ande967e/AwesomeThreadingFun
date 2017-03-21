using AwesomeThreadingFun.Components;
using AwesomeThreadingFun.Other;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwesomeThreadingFun.Components
{
    class Slider : Component, IUpdateable
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
                    (this.Gameobject.GetComponent<BoxCollider>().CollisionRectangle.Width));
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

    }
}
