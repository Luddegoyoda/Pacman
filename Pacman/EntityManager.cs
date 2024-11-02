using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Pacman.Game1;

namespace Pacman
{
    public class EntityManager
    {
        public Player player;

        List<Enemy> enemyArray;

        public EntityManager()
        {
            enemyArray = new List<Enemy>();
        }

        public void Update(GameTime gameTime)
        {
            PlayerUpdates(gameTime);
        }


        public void Draw(SpriteBatch spriteBatch)
        {
            player.Draw(spriteBatch);
        }



        private void PlayerUpdates(GameTime gameTime)
        {
            player.Update(gameTime);

            //if (player.HasCollided(goal))
            //{
            //    Game1.gameOver = true;
            //    Game1.game_state = GAME_STATE.END;
            //    ResetEntites();
            //}

            //if (player.lives <= 0)
            //{
            //    Game1.gameOver = false;
            //    Game1.game_state = GAME_STATE.END;
            //    ResetEntites();
            //}

        }
    }

    
}
