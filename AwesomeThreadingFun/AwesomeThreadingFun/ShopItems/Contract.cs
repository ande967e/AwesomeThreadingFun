using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwesomeThreadingFun.ShopItems
{
    class Contract
    {
        private int maxNumberOfTrucks;
        private int numberOfTrucks;
        private int contractTime; //the amount of time the contract holds before it stops.          --> Miliseconds.
        private int contractTimer; //indicates the amount of time the contract have been active.

        public int ContractTimer { get { return contractTimer; } set { contractTimer = value; } }
        public int NumberOfTrucks { get { return numberOfTrucks; } set { numberOfTrucks = value; } }
        public int MaxNumberOfTrucks { get { return maxNumberOfTrucks; } }
        public int ContractTime { get { return contractTime; } }

        public List<Components.Truck> Trucks;

        public Contract(int maxNumberOfTrucks, int contractTime)
        {
            Trucks = new List<Components.Truck>();
            this.contractTime = contractTime;
            this.maxNumberOfTrucks = maxNumberOfTrucks;
        }

        public void AddTruck(Components.Truck truck)
            => Trucks.Add(truck);

        public void DestroyContract()
        {
            foreach (Components.Truck truck in Trucks)
                truck.Gameobject.Kill();
        }
    }
}
