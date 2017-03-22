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
    class Shop : Component, IUpdateable, IInteractable
    {
        private int Stock;
        private int Money;
        private List<Loadingbay> loadingbays;
        private List<Counter> counters;
        private object key = new object();
        private object cKey = new object();

        public Shop (GameObject go) : base (go)
        {
            loadingbays = new List<Loadingbay>();
            counters = new List<Counter>();
            ButtonEventHandler.SubscribeToEvent(ButtonHandler);

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
                Stock += loadingbays[i].GetGoods();
            }

            int goods = Stock / counters.Count;

            for(int i = 0; i < counters.Count; i++)
            {
                counters[i].GiveGoods(goods);
                Stock -= goods;
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
    }
}
