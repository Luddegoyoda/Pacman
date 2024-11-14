using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Pacman
{
    public class Item : CollisionObject
    {
        public bool isAlive;
        public int itemNumber;
        public int value;
        public Item(Vector2 pos, Texture2D tex, Rectangle hitbox, int itemNumber) : base(pos, tex, hitbox)
        {
            this.pos = pos;
            this.tex = tex;
            this.hitbox = hitbox;
            this.itemNumber = itemNumber;
            isAlive = true;
            value = itemNumber * 100;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (isAlive)
            {
                spriteBatch.Draw(tex, hitbox, new Rectangle(itemNumber * Game1.spriteSize, 6 * Game1.spriteSize, Game1.spriteSize,Game1.spriteSize), Color.White);
            }
        }
    }
}
