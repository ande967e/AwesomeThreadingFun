using AwesomeThreadingFun.Components;
using AwesomeThreadingFun.Other;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwesomeThreadingFun
{
    class Slider : Component, IUpdateable
    {
        private int procent;
        private BoxCollider pointerCol;
        private GameObject pointer;

        public Slider(GameObject go) : base(go)
        {

        }


        public void LoadContent()
        {
            //Creates the pointer.
            pointer = new GameObject(1f);
            pointer.AddComponent(new Transform(pointer, VectorF.Zero));
            pointer.AddComponent(new Renderer(pointer, "Building"));
            pointerCol = pointer.GetComponent<BoxCollider>();
            pointer.AddComponent(pointerCol);

            //Places the pointer at the right start position.
            pointer.Transform.Position = this.Gameobject.Transform.Position;
        }

        public void Update(TimeSpan time)
        {
            //this.Gameobject.Transform.Position
        }

    }
}
