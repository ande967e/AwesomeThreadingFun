using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace AwesomeThreadingFun.Other
{
    struct Animation
    {
        public Rectangle[] Frames;
        public string ImageName;
        public int FramesPerSecond;

        public Animation(string ImageName, int FramesPerSecond, params Rectangle[] Frames)
        {
            this.Frames = Frames;
            this.FramesPerSecond = FramesPerSecond;
            this.ImageName = ImageName;
        }

        public Animation(string ImageName, int FramesPerSecond, int Frames, int FrameWidth, int FrameHeight, int FrameXOffset, int FrameYOffset)
        {
            var TempFrames = new List<Rectangle>();

            this.ImageName = ImageName;
            this.FramesPerSecond = FramesPerSecond;

            for (int i = 0; i < Frames; i++)
                TempFrames.Add(new Rectangle(FrameWidth * (i + FrameXOffset), FrameHeight * FrameYOffset, FrameWidth, FrameHeight));

            this.Frames = TempFrames.ToArray();
        }
    }
}
