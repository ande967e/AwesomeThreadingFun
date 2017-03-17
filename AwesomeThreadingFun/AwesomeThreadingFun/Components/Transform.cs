using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AwesomeThreadingFun.Other;

namespace AwesomeThreadingFun.Components
{
    class Transform : Component
    {
        public VectorF Position { get; set; }
       
        public Transform(GameObject go, VectorF position) : base(go)
        {
            this.Position = position;
        }

        public void Translate(VectorF v)
            => this.Position += v;
    }
}
