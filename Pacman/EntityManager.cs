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
                foodList.Add(new Food(foodSpawn,TextureManager.spriteSheet,new Rectangle((int)foodSpawn.X, (int)foodSpawn.Y, Game1.spriteSize,Game1.spriteSize)));
            }
            foodSpawned = true;
        }

        void SpawnEnemies()
        {
            enemyList.Add(new Enemy(new Vector2(400, 450), TextureManager.spriteSheet, new Rectangle(400, 450, Game1.spriteSize, Game1.spriteSize)));
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
                    food.isAlive= false;
                }
            }
            

            if (player.health <= 0)
            {
                
            }

        }
    }

    
}
