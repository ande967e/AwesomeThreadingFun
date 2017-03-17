using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using System.Threading;
using AwesomeThreadingFun.Components;

namespace AwesomeThreadingFun
{
    class GameObject
    {
        private bool kill;
        private Thread UpdateThread;

        private List<Component> components;

        public GameObject()
        {
            this.kill = false;
        }

        public void Draw(SpriteBatch sb)
            => components.FindAll(c => c is IDrawable).ForEach(c => (c as IDrawable).Draw(sb));

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

        public T GetComponent<T>() where T : Component
            => components.Find(c => c is T) as T;

        public Component GetComponent(Func<Component, bool> Filter)
            => components.Find(c => Filter(c));

        public T[] GetComponents<T>() where T : Component
            => (from c in components where c is T select c as T).ToArray();

        public Component[] GetComponents(Func<Component, bool> Filter)
            => components.FindAll(c => Filter(c)).ToArray();
    }
}
