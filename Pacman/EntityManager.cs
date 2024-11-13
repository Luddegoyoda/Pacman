using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SharpDX.Direct2D1.Effects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman
{
    public class EntityManager
    {
        public Player player;

        bool foodSpawned = false;

        public List<Enemy> enemyList;

        public Vector2 playerSpawnPos;
        public static List<Vector2> enemySpawnLocations;
        public static List<Vector2> foodLocations;
        public static List<Vector2> powerupLocations;

        int poweredUpTime = 5000;
        int currentTime = 0;
        

        public List<Food> foodList;
        public List<Powerup> powerUpList;

        public EntityManager()
        {
            enemyList = new List<Enemy>();
            foodList = new List<Food>();
            powerUpList = new List<Powerup>();
            foodLocations = new List<Vector2>();
            powerupLocations = new List<Vector2>();
            enemySpawnLocations = new List<Vector2>() { new Vector2(490,490), new Vector2(522, 522), new Vector2(394, 468), new Vector2(490, 522)};
            playerSpawnPos= new Vector2(400,400);
        }

        public void SpawnFood()
        {
            foodList.Clear();
            foreach(Vector2 foodSpawn in foodLocations)
            {
                foodList.Add(new Food(foodSpawn,TextureManager.spriteSheet,new Rectangle((int)foodSpawn.X + Game1.spriteSize / 2, (int)foodSpawn.Y + Game1.spriteSize / 2, Game1.spriteSize,Game1.spriteSize)));
            }
            foodSpawned = true;
        }

        public void SpawnPowerup()
        {
            powerUpList.Clear();
            foreach (Vector2 powerUpSpawn in powerupLocations)
            {
                powerUpList.Add(new Powerup(powerUpSpawn, TextureManager.spriteSheet, new Rectangle((int)powerUpSpawn.X + Game1.spriteSize / 2, (int)powerUpSpawn.Y + Game1.spriteSize / 2, Game1.spriteSize, Game1.spriteSize)));
            }
            foodSpawned = true;
        }

        void SpawnEnemies()
        {
            enemyList.Add(new Enemy(enemySpawnLocations[0], TextureManager.spriteSheet, new Rectangle(480, 480, Game1.spriteSize, Game1.spriteSize), Enemy.ENEMYTYPE.RED));
            enemyList.Add(new Enemy(enemySpawnLocations[1], TextureManager.spriteSheet, new Rectangle(480, 480, Game1.spriteSize, Game1.spriteSize), Enemy.ENEMYTYPE.PINK));
            enemyList.Add(new Enemy(enemySpawnLocations[2], TextureManager.spriteSheet, new Rectangle(520, 460, Game1.spriteSize, Game1.spriteSize), Enemy.ENEMYTYPE.CYAN));
            enemyList.Add(new Enemy(enemySpawnLocations[3], TextureManager.spriteSheet, new Rectangle(480, 500, Game1.spriteSize, Game1.spriteSize), Enemy.ENEMYTYPE.ORANGE));
        }

        public void Update(GameTime gameTime)
        {
            PlayerUpdates(gameTime);
            if (!foodSpawned)
            {
                SpawnFood();
                SpawnPowerup();
                GamemodeManager.foodGoal = foodList.Count;
            }
            if (enemyList.Count < 1)
            {
                SpawnEnemies();
            }
            foreach(Enemy enemy in enemyList)
            {
                enemy.Update(gameTime);

                if (player.isEmpowered)
                {
                    if (!enemy.isSacred && !enemy.isRespawning)
                    {
                        enemy.isSacred = true;
                        enemy.CancelMovement();
                    }
                }
                else
                {
                    if (enemy.isSacred)
                    {
                        enemy.isSacred = false;
                        enemy.CancelMovement();
                    }
                }
                enemy.CalculatePath(player.pos);
            }
        }


        


        private void PlayerUpdates(GameTime gameTime)
        {
            player.Update(gameTime);

            if (player.isEmpowered)
            {
                if (currentTime > poweredUpTime)
                {
                    player.isEmpowered = false;
                    currentTime = 0;
                }
                else
                {
                    currentTime += (int)gameTime.ElapsedGameTime.TotalMilliseconds;
                }
            }

            foreach (Food food in foodList)
            {
                if (player.hitbox.Intersects(food.hitbox))
                {
                    if (food.isAlive)
                    {
                        SoundManager.PlayEffect(SoundManager.allSoundEffects[0]);
                        GamemodeManager.score += 100;
                    }
                    food.isAlive= false;
                }
            }
            foreach (Powerup powerup in powerUpList)
            {
                if (player.hitbox.Intersects(powerup.hitbox))
                {
                    if (powerup.isAlive)
                    {
                        SoundManager.PlayEffect(SoundManager.allSoundEffects[0]);
                        player.isEmpowered = true;
                        GamemodeManager.score += 100;
                    }
                    powerup.isAlive = false;
                }
            }
            foreach (Enemy enemy in enemyList)
            {
                if (player.hitbox.Intersects(enemy.hitbox))
                {
                    if (player.isEmpowered)
                    {
                        enemy.RespawnPhase();
                        GamemodeManager.score += 500;
                    }
                    else
                    {
                        player.health--;
                        ResetEntities();
                    }
                }
            }

            if (player.health <= 0)
            {
                Game1.gameState = Game1.GAMESTATE.LOST;
                player.health = 3;
            }

        }
        

        void ResetEntities()
        {
            player.pos = playerSpawnPos;

            for (int i = 0; i < enemyList.Count; i++)
            {
                enemyList[i].pos = enemySpawnLocations[i];
                enemyList[i].CancelMovement();
            }
            SpawnFood();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            player.Draw(spriteBatch);
            foreach (Food food in foodList)
            {
                food.Draw(spriteBatch);
            }
            foreach (Powerup powerup in powerUpList)
            {
                powerup.Draw(spriteBatch);
            }
            foreach (Enemy enemy in enemyList)
            {
                enemy.Draw(spriteBatch);
            }
            
        }

    }


}
