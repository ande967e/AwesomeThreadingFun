using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwesomeThreadingFun.Components
{
    class Component
    {
        public GameObject Gameobject;
        public Transform Transform { get { return Gameobject.GetComponent<Transform>(); } }
        public Renderer Renderer { get { return Gameobject.GetComponent<Renderer>(); } }

        public Component(GameObject go)
        {
            this.Gameobject = go;
        }
    }
}
