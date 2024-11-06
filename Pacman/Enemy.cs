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
        float speed = 48f;

        int wayPointReachedCounter = 0;
        Vector2 direction;

        float calculateCooldown = 0;
        float calculateTime = 0;

        public enum ENEMYTYPE { RED, PINK, CYAN, ORANGE };
        public ENEMYTYPE enemyType;

        List<Vector2> confirmedTiles = new List<Vector2>();

        int smallestIndex = 0; //temp

        public Enemy(Vector2 pos, Texture2D tex, Rectangle rec, ENEMYTYPE ENEMYTYPE) : base(pos, tex, rec)
        {
            this.pos = pos;
            this.tex = tex;
            this.hitbox = rec;
            posRef = pos;
            isAlive = true;
            enRouteToDestitation = false;
            pathFound = false;
            this.enemyType = ENEMYTYPE;
            targetPosition = Vector2.Zero;
            //switch (enemyType)
            //{
            //    case ENEMYTYPE.RED:
            //        this.speed = 50f;
            //        break;
            //    case ENEMYTYPE.PINK:
            //        this.speed = 48f;
            //        break;
            //    case ENEMYTYPE.CYAN:
            //        this.speed = 50f;
            //        break;
            //    case ENEMYTYPE.ORANGE:
            //        this.speed = 49f;
            //        break;
            //}
        }

        /// <summary>
        /// Find the position of all tiles around the enemy. The tile with the closest distance to the player is saved and a positionReference is marked as it being there. 
        /// From there it keeps going from the posRef and repeats the process, making sure no duplicate tiles are selected (this is what fixes ai being stuck). 
        /// Once it reaches within 10 distance of the given position, 20 waypoints has been reached, or no other alternative way is available the enemy moves to the last waypoint one by one.
        /// During the movement of the enemy no other pathfinding can be done until it is marked as no longer en route. The enemy is either A, calculating next route. Or B, moving to destination.
        /// </summary>
        public void CalculatePath(Vector2 targetPos, GameTime gameTime)
        {
            Vector2[] tilesToCheck = new Vector2[4];

            targetPosition.X = (int)targetPos.X;
            targetPosition.Y = (int)targetPos.Y;
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

                    if (posRef.X > 1000) //if no path is available say its done and ready to move there
                    {
                        pathFound = true;
                        wayPointReachedCounter = 0;
                    }

                    confirmedTiles.Add(posRef);

                    if (confirmedTiles.Count > 20 ) //crash fix and optimisation at once. poggers
                    {
                        pathFound = true;
                        wayPointReachedCounter = 0;
                    }
                    else if (50 < Vector2.Distance(posRef,targetPos))
                    {
                        CalculatePath(targetPos, gameTime);
                    }
                    else
                    {
                        pathFound = true;
                        wayPointReachedCounter = 0;
                    }
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
