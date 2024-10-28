using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Pacman
{
    class AnimationManager
    {
        public static Rectangle[] playerEatAnimation =
        {
            new Rectangle(1 * Game1.spriteSize, Game1.spriteSize, Game1.spriteSize, Game1.spriteSize),
            new Rectangle(2 * Game1.spriteSize, Game1.spriteSize, Game1.spriteSize, Game1.spriteSize),
        };

    }
}
