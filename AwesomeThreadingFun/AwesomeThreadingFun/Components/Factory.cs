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
        private int spawnSpeed;
        private int truckCargoSize;
        private int truckTravelSpeed;

        public Factory(GameObject go, int spawnSpeed, int truckCargoSize, int truckTravelSpeed) : base(go)
        {

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
    }
}
