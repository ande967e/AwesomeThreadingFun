using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using AwesomeThreadingFun.Components;

namespace AwesomeThreadingFun
{
    class GameObject
    {
        public float Scale;

        public Transform Transform { get; private set; }
        public Renderer Renderer { get; private set; }

        private bool kill;
        private bool started;
        private Thread UpdateThread;

        private List<Component> components;

        public GameObject()
        {
            components = new List<Component>();
            this.kill = false;
            this.started = false;
            Scale = 1;
        }

        public GameObject(float scale)
        {
            this.kill = false;
            this.Scale = scale;
        }

        /// <summary>
        /// Draws the gameobject to the screen
        /// </summary>
        /// <param name="sb">The spritebatch to draw with</param>
        public void Draw(SpriteBatch sb)
            => components.FindAll(c => c is IDrawable).ForEach(c => (c as IDrawable).Draw(sb));

        /// <summary>
        /// !!!WARNING!!! Thread loop, don't call with a thread not supposed to loop!
        /// The main update function for this gameobject
        /// </summary>
        private void Update()
        {
            while (!kill)
                components.FindAll(c => c is IUpdateable).ForEach(c => (c as IUpdateable).Update(Gameworld.Instance.MaxElapsedTime));

            Gameworld.Instance.Remove(this);
        }

        public void Interact(Truck sender)
           => components.FindAll(c => c is IInteractable).ForEach(c => (c as IInteractable).Interact(sender));

        /// <summary>
        /// Starts the thread associated with the gameobject
        /// </summary>
        public void Start()
        {
            if (!this.started)
            {
                this.kill = false;
                (UpdateThread = new Thread(Update)).Start();
            }
        }

        /// <summary>
        /// Tells the gameobject to please kill itself
        /// </summary>
        public void Kill()
        {
            this.started = false;
            this.kill = true;
        }

        /// <summary>
        /// Adds a component to the list of components,
        /// </summary>
        /// <param name="comp">The component to add</param>
        public void AddComponent(Component comp)
        {
            components.Add(comp);

            if (comp is Transform)
                Transform = comp as Transform;
            else if (comp is Renderer)
                Renderer = comp as Renderer;
        }

        /// <summary>
        /// Gets the first occuring component.
        /// </summary>
        /// <typeparam name="T">The type of the Component to find</typeparam>
        /// <returns>The component of specified type</returns>
        public T GetComponent<T>() where T : Component
            => components.Find(c => c is T) as T;

        /// <summary>
        /// Gets then first occuring component
        /// </summary>
        /// <param name="Filter">The filter to filter all the fluff out</param>
        /// <returns>A component matching the criterias in the Filter</returns>
        public Component GetComponent(Func<Component, bool> Filter)
            => components.Find(c => Filter(c));

        /// <summary>
        /// Gets all occuring components matching T
        /// </summary>
        /// <typeparam name="T">The type of component to get</typeparam>
        /// <returns>all Components matching T</returns>
        public T[] GetComponents<T>() where T : Component
            => (from c in components where c is T select c as T).ToArray();

        /// <summary>
        /// Gets all occuring components matching Filter
        /// </summary>
        /// <param name="Filter">The filter to filter with</param>
        /// <returns>all components matching the Filter</returns>
        public Component[] GetComponents(Func<Component, bool> Filter)
            => components.FindAll(c => Filter(c)).ToArray();
    }
}
