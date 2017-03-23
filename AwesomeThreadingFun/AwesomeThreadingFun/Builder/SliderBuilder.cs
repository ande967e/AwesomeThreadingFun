﻿using AwesomeThreadingFun.Components;
using AwesomeThreadingFun.Other;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AwesomeThreadingFun.Components;

namespace AwesomeThreadingFun.Builder
{
    class SliderBuilder : IBuilder
    {
        private GameObject go;
        private Vector position;
        private int maxValue;
        private bool type;

        public SliderBuilder(Vector position, int maxValue)
        {
            this.position = position;
            this.maxValue = maxValue;
        }

        public SliderBuilder(Vector position, int maxValue, bool type)
        {
            this.position = position;
            this.maxValue = maxValue;
            this.type = type;
        }

        public void BuildGameobject()
        {
            go = new GameObject(1);
            go.AddComponent(new Transform(go, position));
            go.AddComponent(new Renderer(go, "Building", Color.Gray));
            go.AddComponent(new BoxCollider(go));
            go.AddComponent(new Slider(go, maxValue, type));
            go.GetComponent<Slider>().LoadContent();
        }

        public GameObject GetGameobject()
        {
            return go;
        }
    }
}
