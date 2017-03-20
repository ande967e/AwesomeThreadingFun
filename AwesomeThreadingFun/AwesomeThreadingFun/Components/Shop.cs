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

        

        public Shop (GameObject go) : base (go)
        {
            loadingbays = new List<Loadingbay>();
            loadingbays.Add(new Loadingbay());
        }
        
        public void Update(TimeSpan time)
        {
            
        }

        public Loadingbay RequestLoadingBay()
        {
            lock{ return loadingbays.Find(l => l.)}
        }

        private void UpdateStock()
        {
            if ()
            {

            }

            if ()
            {

            }
        }
    }
}
