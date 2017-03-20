using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AwesomeThreadingFun.Components;

namespace AwesomeThreadingFun.ShopItems
{
    class Loadingbay : IInteractable
    {
        public GameObject interacter;
        private object key = new object();
        private int goods;

        public Loadingbay()
        { goods = 0; }

        public void Interact(Truck t)
        {
            interacter = t.Gameobject;
            for (int i = 0; i < t.MaxLoad; i++)
            {
                lock (key) { goods++; }
                Thread.Sleep(1);
            }
            interacter = null;
        }

        public int GetGoods()
        {
            int temp = goods;
            lock (key) { goods = 0; }
            return temp;
        }
    }
}
