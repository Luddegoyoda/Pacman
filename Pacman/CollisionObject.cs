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
        protected Rectangle rec;
        


        public CollisionObject(Vector2 pos, Texture2D tex, Rectangle rec) : base(pos, tex)
        { 
            this.rec = rec;


        }


        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(tex, rec, Color.White);
        }
    }
}
