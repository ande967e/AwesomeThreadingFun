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
        new List<Loadingbay> loadingbays;
        private object key = new object();

        public Shop (GameObject go) : base (go)
        {
            loadingbays = new List<Loadingbay>();
            ButtonEventHandler.SubscribeToEvent(ButtonHandler);

            for (int i = 0; i < 5; i++)
                loadingbays.Add(new Loadingbay());
        }
        
        public void Update(TimeSpan time)
        {
            for(int i = 0; i < loadingbays.Count; i++)
            {
                Stock += loadingbays[i].GetGoods();
            }
        }

        public Loadingbay Interact()
        {
            lock(key) {
                return loadingbays.Find(l => l.interacter == null);
            }
        }

        private void ButtonHandler(ButtonType type)
        {
            switch(type)
            {
                case ButtonType.LoadingbayUpgrade:
                    loadingbays.Add(new Loadingbay());
                    break;
            }
        }
    }
}
