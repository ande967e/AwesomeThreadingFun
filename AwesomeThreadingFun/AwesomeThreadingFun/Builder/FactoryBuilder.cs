using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AwesomeThreadingFun.Components;

namespace AwesomeThreadingFun.Builder
{
    class FactoryBuilder : IBuilder
    {
        private GameObject go;

        public FactoryBuilder()
        { }

        public void BuildGameobject()
        {
            go = new GameObject();

            go.AddComponent(new Transform(go, new Other.VectorF(
                Gameworld.Instance.GraphicsDevice.Viewport.Width, Gameworld.Instance.GraphicsDevice.Viewport.Height)));
            go.AddComponent(new Renderer(go, "Building"));
            go.AddComponent(new Factory(go, 10, 2000, 1, 1000));
            go.AddComponent(new BoxCollider(go));
        }

        public GameObject GetGameobject()
            => go;
    }
}
