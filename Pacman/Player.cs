﻿
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Runtime.CompilerServices;


namespace Pacman
{
    public class Player : AnimatedObject
    {
        int timeSinceLastFrame = 0;
        int timeToAnimate = 150;
        int animationState = 1;
        public int health = 3;

        float speed = 50f;

        public new Vector2 pos;

        Vector2 destination;
        Vector2 direction;

        Vector2 origin;

        public bool isAlive = false;
       
        Rectangle currentAnimation;


        public Player(Vector2 pos, Texture2D tex, Rectangle rec) : base(pos, tex, rec) 
        {
            this.pos = pos;
            this.tex = tex;
            this.hitbox = rec;
            hitbox = new Rectangle((int)pos.X, (int)pos.Y, Game1.tileSize, Game1.tileSize);
            currentAnimation = AnimationManager.playerEatAnimation[0];
            isAlive = true;
            origin = new Vector2(Game1.spriteSize / 2f, Game1.spriteSize / 2f);
            

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

            if (GamemodeManager.GetTileAtPosition(pos + direction * Game1.tileSize / 2))
            {
                pos += direction * speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
                
            }

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

            
        }

        public void ChangeDirection(Vector2 dir)
        {
            direction = dir;
            Vector2 newDestination = pos + direction * Game1.tileSize / 2;
            if (GamemodeManager.GetTileAtPosition(newDestination))
            {
                destination = newDestination; //This might be the thing causing weird movement collision
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
            if (direction.X >= 1)
            {
                spriteBatch.Draw(tex, hitbox, currentAnimation, Color.White, 0f, origin, SpriteEffects.None, 0);
            }
            if (direction.X <= -1)
            {
                spriteBatch.Draw(tex, hitbox, currentAnimation, Color.White, 0f, origin, SpriteEffects.FlipHorizontally, 0);
            }
            if (direction.Y >= 1)
            {
                spriteBatch.Draw(tex, hitbox, currentAnimation, Color.White, 4.7f, origin, SpriteEffects.FlipHorizontally, 0);
            }
            if (direction.Y <= -1)
            {
                spriteBatch.Draw(tex, hitbox, currentAnimation, Color.White, 4.7f, origin, SpriteEffects.None, 0);
            }
            if (direction.Y == 0 && direction.X == 0)
            {
                spriteBatch.Draw(tex, hitbox, currentAnimation, Color.White, 0f, origin, SpriteEffects.None, 0);
            }
            
        }

        

    }
}
