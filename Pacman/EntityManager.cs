using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
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

        List<Enemy> enemyList;
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

        public void Update(GameTime gameTime)
        {
            PlayerUpdates(gameTime);
            if (!foodSpawned)
            {
                SpawnFood();
            }
        }


        public void Draw(SpriteBatch spriteBatch)
        {
            player.Draw(spriteBatch);
            foreach(Food food in foodList)
            {
                food.Draw(spriteBatch);
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
