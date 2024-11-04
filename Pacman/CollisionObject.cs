using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SharpDX.Direct2D1.Effects;
using System.Collections.Generic;
using System.IO;

namespace Pacman
{
    public class CollisionObject : GameObject
    {
        public Rectangle hitbox;
        


        public CollisionObject(Vector2 pos, Texture2D tex, Rectangle hitbox) : base(pos, tex)
        { 
            this.hitbox = hitbox;
        }


        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(tex, hitbox, Color.White);
        }
    }
}
