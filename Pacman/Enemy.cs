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
        
        public Vector2 targetPosition;
        Vector2 posRef;
        bool isAlive;
        bool enRouteToDestitation;
        bool pathFound;
        float speed = 45f;

        int wayPointReachedCounter = 0;
        Vector2 direction;

        float calculateCooldown = 0;
        float calculateTime = 0;

        public enum ENEMYTYPE { RED, PINK, CYAN, ORANGE };
        ENEMYTYPE enemyType;

        List<Vector2> confirmedTiles = new List<Vector2>();

        int smallestIndex = 0; //temp

        public Enemy(Vector2 pos, Texture2D tex, Rectangle rec) : base(pos, tex, rec)
        {
            this.pos = pos;
            this.tex = tex;
            this.hitbox = rec;
            posRef = pos;
            isAlive = true;
            enRouteToDestitation = false;
            pathFound = false;
            enemyType= ENEMYTYPE.RED;
            targetPosition = Vector2.Zero;
        }

        public void CalculatePath(Vector2 targetPos, GameTime gameTime)
        {
            Vector2[] tilesToCheck = new Vector2[4]; //Find the 4 tiles around us. 
            targetPosition = targetPos;
            if (!enRouteToDestitation && !pathFound)
            {
                if (calculateTime > calculateCooldown)
                {
                    for (int i = 0; i < tilesToCheck.Length; i++)
                    {
                        switch (i)
                        {
                            case 0:
                                Vector2 newDestination = posRef + new Vector2(0, -1) * Game1.tileSize;
                                newDestination.Floor();
                                if (GamemodeManager.GetTileAtPosition(new Vector2(newDestination.X, newDestination.Y)))
                                {
                                    tilesToCheck[i] = new Vector2(newDestination.X, newDestination.Y);
                                }
                                else
                                {
                                    tilesToCheck[i] = new Vector2(900000, 900000);
                                }
                                break;

                            case 1:
                                newDestination = posRef + new Vector2(-1, 0) * Game1.tileSize;
                                newDestination.Floor();
                                if (GamemodeManager.GetTileAtPosition(new Vector2(newDestination.X, newDestination.Y)))
                                {
                                    tilesToCheck[i] = new Vector2(newDestination.X, newDestination.Y);
                                }
                                else
                                {
                                    tilesToCheck[i] = new Vector2(900000, 900000);
                                }
                                break;

                            case 2:
                                newDestination = posRef + new Vector2(1, 0) * Game1.tileSize;
                                newDestination.Floor();
                                if (GamemodeManager.GetTileAtPosition(new Vector2(newDestination.X, newDestination.Y)))
                                {
                                    tilesToCheck[i] = new Vector2(newDestination.X, newDestination.Y);
                                }
                                else
                                {
                                    tilesToCheck[i] = new Vector2(900000, 900000);
                                }
                                break;

                            case 3:
                                newDestination = posRef + new Vector2(0, 1) * Game1.tileSize;
                                newDestination.Floor();
                                if (GamemodeManager.GetTileAtPosition(new Vector2(newDestination.X, newDestination.Y)))
                                {
                                    tilesToCheck[i] = new Vector2(newDestination.X, newDestination.Y);
                                }
                                else
                                {
                                    tilesToCheck[i] = new Vector2(900000, 900000);
                                }
                                break;
                        }
                        foreach(Vector2 position in confirmedTiles)
                        {
                            if (tilesToCheck[i] == position)
                            {
                                tilesToCheck[i] = new Vector2(99999,99999);
                            }
                        }
                    }
                    float smallestDistance = 99999;
                    float[] distances = new float[4];

                    for (int i = 0; i < 4; i++)
                    {
                        distances[i] = Vector2.Distance(targetPos, tilesToCheck[i]);
                        if (smallestDistance > distances[i])
                        {
                            smallestDistance = distances[i];
                            smallestIndex = i;
                        }   
                    }
                    
                    posRef = tilesToCheck[smallestIndex];
                    confirmedTiles.Add(posRef);
                    
                    if (50 < Vector2.Distance(posRef,targetPos))
                    {
                        CalculatePath(targetPos, gameTime);
                    }
                    else
                    {
                        pathFound = true;
                        wayPointReachedCounter = 0;
                    }
                            
                            
                int j = 0;
                }
                else
                {
                    calculateTime += (int)gameTime.ElapsedGameTime.TotalMilliseconds;
                }
            }
           
        }

        public override void Update(GameTime gameTime)
        {
            hitbox.X = (int)pos.X;
            hitbox.Y = (int)pos.Y;
            
            
            //if (smallestIndex == 1)
            //{
            //    direction = new Vector2(-1, 0);
            //}
            //else if (smallestIndex == 2)
            //{
            //    direction = new Vector2(1, 0);
            //}
            //else if (smallestIndex == 0)
            //{
            //    direction = new Vector2(0, -1);
            //}
            //else if (smallestIndex == 3)
            //{
            //    direction = new Vector2(0, 1);
            //}

            if (pathFound)
            {
                
                    if((int)pos.X - confirmedTiles[wayPointReachedCounter].X > 0)
                    {
                        direction = new Vector2(-1,0);
                    }
                    else if ((int)pos.X - confirmedTiles[wayPointReachedCounter].X < 0)
                    {
                        direction = new Vector2(1, 0);
                        
                    }
                    else if ((int)pos.Y - confirmedTiles[wayPointReachedCounter].Y > 0)
                    {
                        direction = new Vector2(0, -1);
                    }
                    else if ((int)pos.Y - confirmedTiles[wayPointReachedCounter].Y < 0)
                    {
                        direction = new Vector2(0, 1);
                        
                    }
                    if (Vector2.Distance(pos, confirmedTiles[wayPointReachedCounter]) < 1)
                    {
                        wayPointReachedCounter++;
                    }
                
                pos += direction * speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
                if (10 > Vector2.Distance(pos, confirmedTiles[^1]))
                {
                    enRouteToDestitation = false;
                    pathFound = false;
                    confirmedTiles.Clear();
                    
                }
                
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
