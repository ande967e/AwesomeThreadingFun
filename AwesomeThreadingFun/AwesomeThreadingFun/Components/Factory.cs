using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using AwesomeThreadingFun.Builder;

namespace AwesomeThreadingFun.Components
{
    class Factory : Component, IUpdateable
    {
        private int truckCargoSize; //the amount of cargo the truck carries.
        private int truckTravelSpeed; //the speed of which the truck travels.
        private int truckOnloadTime; //Time it takes to onload a truck.
        private int contractAmount; //amount of contracts.
        private Director director;
        private int contractTime; //the amount of time the contract holds before it stops.          --> Miliseconds.
        private int contractTimer; //indicates the amount of time the contract have been active.
        private int spawnSpeed; //the time between trucks are send on it's way.                     --> Miliseconds.
        private int spawnTimer; //indicates the upcounter until next truck spawn.

        public Factory(GameObject go, int spawnSpeed, int truckCargoSize, int truckTravelSpeed, int contractTime, int truckOnloadTime) : base(go)
        {
            this.spawnSpeed = spawnSpeed;
            this.truckCargoSize = truckCargoSize;
            this.truckTravelSpeed = truckTravelSpeed;
            this.truckOnloadTime = truckOnloadTime;
            this.contractTime = contractTime;
            director = new Director(new Truckbuilder(this.Gameobject, this.truckTravelSpeed, this.truckCargoSize, this.truckOnloadTime));

        }

        public void Update(TimeSpan time)
        {
            //runs if there are any contracts.
            if (contractAmount > 0)
            {
                //removes a contract if it's time limit is reached.
                contractTimer += time.Milliseconds;
                if (contractTimer >= contractTime)
                {
                    contractAmount--;
                    contractTimer = 0;
                }

                //adds a truck if enough time has passed.
                spawnTimer += time.Milliseconds;
                if (spawnTimer > spawnSpeed)
                {
                    SpawnTruck();
                    spawnTimer = 0;
                }
            }  
        }

        public void SpawnTruck()
        {
            director.BuildObject();
        }

        public void BuyContract()
        {
            contractAmount++;
        }
    }
}
