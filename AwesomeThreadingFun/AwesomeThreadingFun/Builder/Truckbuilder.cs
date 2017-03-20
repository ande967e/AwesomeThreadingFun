using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AwesomeThreadingFun.Components;
using AwesomeThreadingFun.Other;

namespace AwesomeThreadingFun.Builder
{
    class Truckbuilder : IBuilder
    {
        private GameObject target;
        private GameObject dispenser;
        private int speed;
        private int maxLoad;
        private int unloadSpeed;

        private GameObject go;

        public Truckbuilder(GameObject dispenser, int speed, int maxLoad)
            : this(Gameworld.Instance.GetGameobject(g => g.GetComponent<Shop>() != null),
                  dispenser, speed, maxLoad, maxLoad/100)
        { }

        public Truckbuilder(GameObject dispenser, int speed, int maxLoad, int unloadSpeed)
            : this(Gameworld.Instance.GetGameobject(g => g.GetComponent<Shop>() != null), 
                  dispenser, speed, maxLoad, unloadSpeed)
        { }

        public Truckbuilder(GameObject target, GameObject dispenser, int speed, int maxLoad, int unloadSpeed)
        {
            this.target = target;
            this.dispenser = dispenser;
            this.speed = speed;
            this.maxLoad = maxLoad;
            this.unloadSpeed = unloadSpeed;
        }

        public void BuildGameobject()
        {
            go = new GameObject(1);
            go.AddComponent(new Transform(go, VectorF.Zero));
            go.AddComponent(new Renderer(go, "Building"));
            //go.AddComponent(new Animator(go, 5));
            go.AddComponent(new Truck(go, target, dispenser, maxLoad, speed, unloadSpeed));
        }

        public GameObject GetGameobject()
            => go;
    }
}
