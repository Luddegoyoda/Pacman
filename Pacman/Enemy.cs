using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace Pacman
{
    public class Enemy : AnimatedObject
    {

        public Vector2 targetPosition;
        Vector2 posRef;
        bool isAlive;
        bool enRouteToDestitation;
        bool pathFound;
        public bool isRespawning;
        public bool isScared;
        float speed = 48f;
        //float respawnSpeed = 70f;

        public new Vector2 pos;
        public Vector2 posCache;
        public Vector2 spawnPoint;

        int cacheTime = 3000;
        int currentTime = 0;

        int timeSinceLastFrame = 0;
        int timeToAnimate = 150;
        int animationState = 1;
        Rectangle currentAnimation;

        int wayPointReachedCounter = 0;
        Vector2 direction;

        public enum ENEMYTYPE { RED, PINK, CYAN, ORANGE };
        public ENEMYTYPE enemyType;

        List<Vector2> confirmedTiles = new List<Vector2>();

        int smallestIndex = 0;

        public Enemy(Vector2 pos, Texture2D tex, Rectangle rec, ENEMYTYPE ENEMYTYPE) : base(pos, tex, rec)
        {
            this.pos = pos;
            this.tex = tex;
            this.hitbox = rec;
            posRef = pos;
            isAlive = true;
            enRouteToDestitation = false;
            pathFound = false;
            isScared = false;
            this.enemyType = ENEMYTYPE;
            targetPosition = Vector2.Zero;
            posCache = pos;
            switch (enemyType)
            {
                case ENEMYTYPE.RED:
                    this.speed = 49f;
                    spawnPoint = EntityManager.enemySpawnLocations[0];
                    break;
                case ENEMYTYPE.PINK:
                    this.speed = 48f;
                    spawnPoint = EntityManager.enemySpawnLocations[1];
                    break;
                case ENEMYTYPE.CYAN:
                    this.speed = 50f;
                    spawnPoint = EntityManager.enemySpawnLocations[2];
                    break;
                case ENEMYTYPE.ORANGE:
                    this.speed = 47f;
                    spawnPoint = EntityManager.enemySpawnLocations[3];
                    break;
            }

        }

        public override void Animate(GameTime gameTime)
        {
            timeSinceLastFrame += gameTime.ElapsedGameTime.Milliseconds;

            if (timeSinceLastFrame > timeToAnimate)
            {
                timeSinceLastFrame -= timeToAnimate;

                switch (enemyType)
                {
                    case ENEMYTYPE.RED:
                        if (direction.X >= 1)
                        {
                            currentAnimation = AnimationManager.redGhostLeft[animationState];

                        }
                        if (direction.X <= -1)
                        {
                            currentAnimation = AnimationManager.redGhostRight[animationState];
                        }
                        if (direction.Y >= 1)
                        {
                            currentAnimation = AnimationManager.redGhostDown[animationState];
                        }
                        if (direction.Y <= -1)
                        {
                            currentAnimation = AnimationManager.redGhostUp[animationState];

                        }
                        if (direction.Y == 0 && direction.X == 0)
                        {
                            currentAnimation = AnimationManager.redGhostRight[animationState];
                        }
                        break;
                    case ENEMYTYPE.PINK:
                        if (direction.X >= 1)
                        {
                            currentAnimation = AnimationManager.pinkGhostLeft[animationState];

                        }
                        if (direction.X <= -1)
                        {

                            currentAnimation = AnimationManager.pinkGhostRight[animationState];
                        }
                        if (direction.Y >= 1)
                        {
                            currentAnimation = AnimationManager.pinkGhostDown[animationState];
                        }
                        if (direction.Y <= -1)
                        {

                            currentAnimation = AnimationManager.pinkGhostUp[animationState];
                        }
                        if (direction.Y == 0 && direction.X == 0)
                        {
                            currentAnimation = AnimationManager.pinkGhostRight[animationState];
                        }
                        break;
                    case ENEMYTYPE.CYAN:
                        if (direction.X >= 1)
                        {
                            currentAnimation = AnimationManager.cyanGhostLeft[animationState];
                        }
                        if (direction.X <= -1)
                        {
                            currentAnimation = AnimationManager.orangeGhostRight[animationState];

                        }
                        if (direction.Y >= 1)
                        {
                            currentAnimation = AnimationManager.cyanGhostDown[animationState];
                        }
                        if (direction.Y <= -1)
                        {

                            currentAnimation = AnimationManager.cyanGhostUp[animationState];
                        }
                        if (direction.Y == 0 && direction.X == 0)
                        {
                            currentAnimation = AnimationManager.orangeGhostRight[animationState];
                        }
                        break;
                    case ENEMYTYPE.ORANGE:
                        if (direction.X >= 1)
                        {
                            currentAnimation = AnimationManager.orangeGhostTexLeft[animationState];
                        }
                        if (direction.X <= -1)
                        {

                            currentAnimation = AnimationManager.orangeGhostTexRight[animationState];
                        }
                        if (direction.Y >= 1)
                        {
                            currentAnimation = AnimationManager.orangeGhostTexDown[animationState];
                        }
                        if (direction.Y <= -1)
                        {

                            currentAnimation = AnimationManager.orangeGhostTexUp[animationState];
                        }
                        if (direction.Y == 0 && direction.X == 0)
                        {
                            currentAnimation = AnimationManager.orangeGhostRight[animationState];
                        }
                        break;
                }


                animationState++;

                if (animationState >= 2)
                {
                    animationState = 0;
                }
            }
        }

        /// <summary>
        /// Find the position of all tiles around the enemy. The tile with the closest distance to the player is saved and a positionReference is marked as it being there. 
        /// From there it keeps going from the posRef and repeats the process, making sure no duplicate tiles are selected (this is what fixes ai being stuck). 
        /// Once it reaches within 10 distance of the given position, 20 waypoints has been reached, or no other alternative way is available the enemy moves to the last waypoint one by one.
        /// During the movement of the enemy no other pathfinding can be done until it is marked as no longer en route. The enemy is either A, calculating next route. Or B, moving to destination.
        /// </summary>
        public void CalculatePath(Vector2 targetPos)
        {
            Vector2[] tilesToCheck = new Vector2[4];

            targetPosition.X = (int)targetPos.X;
            targetPosition.Y = (int)targetPos.Y;
            if (!enRouteToDestitation && !pathFound)
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
                    foreach (Vector2 position in confirmedTiles)
                    {
                        if (tilesToCheck[i] == position)
                        {
                            tilesToCheck[i] = new Vector2(99999, 99999);
                        }
                    }
                }
                float smallestDistance = 99999;
                float[] distances = new float[4];

                if (!isScared)
                {
                    for (int i = 0; i < 4; i++)
                    {
                        distances[i] = Vector2.Distance(targetPos, tilesToCheck[i]);

                        if (smallestDistance > distances[i])
                        {
                            smallestDistance = distances[i];
                            smallestIndex = i;
                        }
                    }
                }
                else // if scared run away
                {
                    smallestDistance = 0;
                    for (int i = 0; i < 4; i++)
                    {
                        distances[i] = Vector2.Distance(targetPos, tilesToCheck[i]);

                        if (smallestDistance < distances[i] && distances[i] < 1000 && distances[i] > 32)
                        {
                            smallestDistance = distances[i];
                            smallestIndex = i;
                        }
                    }
                }

                posRef = tilesToCheck[smallestIndex];

                if (posRef.X > 850)
                {
                    pathFound = true;
                    wayPointReachedCounter = 0;
                }
                else
                {
                    confirmedTiles.Add(posRef);
                }



                if (confirmedTiles.Count > 30)
                {
                    pathFound = true;
                    wayPointReachedCounter = 0;
                }
                else if (50 < Vector2.Distance(posRef, targetPos))
                {
                    CalculatePath(targetPos);
                }
                else
                {
                    pathFound = true;
                    wayPointReachedCounter = 0;
                }
            }
        }

        void PathFidningMovement(GameTime gameTime)
        {
            if (currentTime > cacheTime)
            {
                if (posCache.X >= pos.X && pos.X + 1 >= posCache.X || posCache.X <= pos.X && pos.X - 1 <= posCache.X || pos.X > 1000)
                {
                    if (posCache.Y >= pos.Y && pos.Y + 1 >= posCache.Y || posCache.Y <= pos.Y && pos.Y - 1 <= posCache.Y || pos.X > 1000)
                    {
                        pos = spawnPoint;
                        CancelMovement();
                    }
                }
                posCache = pos;
                currentTime = 0;
            }
            else
            {
                currentTime += (int)gameTime.ElapsedGameTime.TotalMilliseconds;
            }

            if (pathFound && confirmedTiles.Count > 0)
            {
                Vector2 posCopy = pos;

                if ((int)posCopy.X - confirmedTiles[wayPointReachedCounter].X > 0)
                {
                    direction = new Vector2(-1, 0);
                }
                else if ((int)posCopy.X - confirmedTiles[wayPointReachedCounter].X < 0)
                {
                    direction = new Vector2(1, 0);

                }
                else if ((int)posCopy.Y - confirmedTiles[wayPointReachedCounter].Y > 0)
                {
                    direction = new Vector2(0, -1);
                }
                else if ((int)posCopy.Y - confirmedTiles[wayPointReachedCounter].Y < 0)
                {
                    direction = new Vector2(0, 1);

                }
                if (Vector2.Distance(pos, confirmedTiles[wayPointReachedCounter]) < 1)
                {
                    wayPointReachedCounter++;
                }
                enRouteToDestitation = true;
                //if (isRespawning)
                //{
                //    pos += direction * respawnSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
                //}
                //else
                //{
                pos += direction * speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
                //}

                if (10 > Vector2.Distance(pos, confirmedTiles[^1]))
                {
                    CancelMovement();
                }

            }
        }

        public void CancelMovement()
        {
            enRouteToDestitation = false;
            pathFound = false;
            confirmedTiles.Clear();
            posRef = pos;
            if (isRespawning)
            {
                switch (enemyType)
                {
                    case ENEMYTYPE.RED:
                        if (60 > Vector2.Distance(pos, EntityManager.enemySpawnLocations[0]))
                        {
                            isRespawning = false;
                            enRouteToDestitation = false;
                        }
                        break;
                    case ENEMYTYPE.PINK:
                        if (60 > Vector2.Distance(pos, EntityManager.enemySpawnLocations[1]))
                        {
                            isRespawning = false;
                            enRouteToDestitation = false;
                        }
                        break;
                    case ENEMYTYPE.CYAN:
                        if (60 > Vector2.Distance(pos, EntityManager.enemySpawnLocations[2]))
                        {
                            isRespawning = false;
                            enRouteToDestitation = false;
                        }
                        break;
                    case ENEMYTYPE.ORANGE:
                        if (60 > Vector2.Distance(pos, EntityManager.enemySpawnLocations[3]))
                        {
                            isRespawning = false;
                            enRouteToDestitation = false;
                        }

                        break;

                }
            }
        }

        public void RespawnPhase()
        {
            CancelMovement();
            isRespawning = true;
            isScared = false;
            CalculatePath(spawnPoint);
        }

        public override void Update(GameTime gameTime)
        {
            hitbox.X = (int)pos.X;
            hitbox.Y = (int)pos.Y;
            hitbox.Width = Game1.tileSize;
            hitbox.Height = Game1.tileSize;
            PathFidningMovement(gameTime);
            Animate(gameTime);
        }





        public override void Draw(SpriteBatch spriteBatch)
        {
            if (isAlive)
            {
                if (!isRespawning && !isScared)
                {
                    switch (enemyType)
                    {
                        case ENEMYTYPE.RED:
                            spriteBatch.Draw(tex, hitbox, currentAnimation, Color.White);
                            break;
                        case ENEMYTYPE.PINK:
                            spriteBatch.Draw(tex, hitbox, currentAnimation, Color.White);
                            break;
                        case ENEMYTYPE.CYAN:
                            spriteBatch.Draw(tex, hitbox, currentAnimation, Color.White);
                            break;
                        case ENEMYTYPE.ORANGE:
                            spriteBatch.Draw(tex, hitbox, currentAnimation, Color.White);
                            break;
                    }
                }
                else if (isScared)
                {
                    spriteBatch.Draw(tex, hitbox, AnimationManager.scaredBlueGhostTex[animationState], Color.White);
                }
                else
                {
                    spriteBatch.Draw(tex, hitbox, AnimationManager.respawnEyesGhostTex[animationState], Color.White);
                }


            }
        }
    }
}
