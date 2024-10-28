using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SharpDX.Direct2D1.Effects;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace Pacman
{
    public class AnimatedObject : CollisionObject
    {

        private int timeSinceLastFrame = 0;
        private int millisecondsPerFrame = 100;
        private Point currentFrame = new Point(0, 0);


        public AnimatedObject(Vector2 pos, Texture2D tex, Rectangle hitbox):base(pos,tex,hitbox)
        {


        }

        public virtual void Update(GameTime gameTime)
        {
            
        }

        public virtual void Animate(GameTime gameTime)
        {
            timeSinceLastFrame += gameTime.ElapsedGameTime.Milliseconds;

            if (timeSinceLastFrame > millisecondsPerFrame)
            {
                timeSinceLastFrame -= millisecondsPerFrame;
                currentFrame.X++;

                //if (currentFrame.X >= sheetSize.X)
                //{
                //    currentFrame.X = 0;
                //}
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(tex, hitbox, new Rectangle(currentFrame.X * Game1.spriteSize, currentFrame.Y * Game1.spriteSize, Game1.spriteSize, Game1.spriteSize), Color.White);
        }
    }
}
