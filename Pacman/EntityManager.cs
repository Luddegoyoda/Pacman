using Microsoft.Xna.Framework;
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


        public void Update(GameTime gameTime)
        {
            player.Update(gameTime);
        }


        public void Draw(GameTime gameTime)
        {
            player.Update(gameTime);
        }
    }

    
}
