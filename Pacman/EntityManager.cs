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
        public static List<Vector2> foodLocations;

        public List<Food> foodList;

        public EntityManager()
        {
            enemyList = new List<Enemy>();
            foodList = new List<Food>();
            foodLocations = new List<Vector2>();
            
        }

        public void SpawnFood()
        {
            foreach(Vector2 foodSpawn in foodLocations)
            {
                foodList.Add(new Food(foodSpawn,TextureManager.spriteSheet,new Rectangle((int)foodSpawn.X + Game1.spriteSize / 2, (int)foodSpawn.Y + Game1.spriteSize / 2, Game1.spriteSize,Game1.spriteSize)));
            }
            foodSpawned = true;
        }

        void SpawnEnemies()
        {
            enemyList.Add(new Enemy(new Vector2(480, 480), TextureManager.spriteSheet, new Rectangle(480, 480, Game1.spriteSize, Game1.spriteSize), Enemy.ENEMYTYPE.RED));
            enemyList.Add(new Enemy(new Vector2(500, 480), TextureManager.spriteSheet, new Rectangle(500, 480, Game1.spriteSize, Game1.spriteSize), Enemy.ENEMYTYPE.PINK));
            enemyList.Add(new Enemy(new Vector2(500, 500), TextureManager.spriteSheet, new Rectangle(500, 500, Game1.spriteSize, Game1.spriteSize), Enemy.ENEMYTYPE.CYAN));
            enemyList.Add(new Enemy(new Vector2(480, 500), TextureManager.spriteSheet, new Rectangle(480, 500, Game1.spriteSize, Game1.spriteSize), Enemy.ENEMYTYPE.ORANGE));
        }

        public void Update(GameTime gameTime)
        {
            PlayerUpdates(gameTime);
            if (!foodSpawned)
            {
                SpawnFood();
            }
            if (enemyList.Count < 1)
            {
                SpawnEnemies();
            }
            foreach(Enemy enemy in enemyList)
            {
                enemy.Update(gameTime);
                enemy.CalculatePath(player.pos, gameTime);
            }
        }


        public void Draw(SpriteBatch spriteBatch)
        {
            player.Draw(spriteBatch);
            foreach(Food food in foodList)
            {
                food.Draw(spriteBatch);
            }
            foreach(Enemy enemy in enemyList)
            {
                enemy.Draw(spriteBatch);
            }
        }



        private void PlayerUpdates(GameTime gameTime)
        {
            player.Update(gameTime);

            foreach (Food food in foodList)
            {
                if (player.hitbox.Intersects(food.hitbox))
                {
                    if (food.isAlive)
                    {
                        SoundManager.PlayEffect(SoundManager.allSoundEffects[0]);
                    }
                    food.isAlive= false;
                    
                }
            }
            foreach (Enemy enemy in enemyList)
            {
                if (player.hitbox.Intersects(enemy.hitbox))
                {
                    player.health--;
                }
            }


            if (player.health <= 0)
            {
                player.isAlive = false;
            }

        }
    }

    
}
