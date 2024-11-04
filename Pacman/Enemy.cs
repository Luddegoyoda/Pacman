using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Pacman
{
    public class Enemy : AnimatedObject
    {
        Random random; //temp
        int randomDirection = 0;//temp
        public Vector2 targetPosition;
        bool isAlive;
        float speed = 50f;
        Vector2 direction;
        public enum ENEMYTYPE { RED, PINK, CYAN, ORANGE };
        ENEMYTYPE enemyType;
        public Enemy(Vector2 pos, Texture2D tex, Rectangle rec) : base(pos, tex, rec)
        {
            this.pos = pos;
            this.tex = tex;
            this.hitbox = rec;
            isAlive= true;
            enemyType= ENEMYTYPE.RED;
            random = new Random();
        }

        public void SetTargetPosition(Vector2 pos)
        {
            this.targetPosition = pos;
        }

        void CalculateOpimalPath()
        {
            Vector2[] tilesToCheck = new Vector2[9]; //Find the 9 tiles around us. 
            for (int i = 0; i < tilesToCheck.Length; i++) 
            {
                switch (i)
                {

                    case 0:
                        Vector2 newDestination = pos + new Vector2(-1, -1) * Game1.tileSize;
                        tilesToCheck[i] = new Vector2(newDestination.X, newDestination.Y + (+2 * Game1.tileSize));
                        break;
                    case 1:
                        newDestination = pos + new Vector2(0, -1) * Game1.tileSize;
                        tilesToCheck[i] = new Vector2(newDestination.X, newDestination.Y + (+2 * Game1.tileSize));
                        break;
                    case 2:
                        newDestination = pos + new Vector2(1, -1) * Game1.tileSize;
                        tilesToCheck[i] = new Vector2(newDestination.X, newDestination.Y + (+2 * Game1.tileSize));
                        break;
                    case 3:
                        newDestination = pos + new Vector2(-1, 0) * Game1.tileSize;
                        tilesToCheck[i] = new Vector2(newDestination.X, newDestination.Y + (0 * Game1.tileSize));
                        break;
                    case 4:
                        tilesToCheck[i] = pos;
                        break;
                    case 5:
                        newDestination = pos + new Vector2(1, 0) * Game1.tileSize;
                        tilesToCheck[i] = new Vector2(newDestination.X, newDestination.Y + (0 * Game1.tileSize));
                        break;
                    case 6:
                        newDestination = pos + new Vector2(-1, 1) * Game1.tileSize;
                        tilesToCheck[i] = new Vector2(newDestination.X, newDestination.Y - (-1 * Game1.tileSize));
                        break;
                    case 7:
                        newDestination = pos + new Vector2(0, 1) * Game1.tileSize;
                        tilesToCheck[i] = new Vector2(newDestination.X, newDestination.Y - (-1 * Game1.tileSize));
                        break;
                    case 8:
                        newDestination = pos + new Vector2(1, 1) * Game1.tileSize;
                        tilesToCheck[i] = new Vector2(newDestination.X, newDestination.Y - (-1 * Game1.tileSize));
                        break;
                }
            }
            

            float[] xDistances = new float[9];
            for (int i = 0; i < xDistances.Length; i++) //give them a x and y score based on the differential between it and our target destination
            {
                xDistances[i] = tilesToCheck[i].X / Game1.tileSize % targetPosition.X / Game1.tileSize;
            }
            int j = 0;
        }

        public override void Update(GameTime gameTime)
        {
            SetTargetPosition(new Vector2(400, 400));
            CalculateOpimalPath();

            hitbox.X = (int)pos.X;
            hitbox.Y = (int)pos.Y;


            randomDirection = random.Next(0, 100); // temp movement
            if (randomDirection >= 90)
            {
                direction = new Vector2(-1, 0);
            }
            else if (randomDirection >= 50 && randomDirection < 89)
            {
                direction = new Vector2(1, 0);
            }
            else if (randomDirection >= 25 && randomDirection < 50)
            {
                direction = new Vector2(0, -1);
            }
            else if (randomDirection < 25)
            {
                direction = new Vector2(0, 1);
            }

            if (GamemodeManager.GetTileAtPosition(pos + direction * Game1.tileSize))
            {
                pos += direction * speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (isAlive)
            {
                switch (enemyType)
                {
                    case ENEMYTYPE.RED:
                        spriteBatch.Draw(tex, hitbox, AnimationManager.redGhostTex[0], Color.White);
                        break;
                    case ENEMYTYPE.PINK:
                        spriteBatch.Draw(tex, hitbox, AnimationManager.pinkGhostTex[0], Color.White);
                        break;
                    case ENEMYTYPE.CYAN:
                        spriteBatch.Draw(tex, hitbox, AnimationManager.cyanGhostTex[0], Color.White);
                        break;
                    case ENEMYTYPE.ORANGE:
                        spriteBatch.Draw(tex, hitbox, AnimationManager.orangeGhostTex[0], Color.White);
                        break;

                }

            }
        }
    }
}
