using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using System.Threading;

namespace AwesomeThreadingFun
{
    class GameObject
    {
        private bool kill;
        private Thread UpdateThread;

        public GameObject()
        {
            this.kill = false;
        }

        public void Draw(SpriteBatch sb)
        {

        }

        private void Update()
        {
            while (!this.kill)
            {

            }
        }

        public void Start()
        {
            this.kill = false;
            (UpdateThread = new Thread(Update)).Start();
        }

        public void Kill()
            => this.kill = true;
    }
}
