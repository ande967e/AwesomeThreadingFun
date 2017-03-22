using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AwesomeThreadingFun.Other;
using AwesomeThreadingFun.Components;

namespace AwesomeThreadingFun.Builder
{
    class PeopleSpawnBuilder : IBuilder
    {
        private GameObject go;

        private VectorF position;
        private int maxPeople, peopleSpawnDelay;

        public PeopleSpawnBuilder(int maxPeople, int peopleSpawnDelay, VectorF position)
        {
            this.position = position;
            this.maxPeople = maxPeople;
            this.peopleSpawnDelay = peopleSpawnDelay;
            //LeCommen
        }

        public void BuildGameobject()
        {
            go = new GameObject();
            go.AddComponent(new Transform(go, position));
            go.AddComponent(new PeopleSpawnCenter(go, peopleSpawnDelay, maxPeople));
        }

        public GameObject GetGameobject()
            => go;
    }
}
