using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SharpDX.Direct2D1.Effects;
using System.Collections.Generic;
using System.IO;

namespace Pacman
{
    public class AnimatedObject : CollisionObject
    {

        private int timeSinceLastFrame = 0;
        private int millisecondsPerFrame = 100;
        private Point currentFrame = new Point(0, 0);
        private Point sheetSize;
        private Point frameSize;
        public AnimatedObject(Vector2 pos, Texture2D tex, Rectangle rec,Point sheetSize, Point frameSize):base(pos,tex,rec)
        {
            this.sheetSize = sheetSize;
            this.frameSize = frameSize;


        }

        public void Update(GameTime gameTime)
        {
            timeSinceLastFrame += gameTime.ElapsedGameTime.Milliseconds;

            if (timeSinceLastFrame > millisecondsPerFrame)
            {
                timeSinceLastFrame -= millisecondsPerFrame;
                currentFrame.X++;

                if (currentFrame.X >= sheetSize.X)
                {
                    currentFrame.X = 0;
                }
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(tex, rec, new Rectangle(currentFrame.X * frameSize.X, currentFrame.Y * frameSize.Y, frameSize.X, frameSize.Y), Color.White);
        }
    }
}
