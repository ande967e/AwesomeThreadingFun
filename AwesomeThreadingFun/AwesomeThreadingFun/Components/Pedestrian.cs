using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AwesomeThreadingFun.ShopItems;

namespace AwesomeThreadingFun.Components
{
    class Pedestrian : Component, IUpdateable
    {
        private const int Reach = 5;

        private int speed;
        private GameObject target;
        private GameObject spawn;
        private GameObject curTarget;
        private bool WillBuy;

        //Willbuy variables
        private DateTime spawnTime;
        private int delayTillBuy;
        private int buyOrder;
        private bool hasBought;

        public Pedestrian(GameObject go, int speed, GameObject spawn, GameObject target) : base(go)
        {
            this.target = this.curTarget = (target == null ? 
                Gameworld.Instance.GetGameobject(g => g.GetComponent<PeopleSpawnCenter>() != null && g != spawn) : target);
            this.hasBought = this.WillBuy = false;

            this.spawn = spawn;
            this.speed = speed;
        }

        public Pedestrian(GameObject go, int speed, GameObject spawn, GameObject target, bool willBuy, int buyOrder, int miliDelayTillBuy) : base(go)
        {
            this.spawn = spawn;
            this.target = this.curTarget = (target == null ? 
                Gameworld.Instance.GetGameobject(g => g.GetComponent<PeopleSpawnCenter>() != null && g != spawn) : target);
            this.WillBuy = willBuy;
            this.speed = speed;
            this.buyOrder = buyOrder;
            this.delayTillBuy = miliDelayTillBuy;
            this.spawnTime = DateTime.Now;
        }

        public void Update(TimeSpan ts)
        {
            if ((this.Transform.Position - curTarget.Transform.Position).Length < Reach)
            {
                if (this.curTarget.GetComponent<Shop>() != null)
                {
                    Counter c;
                    if ((c = this.curTarget.GetComponent<Shop>().RequestCounter()) != null)
                    {
                        c.BuyGoods(buyOrder);

                        this.curTarget = spawn;
                        this.hasBought = true;
                    }
                }
                else if (this.curTarget == target)
                    this.curTarget = spawn;
                else
                {
                    Gameobject.Kill();
                    spawn.GetComponent<PeopleSpawnCenter>().CurrentPeople--;
                }
            }
            else
                Transform.Translate((curTarget.Transform.Position - Transform.Position).Normalized * speed);

            if (hasBought)
                this.curTarget = spawn;
            else if (WillBuy && (DateTime.Now - spawnTime).TotalMilliseconds > delayTillBuy)
            {
                GameObject[] temp = Gameworld.Instance.GetGameobjects(g => g != null && g.GetComponent<Shop>() != null);
                curTarget = temp[Gameworld.Instance.Random.Next() % temp.Length];
            }
        }
    }
}
