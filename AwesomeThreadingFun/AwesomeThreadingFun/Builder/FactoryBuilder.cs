using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AwesomeThreadingFun.Components;
using AwesomeThreadingFun.Other;

namespace AwesomeThreadingFun.Builder
{
    class FactoryBuilder : IBuilder
    {
        private GameObject go;
        private VectorF position;

        public FactoryBuilder(VectorF position)
        {
            this.position = position;
        }

        public FactoryBuilder() : this(new VectorF(0, 0))
        { }

        public void BuildGameobject()
        {
            go = new GameObject();

            go.AddComponent(new Transform(go, position));
            go.AddComponent(new Renderer(go, "Building"));
            go.AddComponent(new Factory(go, 1000, 1500, 1, 1000));
            go.AddComponent(new BoxCollider(go));
        }

        public GameObject GetGameobject()
            => go;
    }
}
