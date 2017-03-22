using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using AwesomeThreadingFun.Builder;
using AwesomeThreadingFun.ShopItems;
using Microsoft.Xna.Framework;

namespace AwesomeThreadingFun.Components
{
    class Factory : Component, IUpdateable, IInteractable, IDrawable
    {
        private int truckCargoSize; //the amount of cargo the truck carries.
        private int truckTravelSpeed; //the speed of which the truck travels.
        private int truckOnloadTime; //Time it takes to onload a truck.
        private Director director;
        private int spawnSpeed; //the time between trucks are send on it's way.                     --> Miliseconds.
        private int spawnTimer; //indicates the upcounter until next truck spawn.
        private int contractPrice;
        private List<Contract> contracts;

        //Values to construct a contract
        private int maxNumberOfTrucks;
        private int contractTime; //the amount of time the contract holds before it stops.          --> Miliseconds.

        //Sliders
        private GameObject trucksContract;
        private GameObject timeContract;

        public int ContractPrice { get { return contractPrice; } }

        public Factory(GameObject go, int spawnSpeed, int truckCargoSize, int truckTravelSpeed, int truckOnloadTime) : base(go)
        {
            this.contracts = new List<Contract>();
            this.spawnSpeed = spawnSpeed;
            this.truckCargoSize = truckCargoSize;
            this.truckTravelSpeed = truckTravelSpeed;
            this.truckOnloadTime = truckOnloadTime;
            director = new Director(new Truckbuilder(this.Gameobject, this.truckTravelSpeed, this.truckCargoSize, this.truckOnloadTime));
            this.maxNumberOfTrucks = 10;
            this.contractTime = 10000;

            //Adds slider for number of trucks
            Gameworld.Instance.Add(trucksContract = new Director(new SliderBuilder(
                new Other.Vector((int)this.Gameobject.Transform.Position.X + 40, (int)this.Gameobject.Transform.Position.Y - 25), 100, true)).BuildObject());
            //Adds slider for contract time
            Gameworld.Instance.Add(timeContract = new Director(new SliderBuilder(
                new Other.Vector((int)this.Gameobject.Transform.Position.X + 40, (int)this.Gameobject.Transform.Position.Y + 35), 100, false)).BuildObject());

            ButtonEventHandler.SubscribeToEvent(ButtonHandler);
        }

        public void Update(TimeSpan time)
        {
            //Updates the contracts price
            ContractPriceCalculator();

            //checks if new contract should be bought, and buys if so
            CheckAndBuyContract();

            //runs if there are any contracts.
            if (contracts.Count > 0)
            {
                //runs through all the contrats in the list contracts
                for(int i = 0; i < contracts.Count; i++)
                {
                    Contract c = contracts[i];
                    //adds to the contract's time it has been alive.
                    c.ContractTimer += time.Milliseconds;

                    //Spawns trucks.
                    if((c.ContractTimer - spawnSpeed*c.NumberOfTrucks) >= spawnSpeed && c.MaxNumberOfTrucks > c.NumberOfTrucks)
                    {
                        SpawnTruck(c);
                    }

                    //If the contracts time has been exceeded it will be removed.
                    if (c.ContractTimer >= c.ContractTime)
                    {
                        c.DestroyContract();
                        contracts.Remove(c);
                    }
                }
            }  
        }

        private void ContractPriceCalculator()
        {
            contractPrice = (trucksContract.GetComponent<Slider>().GetCurrentValue * timeContract.GetComponent<Slider>().GetCurrentValue)
                * truckCargoSize;
        }

        public Loadingbay Interact()
            => new Loadingbay();

        public void SpawnTruck(Contract c)
        {
            GameObject truck = director.BuildObject();
            truck.Transform.Position = this.Transform.Position;
            Gameworld.Instance.Add(truck);
            c.NumberOfTrucks++;
            c.AddTruck(truck.GetComponent<Truck>());
        }

        public void CheckAndBuyContract()
        {
            if (this.Gameobject.GetComponent<BoxCollider>().CollisionRectangle.Contains(InputManager.GetMouseBounds()))
            {
                if (InputManager.GetHasMouseButtonBeenReleased(MouseButton.Left))
                {
                    //If mouse hovers over, and button is released
                    contracts.Add(new Contract(trucksContract.GetComponent<Slider>().GetCurrentValue, timeContract.GetComponent<Slider>().GetCurrentValue * 60000));
                    Renderer.Color = Microsoft.Xna.Framework.Color.White;
                }
                else if (InputManager.GetIsMouseButtonPressed(MouseButton.Left))
                    Renderer.Color = Microsoft.Xna.Framework.Color.Blue;
                else
                    Renderer.Color = Microsoft.Xna.Framework.Color.DarkRed;
            }
            else
                Renderer.Color = Microsoft.Xna.Framework.Color.White;
        }

        public void AddContract(Contract contract)
            => contracts.Add(contract);

        private void ButtonHandler(ButtonType type, GameObject sender)
        {

        }

        public void Draw(SpriteBatch sb)
        {
            Other.Vector pos = new Other.Vector((int)(trucksContract.Transform.Position.X + trucksContract.GetComponent<BoxCollider>().CollisionRectangle.Width + 10), (int)this.Transform.Position.Y + this.Gameobject.GetComponent<BoxCollider>().CollisionRectangle.Height/2);
            sb.DrawString(Gameworld.Instance.Font, "Price: " + contractPrice.ToString(), pos, Color.White);
        }
    }
}
