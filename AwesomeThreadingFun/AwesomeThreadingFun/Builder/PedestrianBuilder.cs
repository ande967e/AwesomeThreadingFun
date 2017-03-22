using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AwesomeThreadingFun.Components;
using AwesomeThreadingFun.Other;

namespace AwesomeThreadingFun.Builder
{
    class PedestrianBuilder : IBuilder
    {
        private GameObject go, target, spawn;
        private int willBuyChance, speed, delay, maxBuyOrder;

        public PedestrianBuilder(GameObject target, GameObject spawn, int speed, int willBuyChance, int delay, int maxBuyOrder)
        {
            this.target = target;
            this.spawn = spawn;
            this.willBuyChance = willBuyChance;
            this.speed = speed;
            this.delay = delay;
            this.maxBuyOrder = maxBuyOrder;
        }

        public void BuildGameobject()
        {
            go = new GameObject();
            go.AddComponent(new Transform(go, new VectorF(0, 0)));
            go.AddComponent(new Renderer(go, "Person"));
            go.AddComponent(new Pedestrian(go, speed, spawn, target, Gameworld.Instance.Random.Next() % 100 < willBuyChance
                , Gameworld.Instance.Random.Next() % maxBuyOrder, Gameworld.Instance.Random.Next() % delay));
        }

        public GameObject GetGameobject()
            => go;
    }
}
