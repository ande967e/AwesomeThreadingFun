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

        public SliderBuilder(GameObject go)
        {
            this.go = go;
        }

        public void BuildGameobject()
        {
            go = new GameObject(1);
            go.AddComponent(new Transform(go, VectorF.Zero));
            go.AddComponent(new Renderer(go, "Building"));
            go.AddComponent(new BoxCollider(go));
            go.AddComponent(new Slider(go));
            go.GetComponent<Slider>().LoadContent();
        }

        public GameObject GetGameobject()
        {
            return go;
        }
    }
}
