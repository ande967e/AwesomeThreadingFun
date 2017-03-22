using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using AwesomeThreadingFun.ShopItems;


namespace AwesomeThreadingFun.Components
{
    class Shop : Component, IUpdateable, IInteractable, IDrawable
    {
        private int stock;
        private int totalStock;
        private int money;
        public int Money { get; set; }
        private List<Loadingbay> loadingbays;
        private List<Counter> counters;
        private object key = new object();
        private object cKey = new object();

        public Shop (GameObject go) : base (go)
        {
            Money = 10000;
            loadingbays = new List<Loadingbay>();
            counters = new List<Counter>();
            ButtonEventHandler.SubscribeToEvent(ButtonHandler);
            Renderer.Layer = .1f;

            for (int i = 0; i < 5; i++)
            {
                loadingbays.Add(new Loadingbay());
                counters.Add(new Counter());
            }
        }
        
        public void Update(TimeSpan time)
        {
            for(int i = 0; i < loadingbays.Count; i++)
            {
                stock += loadingbays[i].GetGoods();
            }

            int goods = stock / counters.Count;

            for(int i = 0; i < counters.Count; i++)
            {
                counters[i].GiveGoods(goods);
                Money += counters[i].TakeMoney();
                stock -= goods;
            }

            //Updates totalStock 
            for (int i = 0; i < counters.Count; i++)
            {
                totalStock = 0;
                totalStock += counters[i].Goods;
                totalStock += stock;
            }
        }

        public Loadingbay Interact()
        {
            lock(key) {
                return loadingbays.Find(l => l.interacter == null);
            }
        }

        public Counter RequestCounter()
        {
            lock(cKey)
            {
                return counters.Find(c => c.interacter == null);
            }
        }

        private void ButtonHandler(ButtonType type)
        {
            switch(type)
            {
                case ButtonType.LoadingbayUpgrade:
                    loadingbays.Add(new Loadingbay());
                    break;
                case ButtonType.CounterUpgrade:
                    counters.Add(new Counter());
                    break;
                case ButtonType.StorageUpgrade:
                    break;
            }
        }

        public void Draw(SpriteBatch sb)
        {
            //Writes the amount of money the shop has
            Other.Vector pos = new Other.Vector((int)this.Transform.Position.X, (int)this.Transform.Position.Y - 15);
            sb.DrawString(Gameworld.Instance.Font, "Money: " + Money, pos, Color.White);

            //Writes the amount of stock the shop has
            pos = new Other.Vector((int)this.Transform.Position.X, (int)this.Transform.Position.Y - 30);
            sb.DrawString(Gameworld.Instance.Font, "Stock: " + totalStock, pos, Color.White);
        }
    }
}
