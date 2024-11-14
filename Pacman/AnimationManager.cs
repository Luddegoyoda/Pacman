using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Pacman
{
    class AnimationManager //Acts more like a library
    {
        //player animations
        public static Rectangle[] playerEatAnimation =
        {
            new Rectangle(1 * Game1.spriteSize, 0*Game1.spriteSize, Game1.spriteSize, Game1.spriteSize),
            new Rectangle(2 * Game1.spriteSize, 0*Game1.spriteSize, Game1.spriteSize, Game1.spriteSize),
        };
        public static Rectangle UpWallRec = new Rectangle(0 * Game1.tileSize, 1 * Game1.tileSize, Game1.tileSize, Game1.tileSize);
        public static Rectangle DownWallTex = new Rectangle(1 * Game1.tileSize, 1 * Game1.tileSize, Game1.tileSize, Game1.tileSize);
        public static Rectangle WestWallTex = new Rectangle(2 * Game1.tileSize, 2 * Game1.tileSize, Game1.tileSize, Game1.tileSize);
        public static Rectangle EastWallTex = new Rectangle(1 * Game1.tileSize, 0 * Game1.tileSize, Game1.tileSize, Game1.tileSize);
        public static Rectangle NWwallTex = new Rectangle(1 * Game1.tileSize, 2 * Game1.tileSize, Game1.tileSize, Game1.tileSize);
        public static Rectangle NEwallTex = new Rectangle(0 * Game1.tileSize, 3 * Game1.tileSize, Game1.tileSize, Game1.tileSize);
        public static Rectangle SWwallTex = new Rectangle(3 * Game1.tileSize, 0 * Game1.tileSize, Game1.tileSize, Game1.tileSize);
        public static Rectangle SEwallTex = new Rectangle(2 * Game1.tileSize, 1 * Game1.tileSize, Game1.tileSize, Game1.tileSize);
        public static Rectangle foodTex = new Rectangle(3 * Game1.spriteSize, 0 * Game1.spriteSize, Game1.spriteSize / 2, Game1.spriteSize / 2);
        public static Rectangle powerUpTex = new Rectangle(3 * Game1.spriteSize, 0 * Game1.spriteSize, Game1.spriteSize, Game1.spriteSize);

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
        public static Rectangle[] pinkGhostLeft =
       {
            new Rectangle (Game1.spriteSize, 2 * Game1.spriteSize, Game1.spriteSize, Game1.spriteSize),
            new Rectangle (1 * Game1.spriteSize, 2 * Game1.spriteSize, Game1.spriteSize, Game1.spriteSize),
        };
        public static Rectangle[] pinkGhostRight =
        {
            new Rectangle (2 * Game1.spriteSize, 2 * Game1.spriteSize, Game1.spriteSize, Game1.spriteSize),
            new Rectangle (3 * Game1.spriteSize, 2 * Game1.spriteSize, Game1.spriteSize, Game1.spriteSize),
        };
        public static Rectangle[] pinkGhostUp =
        {
            new Rectangle (4 * Game1.spriteSize, 2 * Game1.spriteSize, Game1.spriteSize, Game1.spriteSize),
            new Rectangle (5 * Game1.spriteSize, 2 * Game1.spriteSize, Game1.spriteSize, Game1.spriteSize)
        };
        public static Rectangle[] pinkGhostDown =
        {
            new Rectangle (6 * Game1.spriteSize, 2 * Game1.spriteSize, Game1.spriteSize, Game1.spriteSize),
            new Rectangle (7 * Game1.spriteSize, 2 * Game1.spriteSize, Game1.spriteSize, Game1.spriteSize)
        };

        //blue ghost
        public static Rectangle[] cyanGhostLeft =
       {
            new Rectangle (Game1.spriteSize, 3 * Game1.spriteSize, Game1.spriteSize, Game1.spriteSize),
            new Rectangle (1 * Game1.spriteSize, 3 * Game1.spriteSize, Game1.spriteSize, Game1.spriteSize),
        };
        public static Rectangle[] orangeGhostRight =
        {
            new Rectangle (2 * Game1.spriteSize, 3 * Game1.spriteSize, Game1.spriteSize, Game1.spriteSize),
            new Rectangle (3 * Game1.spriteSize, 3 * Game1.spriteSize, Game1.spriteSize, Game1.spriteSize),
        };
        public static Rectangle[] cyanGhostUp =
        {
            new Rectangle (4 * Game1.spriteSize, 3 * Game1.spriteSize, Game1.spriteSize, Game1.spriteSize),
            new Rectangle (5 * Game1.spriteSize, 3 * Game1.spriteSize, Game1.spriteSize, Game1.spriteSize)
        };
        public static Rectangle[] cyanGhostDown =
        {
            new Rectangle (6 * Game1.spriteSize, 3 * Game1.spriteSize, Game1.spriteSize, Game1.spriteSize),
            new Rectangle (7 * Game1.spriteSize, 3 * Game1.spriteSize, Game1.spriteSize, Game1.spriteSize)
        };

        //Orange ghost
        public static Rectangle[] orangeGhostTexLeft =
        {
            new Rectangle(0 * Game1.spriteSize, 4*Game1.spriteSize, Game1.spriteSize, Game1.spriteSize),
            new Rectangle(1 * Game1.spriteSize, 4*Game1.spriteSize, Game1.spriteSize, Game1.spriteSize),
        };
        public static Rectangle[] orangeGhostTexRight =
        {
            new Rectangle(2 * Game1.spriteSize, 4*Game1.spriteSize, Game1.spriteSize, Game1.spriteSize),
            new Rectangle(3 * Game1.spriteSize, 4*Game1.spriteSize, Game1.spriteSize, Game1.spriteSize),
        };
        public static Rectangle[] orangeGhostTexUp =
        {
            new Rectangle(4 * Game1.spriteSize, 4*Game1.spriteSize, Game1.spriteSize, Game1.spriteSize),
            new Rectangle(5 * Game1.spriteSize, 4*Game1.spriteSize, Game1.spriteSize, Game1.spriteSize),
        };
        public static Rectangle[] orangeGhostTexDown =
        {
            new Rectangle(6 * Game1.spriteSize, 4*Game1.spriteSize, Game1.spriteSize, Game1.spriteSize),
            new Rectangle(7 * Game1.spriteSize, 4*Game1.spriteSize, Game1.spriteSize, Game1.spriteSize),
        };


        public static Rectangle[] scaredBlueGhostTex =
        {
            new Rectangle(0 * Game1.spriteSize, 5*Game1.spriteSize, Game1.spriteSize, Game1.spriteSize),
            new Rectangle(1 * Game1.spriteSize, 5*Game1.spriteSize, Game1.spriteSize, Game1.spriteSize),
        };

        public static Rectangle[] respawnEyesGhostTex =
        {
            new Rectangle(4 * Game1.spriteSize, 5*Game1.spriteSize, Game1.spriteSize, Game1.spriteSize),
            new Rectangle(5 * Game1.spriteSize, 5*Game1.spriteSize, Game1.spriteSize, Game1.spriteSize),
        };

    }
}
