using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace AwesomeThreadingFun.Components
{
    class Animator : Component, IUpdateable
    {
        private Dictionary<string, Other.Animation> animations;
        private DateTime lastSwap;
        private Rectangle[] currentAnim;
        private string currentAnimationName;
        private int fps;
        private int currentFrame;

        public Animator(GameObject go, int fps) : base(go)
        {
            this.fps = fps;
            this.lastSwap = DateTime.Now;
        }

        /// <summary>
        /// Swaps animationframe, if enough time have passed
        /// </summary>
        /// <param name="gt">needed for IUpdateable</param>
        public void Update(TimeSpan gt)
        {
            if ((DateTime.Now - lastSwap).Milliseconds > 1000 / fps)
            {
                this.currentFrame = ++currentFrame == currentAnim.Length ? 0 : currentFrame;
                this.lastSwap = DateTime.Now;
                base.Renderer.SourceRectangle = currentAnim[currentFrame];
            }
        }

        /// <summary>
        /// Plays the animation with the specified name
        /// </summary>
        /// <param name="animationName">The name of the animation to play</param>
        public void PlayAnimation(string animationName)
        {
            if (this.currentAnimationName != animationName)
            {
                Other.Animation newAnim = animations[animationName];

                this.lastSwap = DateTime.Now;
                this.currentFrame = 0;
                this.currentAnim = newAnim.Frames;
                this.fps = newAnim.FramesPerSecond;
                this.currentAnimationName = animationName;
                base.Renderer.Sprite = Other.Picture.GetImage(newAnim.ImageName);
                base.Renderer.SourceRectangle = currentAnim[currentFrame];
            }
        }

        /// <summary>
        /// Creates an animation for use
        /// </summary>
        /// <param name="animName">The name of the animation to refer to it by</param>
        /// <param name="frameCount">The amount of frames in this animation</param>
        /// <param name="frameWidth">The width of the individual frames</param>
        /// <param name="frameHeight">The height of the individual frames</param>
        /// <param name="frameXOffset">The amount of frames occuring before the animation</param>
        /// <param name="frameYOffset">The line the animation occurs on</param>
        public void CreateAnimation(string animName, int frameCount, int frameWidth, int frameHeight, int frameXOffset, int frameYOffset)
        {
            if (animations.ContainsKey(animName))
                throw new Exception($"Animation by the name {animName} already exists");

            var tempAnim = new List<Rectangle>();

            for (int i = 0; i < frameCount; i++)
                tempAnim.Add(new Rectangle(frameWidth * (i + frameXOffset), frameHeight * frameYOffset, frameWidth, frameHeight));

            animations.Add(animName, new Other.Animation(Other.Picture.GetKey(Renderer.Sprite), fps, tempAnim.ToArray()));
        }

        /// <summary>
        /// Adds an animation to the list
        /// </summary>
        /// <param name="animName">the name of the Animation</param>
        /// <param name="sourceTexture">the image to find the animation on</param>
        /// <param name="framesSecond">the amount of frames to play per second</param>
        /// <param name="frames">the amount of frames present</param>
        /// <param name="frameWidth">the width of a frame</param>
        /// <param name="frameHeight">the height of a frame</param>
        /// <param name="frameXOffset">the frames occuring before the desired animation</param>
        /// <param name="frameYOffset">the frames occuring before the desired animation</param>
        public void CreateAnimation(string animName, string sourceTexture, int framesSecond, int frames, int frameWidth, int frameHeight, int frameXOffset, int frameYOffset)
            => animations.Add(animName, new Other.Animation(sourceTexture, framesSecond, frames, frameWidth, frameHeight, frameXOffset, frameYOffset));

        /// <summary>
        /// Adds an animation to the list
        /// </summary>
        /// <param name="animName">The animations tag</param>
        /// <param name="anim">the animation</param>
        public void CreateAnimation(string animName, Other.Animation anim)
            => animations.Add(animName, anim);
    }
}
