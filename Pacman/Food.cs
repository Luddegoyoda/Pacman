using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Pacman
{
    public class Food : CollisionObject
    {
        public bool isAlive;
        public Food(Vector2 pos, Texture2D tex, Rectangle hitbox) : base(pos, tex, hitbox)
        {
            this.pos = pos;
            this.tex = tex;
            this.hitbox = hitbox;
            isAlive= true;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(tex,hitbox,AnimationManager.foodTex, Color.White);
        }
    }
}
