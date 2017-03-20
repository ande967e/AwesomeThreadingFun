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

        /// <summary>
        /// Loads in all the textures located at Content\Sprites
        /// </summary>
        /// <param name="cm">The contentManager to use for loading</param>
        public static void Initialize(ContentManager cm)
        {
            images = new Dictionary<string, Texture2D>();

            foreach (string s in Directory.GetFiles(@"Content\Sprites"))
                images.Add(s.Split('\\').Last().Split('.').First(), cm.Load<Texture2D>(s.Remove(0, 8).Split('.').First()));
        }

        /// <summary>
        /// Gets an image with the specified name
        /// </summary>
        /// <param name="name">The name of the image to get</param>
        /// <returns>The desired image</returns>
        public static Texture2D GetImage(string name)
            => images[name];

        /// <summary>
        /// Adds an image to the list
        /// </summary>
        /// <param name="tag">The tag given the picture</param>
        /// <param name="image">the image to add</param>
        public static void AddImage(string tag, Texture2D image)
            => images.Add(tag, image);

        /// <summary>
        /// Adds an image to the list
        /// </summary>
        /// <param name="tag">The tag to use</param>
        /// <param name="path">The path to find the picture at</param>
        /// <param name="toUse">The content manager to use for loading the picture</param>
        public static void AddImage(string tag, string path, ContentManager toUse)
            => images.Add(tag, toUse.Load<Texture2D>(path));

        /// <summary>
        /// Gets the key for an image in the list
        /// </summary>
        /// <param name="image">The image to find the key of</param>
        /// <returns>the key to the Image</returns>
        public static string GetKey(Texture2D image)
            => images.First((k) => k.Value == image).Key;
    }
}
