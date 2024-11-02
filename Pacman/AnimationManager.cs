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
        //player animations
        public static Rectangle[] playerEatAnimation =
        {
            new Rectangle(1 * Game1.spriteSize, Game1.spriteSize, Game1.spriteSize, Game1.spriteSize),
            new Rectangle(2 * Game1.spriteSize, Game1.spriteSize, Game1.spriteSize, Game1.spriteSize),
        };




















        //ghost animations
        //red ghost
        public static Rectangle[] redGhostLeft =
        {
            new Rectangle (Game1.spriteSize, 1 * Game1.spriteSize, Game1.spriteSize, Game1.spriteSize),
            new Rectangle (1 * Game1.spriteSize, 1 * Game1.spriteSize, Game1.spriteSize, Game1.spriteSize),
        };
        public static Rectangle[] redGhostRight =
        {
            new Rectangle (2 * Game1.spriteSize, 1 * Game1.spriteSize, Game1.spriteSize, Game1.spriteSize),
            new Rectangle (3 * Game1.spriteSize, 1 * Game1.spriteSize, Game1.spriteSize, Game1.spriteSize),
        };
        public static Rectangle[] redGhostUp =
        {
            new Rectangle (4 * Game1.spriteSize, 1 * Game1.spriteSize, Game1.spriteSize, Game1.spriteSize),
            new Rectangle (5 * Game1.spriteSize, 1 * Game1.spriteSize, Game1.spriteSize, Game1.spriteSize)
        };
        public static Rectangle[] redGhostDown =
        {
            new Rectangle (6 * Game1.spriteSize, 1 * Game1.spriteSize, Game1.spriteSize, Game1.spriteSize),
            new Rectangle (7 * Game1.spriteSize, 1 * Game1.spriteSize, Game1.spriteSize, Game1.spriteSize)
        };

        //purple ghost
        public static Rectangle[] purpleGhostLeft =
       {
            new Rectangle (Game1.spriteSize, 2 * Game1.spriteSize, Game1.spriteSize, Game1.spriteSize),
            new Rectangle (1 * Game1.spriteSize, 2 * Game1.spriteSize, Game1.spriteSize, Game1.spriteSize),
        };
        public static Rectangle[] purpleGhostRight =
        {
            new Rectangle (2 * Game1.spriteSize, 2 * Game1.spriteSize, Game1.spriteSize, Game1.spriteSize),
            new Rectangle (3 * Game1.spriteSize, 2 * Game1.spriteSize, Game1.spriteSize, Game1.spriteSize),
        };
        public static Rectangle[] purpleGhostUp =
        {
            new Rectangle (4 * Game1.spriteSize, 2 * Game1.spriteSize, Game1.spriteSize, Game1.spriteSize),
            new Rectangle (5 * Game1.spriteSize, 2 * Game1.spriteSize, Game1.spriteSize, Game1.spriteSize)
        };
        public static Rectangle[] purpleGhostDown =
        {
            new Rectangle (6 * Game1.spriteSize, 2 * Game1.spriteSize, Game1.spriteSize, Game1.spriteSize),
            new Rectangle (7 * Game1.spriteSize, 2 * Game1.spriteSize, Game1.spriteSize, Game1.spriteSize)
        };

        //blue ghost
        public static Rectangle[] blueGhostLeft =
       {
            new Rectangle (Game1.spriteSize, 3 * Game1.spriteSize, Game1.spriteSize, Game1.spriteSize),
            new Rectangle (1 * Game1.spriteSize, 3 * Game1.spriteSize, Game1.spriteSize, Game1.spriteSize),
        };
        public static Rectangle[] blueGhostRight =
        {
            new Rectangle (2 * Game1.spriteSize, 3 * Game1.spriteSize, Game1.spriteSize, Game1.spriteSize),
            new Rectangle (3 * Game1.spriteSize, 3 * Game1.spriteSize, Game1.spriteSize, Game1.spriteSize),
        };
        public static Rectangle[] blueGhostUp =
        {
            new Rectangle (4 * Game1.spriteSize, 3 * Game1.spriteSize, Game1.spriteSize, Game1.spriteSize),
            new Rectangle (5 * Game1.spriteSize, 3 * Game1.spriteSize, Game1.spriteSize, Game1.spriteSize)
        };
        public static Rectangle[] blueGhostDown =
        {
            new Rectangle (6 * Game1.spriteSize, 3 * Game1.spriteSize, Game1.spriteSize, Game1.spriteSize),
            new Rectangle (7 * Game1.spriteSize, 3 * Game1.spriteSize, Game1.spriteSize, Game1.spriteSize)
        };

        // orange ghost
        public static Rectangle[] orangeGhostLeft =
       {
            new Rectangle (Game1.spriteSize, 4 * Game1.spriteSize, Game1.spriteSize, Game1.spriteSize),
            new Rectangle (1 * Game1.spriteSize, 4 * Game1.spriteSize, Game1.spriteSize, Game1.spriteSize),
        };
        public static Rectangle[] orangeGhostRight =
        {
            new Rectangle (2 * Game1.spriteSize, 4 * Game1.spriteSize, Game1.spriteSize, Game1.spriteSize),
            new Rectangle (3 * Game1.spriteSize, 4 * Game1.spriteSize, Game1.spriteSize, Game1.spriteSize),
        };
        public static Rectangle[] orangeGhostUp =
        {
            new Rectangle (4 * Game1.spriteSize, 4 * Game1.spriteSize, Game1.spriteSize, Game1.spriteSize),
            new Rectangle (5 * Game1.spriteSize, 4 * Game1.spriteSize, Game1.spriteSize, Game1.spriteSize)
        };
        public static Rectangle[] orangeGhostDown =
        {
            new Rectangle (6 * Game1.spriteSize, 4 * Game1.spriteSize, Game1.spriteSize, Game1.spriteSize),
            new Rectangle (7 * Game1.spriteSize, 4 * Game1.spriteSize, Game1.spriteSize, Game1.spriteSize)
        };

        //scared ghost

        //alive scared ghost
        public static Rectangle[] aliveScaredGhost =
        {
            new Rectangle (Game1.spriteSize, 5 * Game1.spriteSize, Game1.spriteSize, Game1.spriteSize),
            new Rectangle (1 * Game1.spriteSize, 5 * Game1.spriteSize, Game1.spriteSize, Game1.spriteSize),
        };

        // dead scared ghost
        public static Rectangle[] deadScaredGhost =
        {
            new Rectangle (2 * Game1.spriteSize, 5 * Game1.spriteSize, Game1.spriteSize, Game1.spriteSize),
            new Rectangle (3 * Game1.spriteSize, 5 * Game1.spriteSize, Game1.spriteSize, Game1.spriteSize),
        };

        //reviving ghost
        public static Rectangle[] revivingGhost =
        {
            new Rectangle (4 * Game1.spriteSize, 5 * Game1.spriteSize, Game1.spriteSize, Game1.spriteSize),
            new Rectangle (5 * Game1.spriteSize, 5 * Game1.spriteSize, Game1.spriteSize, Game1.spriteSize),
            new Rectangle (6 * Game1.spriteSize, 5 * Game1.spriteSize, Game1.spriteSize, Game1.spriteSize),
            new Rectangle (7 * Game1.spriteSize, 5 * Game1.spriteSize, Game1.spriteSize, Game1.spriteSize),
        };

        //fruit

        //cherry
        public static Rectangle[] cherry =
        {
            new Rectangle (Game1.spriteSize, 6 * Game1.spriteSize, Game1.spriteSize, Game1.spriteSize),
        };

        //strawberry
        public static Rectangle[] strawberry =
        {
            new Rectangle (1 * Game1.spriteSize, 6 * Game1.spriteSize, Game1.spriteSize, Game1.spriteSize),
        };

        //pumpkin?
        public static Rectangle[] pumpkin =
        {
            new Rectangle (2 * Game1.spriteSize, 6 * Game1.spriteSize, Game1.spriteSize, Game1.spriteSize),
        };

        //apple
        public static Rectangle[] apple =
        {
            new Rectangle (3 * Game1.spriteSize, 6 * Game1.spriteSize, Game1.spriteSize, Game1.spriteSize),
        };

        //melon
        public static Rectangle[] melon =
        {
            new Rectangle (4 * Game1.spriteSize, 6 * Game1.spriteSize, Game1.spriteSize, Game1.spriteSize),
        };

        //crown
        public static Rectangle[] crown =
        {
            new Rectangle (5 * Game1.spriteSize, 6 * Game1.spriteSize, Game1.spriteSize, Game1.spriteSize),
        };

        //bell
        public static Rectangle[] bell =
        {
            new Rectangle (6 * Game1.spriteSize, 6 * Game1.spriteSize, Game1.spriteSize, Game1.spriteSize),
        };

        //key
        public static Rectangle[] key =
        {
            new Rectangle (7 * Game1.spriteSize, 6 * Game1.spriteSize, Game1.spriteSize, Game1.spriteSize),
        };
    }
}
