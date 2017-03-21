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
        private int cargoSize;
        private int truckSpeed;

        public FactoryBuilder() : this(new VectorF(0, 0), 1500, 1)
        { }

        public FactoryBuilder(VectorF position) : this(position, 1500, 1)
        { }

        public FactoryBuilder(VectorF position, int cargoSize, int truckSpeed)
        {
            this.position = position;
            this.cargoSize = cargoSize;
            this.truckSpeed = truckSpeed;
        }

        public void BuildGameobject()
        {
            go = new GameObject();

            go.AddComponent(new Transform(go, position));
            go.AddComponent(new Renderer(go, "Building"));
            go.AddComponent(new Factory(go, 1000, cargoSize, truckSpeed, 1000));
            go.AddComponent(new BoxCollider(go));
        }

        public GameObject GetGameobject()
            => go;
    }
}
