using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Pacman
{
    public class Player : AnimatedObject
    {
        int timeSinceLastFrame = 0;
        int timeToAnimate = 100;
        int animationState = 1;
        Rectangle currentAnimation;

        public Player(Vector2 pos, Texture2D tex, Rectangle hitbox) : base(pos, tex, hitbox) 
        {
            this.pos = pos;
            this.tex = tex;
            this.hitbox = hitbox;
            currentAnimation = AnimationManager.playerEatAnimation[0];
        }

        public override void Animate(GameTime gameTime)
        {
            timeSinceLastFrame += gameTime.ElapsedGameTime.Milliseconds;

            if (timeSinceLastFrame > timeToAnimate)
            {
                timeSinceLastFrame -= timeToAnimate;
                animationState++;

                currentAnimation = AnimationManager.playerEatAnimation[animationState];

                if (animationState >= 3)
                {
                    animationState = 1;
                }
            }
        }

        public override void Update(GameTime gameTime)
        {
            Animate(gameTime);
            hitbox.X = (int)pos.X;
            hitbox.Y = (int)pos.Y;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(tex, hitbox, currentAnimation, Color.White); //TODO: Player currently doesn't know its own texture even though it's set when created in Game1 load function
        }

        //public static bool GetTileAtPosition(Vector2 pos)
        //{
        //    return tileArray[(int)pos.X / tileSize, (int)pos.Y / tileSize].NotWalkable;
        //}

    }
}
