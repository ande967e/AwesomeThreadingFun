﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace AwesomeThreadingFun.ShopItems
{
    class Counter
    {
        private int goods;
        private int money;
        private object key = new object();
        public GameObject interacter;

        public Counter()
        {
            goods = 0;
        }

        public void GiveGoods(int goodsAmount)
        {
            lock(key) { goods += goodsAmount; }
        }

        public int TakeMoney()
        {
            lock (key)
            {
                int tempMoney = money;
                money = 0;
                return tempMoney;
            }
        }

        public void BuyGoods(int goodsAmount)
        {
            lock(key)
            {
                goods -= (goodsAmount > goods ? goods : goodsAmount);
                money += (goodsAmount > goods ? goods : goodsAmount) * 10;
            }
            Thread.Sleep(2000);
            interacter = null;
        }
    }
}
