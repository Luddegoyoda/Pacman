using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Pacman
{
    public class Tile : GameObject
    {
       
        public bool notWalkable;
        Rectangle sourceRect;

        public Tile(Vector2 pos, Texture2D tex, bool notWalkable, Rectangle sourceRec) : base (pos,tex)
        {
            this.pos = pos;
            this.tex = tex;
            this.notWalkable = notWalkable;
            this.sourceRect = sourceRec;
        }


        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(TextureManager.Tileset, new Rectangle((int)pos.X, (int)pos.Y, Game1.tileSize, Game1.tileSize), sourceRect, Color.White);
        }
    }
}
