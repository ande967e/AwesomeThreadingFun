using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AwesomeThreadingFun.Other;
using AwesomeThreadingFun.Components;

namespace AwesomeThreadingFun.Builder
{
    class ShopBuilder : IBuilder
    {
        private GameObject go;
        VectorF position;

        public ShopBuilder() : this(VectorF.Zero)
        { }

        public ShopBuilder(VectorF position)
        {
            this.position = position;
        }

        public void BuildGameobject()
        {
            go = new GameObject();

            go.AddComponent(new Transform(go, position));
            go.AddComponent(new Renderer(go, "Building"));
            go.AddComponent(new Shop(go));
            go.AddComponent(new BoxCollider(go));
        }

        public GameObject GetGameobject()
            => go;
    }
}
