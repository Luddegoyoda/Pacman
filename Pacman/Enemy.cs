using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Pacman
{
    public class Enemy : AnimatedObject
    {
        public Enemy(Vector2 pos, Texture2D tex, Rectangle rec) : base(pos, tex, rec)
        {
            this.pos = pos;
            this.tex = tex;
            this.hitbox = rec;
        }

        public override void Update(GameTime gameTime)
        {
        }

        public override void Draw(SpriteBatch spriteBatch)
        {

        }
    }
}
