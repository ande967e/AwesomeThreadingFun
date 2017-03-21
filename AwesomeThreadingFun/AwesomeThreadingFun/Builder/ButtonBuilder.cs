using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AwesomeThreadingFun.Components;
using AwesomeThreadingFun.Other;

namespace AwesomeThreadingFun.Builder
{
    class ButtonBuilder : IBuilder
    {
        private GameObject go;
        private ButtonType type;
        private VectorF position;

        public ButtonBuilder() : this(ButtonType.LoadingbayUpgrade, new VectorF(0,0))
        { }

        public ButtonBuilder(ButtonType type) : this(type, new VectorF(0,0))
        { }

        public ButtonBuilder(VectorF position) : this(ButtonType.LoadingbayUpgrade, position)
        { }

        public ButtonBuilder(ButtonType type, VectorF position)
        {
            this.type = type;
            this.position = position;
        }

        public void BuildGameobject()
        {
            this.go = new GameObject();

            go.AddComponent(new Transform(go, position));
            go.AddComponent(new Renderer(go, "Building"));
            go.AddComponent(new BoxCollider(go));
            go.AddComponent(new Button(go, type));
        }

        public GameObject GetGameobject()
            => go;
    }
}
