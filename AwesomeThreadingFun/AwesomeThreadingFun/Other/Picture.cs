using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace AwesomeThreadingFun.Other
{
    static class Picture
    {
        private static Dictionary<string, Texture2D> images;

        public static void Initialize(ContentManager cm)
        {
            images = new Dictionary<string, Texture2D>();

            foreach (string s in Directory.GetFiles(@"Content\Sprites"))
                images.Add(s.Split('\\').Last().Split('.').First(), cm.Load<Texture2D>(s));
        }

        public static Texture2D GetImage(string name)
            => images[name];

        public static void AddImage(string tag, Texture2D image)
            => images.Add(tag, image);
    }
}
