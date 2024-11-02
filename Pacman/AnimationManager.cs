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
            new Rectangle(1 * Game1.spriteSize, 0*Game1.spriteSize, Game1.spriteSize, Game1.spriteSize),
            new Rectangle(2 * Game1.spriteSize, 0*Game1.spriteSize, Game1.spriteSize, Game1.spriteSize),
        };

        public static Rectangle UpWallRec = new Rectangle(1 * Game1.tileSize, 3 * Game1.tileSize, Game1.tileSize, Game1.tileSize);
        public static Rectangle DownWallTex = new Rectangle(3 * Game1.tileSize, 1 * Game1.tileSize, Game1.tileSize, Game1.tileSize);
        public static Rectangle WestWallTex = new Rectangle(3 * Game1.tileSize, 2 * Game1.tileSize, Game1.tileSize, Game1.tileSize);
        public static Rectangle EastWallTex = new Rectangle(2 * Game1.tileSize, 3 * Game1.tileSize, Game1.tileSize, Game1.tileSize);
        public static Rectangle NWwallTex = new Rectangle(1 * Game1.tileSize, 2 * Game1.tileSize, Game1.tileSize, Game1.tileSize);
        public static Rectangle NEwallTex = new Rectangle(0 * Game1.tileSize, 3 * Game1.tileSize, Game1.tileSize, Game1.tileSize);
        public static Rectangle SWwallTex = new Rectangle(0 * Game1.tileSize, 3 * Game1.tileSize, Game1.tileSize, Game1.tileSize);
        public static Rectangle SEwallTex = new Rectangle(2 * Game1.tileSize, 1 * Game1.tileSize, Game1.tileSize, Game1.tileSize);

    }
}
