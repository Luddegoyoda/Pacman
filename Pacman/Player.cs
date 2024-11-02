using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Pacman
{
    public class Player : AnimatedObject
    {
        int timeSinceLastFrame = 0;
        int timeToAnimate = 150;
        int animationState = 1;

        float speed = 50f;

        Vector2 destination;
        Vector2 direction;

        bool isAlive = false;
        bool isMoving = false;
        Rectangle currentAnimation;

        public Player(Vector2 pos, Texture2D tex, Rectangle hitbox) : base(pos, tex, hitbox) 
        {
            this.pos = pos;
            this.tex = tex;
            this.hitbox = hitbox;
            currentAnimation = AnimationManager.playerEatAnimation[0];
            isAlive = true;
        }

        public override void Animate(GameTime gameTime)
        {
            timeSinceLastFrame += gameTime.ElapsedGameTime.Milliseconds;

            if (timeSinceLastFrame > timeToAnimate)
            {
                timeSinceLastFrame -= timeToAnimate;
                

                currentAnimation = AnimationManager.playerEatAnimation[animationState];

                animationState++;

                if (animationState >= 2)
                {
                    animationState = 0;
                }
            }
        }

        private void PlayerMoving(GameTime gameTime)
        {
            if (!isAlive)
                return;

                
                if (Keyboard.GetState().IsKeyDown(Keys.Left))
                {
                    ChangeDirection(new Vector2(-1, 0));
                   
                }
                else if (Keyboard.GetState().IsKeyDown(Keys.Right))
                {
                    ChangeDirection(new Vector2(1, 0));
                    
                }
                else if (Keyboard.GetState().IsKeyDown(Keys.Up))
                {
                    ChangeDirection(new Vector2(0, -1));
                }
                else if (Keyboard.GetState().IsKeyDown(Keys.Down))
                {
                    ChangeDirection(new Vector2(0, 1));
                }


            else
            {
                pos += direction * speed * (float)gameTime.ElapsedGameTime.TotalSeconds;

                if (Vector2.Distance(pos, destination) < 1)
                {
                    pos = destination;
                    isMoving = false;
                }
            }
        }

        public void ChangeDirection(Vector2 dir)
        {
            direction = dir;
            Vector2 newDestination = pos + direction * Game1.tileSize;
            Vector2 diagonal = new Vector2(newDestination.X, newDestination.Y - (-1 * Game1.tileSize));


            if (dir.X != 0)
            {
                if (GamemodeManager.GetTileAtPosition(newDestination))
                {
                    destination = newDestination;
                    isMoving = true;
                }
            }
            if (dir.Y != 0)
            {
                if (GamemodeManager.GetTileAtPosition(newDestination))
                {
                    destination = newDestination;
                    isMoving = true;
                }
            }
        }


        public override void Update(GameTime gameTime)
        {
            Animate(gameTime);
            PlayerMoving(gameTime);
            hitbox.X = (int)pos.X;
            hitbox.Y = (int)pos.Y;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(tex, hitbox, currentAnimation, Color.White); //TODO: Player currently doesn't know its own texture even though it's set when created in Game1 load function
        }

        

    }
}
