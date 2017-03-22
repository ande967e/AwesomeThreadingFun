using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwesomeThreadingFun.Components
{
    class PeopleSpawnCenter : Component, IUpdateable
    {
        private int _curPeople;
        public int CurrentPeople
        {
            get { lock (key) { return _curPeople;  } }
            set { lock (key) { _curPeople = value; } }
        }

        int miliDelay;
        int maxPeople;

        private DateTime lastSpawn;
        private object key = new object();
        private Builder.Director PedDirector;

        public PeopleSpawnCenter(GameObject go, int delay, int maxPeople) : base(go)
        {
            this.miliDelay = delay;
            this.maxPeople = maxPeople;
            this._curPeople = 0;
            this.lastSpawn = DateTime.Now;
            this.PedDirector = new Builder.Director(new Builder.PedestrianBuilder(Gameworld.Instance.GetGameobject(g => 
                g.GetComponent<PeopleSpawnCenter>() != null && g != Gameobject), Gameobject, 1, 40, 10000, 100));
        }

        public void Update(TimeSpan ts)
        {
            if (CurrentPeople < maxPeople && (DateTime.Now - lastSpawn).TotalMilliseconds > miliDelay)
            {
                GameObject go;
                Gameworld.Instance.Add(go = PedDirector.BuildObject());
                go.Transform.Position = this.Transform.Position;
                go.Renderer.Color = Microsoft.Xna.Framework.Color.DarkRed;
                CurrentPeople++;
                this.lastSpawn = DateTime.Now;
            }
        }
    }
}
