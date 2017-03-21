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
        public int MaxLoad;

        private GameObject target;
        private GameObject dispenser;
        private GameObject curTarget;

        private int speed, unloadTime;
        private const float reach = 5;

        public Truck(GameObject go, GameObject target, GameObject dispenser, int maxLoad, int speed, int unloadTime)
            : base(go)
        {
            this.target = this.curTarget = (target == null ? Gameworld.Instance.GetGameobject(g => g.GetComponent<Shop>() != null) : target);
            this.dispenser = dispenser;
            this.MaxLoad = maxLoad;
            this.speed = speed;
            this.unloadTime = unloadTime;
        }

        public void Update(TimeSpan ts)
        {
            if ((curTarget.Transform.Position - Transform.Position).Length < reach)
            {
                if (curTarget.GetComponent<Shop>() != null)
                {
                    ShopItems.Loadingbay lb;

                    if ((lb = curTarget.GetComponent<Shop>().RequestLoadingBay()) == null)
                        return;
                    else
                    {
                        lb.Interact(this);
                        curTarget = dispenser;
                    }
                }
                else
                {
                    //Interact with dispenser

                    curTarget = target;
                }
            }
            else
                Transform.Translate((curTarget.Transform.Position - Transform.Position).Normalized * speed);
        }
    }
}
