using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;

namespace AwesomeThreadingFun.Components
{
    class Factory : Component, IUpdateable, IDrawable
    {
        private int spawnSpeed; //the time between trucks are send on it's way.
        private int truckCargoSize; //the amount of cargo the truck carries.
        private int truckTravelSpeed; //the speed of which the truck travels.
        private int truckOnloadTime; //Time it takes to onload a truck.
        private int contractTime; //the amount of time the contract holds before it stops.
        private int contractAmount; //amount of contracts.

        public Factory(GameObject go, int spawnSpeed, int truckCargoSize, int truckTravelSpeed, int contractTime, int truckOnloadTime) : base(go)
        {
            this.spawnSpeed = spawnSpeed;
            this.truckCargoSize = truckCargoSize;
            this.truckTravelSpeed = truckTravelSpeed;
            this.truckOnloadTime = truckOnloadTime;
            this.contractTime = contractTime;
        }

        public void Draw(SpriteBatch sb)
        {

        }

        public void Update(TimeSpan time)
        {

        }

        public void SpawnTruck()
        {

        }

        public void BuyContract()
        {
            
        }
    }
}
