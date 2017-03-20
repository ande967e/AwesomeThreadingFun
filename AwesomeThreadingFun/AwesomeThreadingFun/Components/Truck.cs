using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwesomeThreadingFun.Components
{
    class Truck : Component, IUpdateable
    {
        private GameObject target;
        private GameObject dispenser;
        private GameObject curTarget;

        private int maxLoad, speed, unloadTime;
        private const float reach = 5;

        public Truck(GameObject go, GameObject target, GameObject dispenser, int maxLoad, int speed, int unloadTime)
            : base(go)
        {
            this.target = this.curTarget = target;
            this.dispenser = dispenser;
            this.maxLoad = maxLoad;
            this.speed = speed;
            this.unloadTime = unloadTime;
        }

        public void Update(TimeSpan ts)
        {
            Transform.Translate((target.Transform.Position - Transform.Position).Normalized * speed);

            if ((curTarget.Transform.Position - Transform.Position).Length < 5)
            {
                curTarget.Interact(this);
                Thread.Sleep(100 * unloadTime);
                curTarget = curTarget == target ? dispenser : target;
            }
        }
    }
}
