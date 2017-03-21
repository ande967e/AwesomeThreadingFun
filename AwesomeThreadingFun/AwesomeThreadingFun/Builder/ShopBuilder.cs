using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AwesomeThreadingFun.Components;

namespace AwesomeThreadingFun.Builder
{
    class ShopBuilder : IBuilder
    {
        private GameObject go;

        public ShopBuilder()
        {

        }

        public void BuildGameobject()
        {
            go = new GameObject();

            go.AddComponent(new Transform(go, new Other.VectorF(0, 0)));
            go.AddComponent(new Renderer(go, "Building"));
            go.AddComponent(new Shop(go));
            go.AddComponent(new BoxCollider(go));
        }

        public GameObject GetGameobject()
            => go;
    }
}
