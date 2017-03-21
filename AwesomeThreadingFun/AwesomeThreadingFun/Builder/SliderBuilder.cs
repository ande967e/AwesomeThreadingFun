using AwesomeThreadingFun.Components;
using AwesomeThreadingFun.Other;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwesomeThreadingFun.Builder
{
    class SliderBuilder : IBuilder
    {
        private GameObject go;
        private Vector position;

        public SliderBuilder(Vector position)
        {
            this.position = position;
        }

        public void BuildGameobject()
        {
            go = new GameObject(1);
            go.AddComponent(new Transform(go, VectorF.Zero));
            go.AddComponent(new Renderer(go, "Building"));
            go.AddComponent(new BoxCollider(go));
            go.AddComponent(new Slider(go));
            go.Transform.Position = position;
            go.GetComponent<Slider>().LoadContent();
        }

        public GameObject GetGameobject()
        {
            return go;
        }
    }
}
