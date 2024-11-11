using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SharpDX.Direct3D9;

namespace Pacman
{
    public class Player : AnimatedObject
    {
        int timeSinceLastFrame = 0;
        int timeToAnimate = 150;
        int animationState = 1;
        public int health = 3;

        float speed = 50f;
        float chaseSpeed = 70f;

        public new Vector2 pos;

        Vector2 destination;
        Vector2 direction;

        Vector2 origin;

        public bool isAlive = false;
        public bool isEmpowered = false;

        Rectangle currentAnimation;

        public Player(Vector2 pos, Texture2D tex, Rectangle hitbox) : base(pos, tex, hitbox)
        {
            this.pos = pos;
            this.tex = tex;
            this.hitbox = hitbox;
            currentAnimation = AnimationManager.playerEatAnimation[0];
            isAlive = true;
            origin = new Vector2(Game1.spriteSize / 2f, Game1.spriteSize / 2f);
            hitbox = new Rectangle((int)pos.X, (int)pos.Y, Game1.tileSize, Game1.tileSize);
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
                if (isEmpowered)
                {
                    pos += direction * chaseSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
                }
                else
                {
                    pos += direction * speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
                }

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
            hitbox.Width = Game1.tileSize;
            hitbox.Height = Game1.tileSize;

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