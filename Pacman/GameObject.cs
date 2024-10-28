using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SharpDX.Direct2D1.Effects;
using System.Collections.Generic;
using System.IO;

namespace Pacman
{
    
        public class GameObject
        {
            protected Vector2 pos;
            protected Texture2D tex;

            public GameObject(Vector2 pos, Texture2D tex)
            {
                this.pos = pos;
                this.tex = tex;

            }


            public virtual void Draw(SpriteBatch spriteBatch)
            {
                spriteBatch.Draw(tex, pos, Color.White);

            }
        }
    
}
