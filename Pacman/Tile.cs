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

        public Tile(Vector2 pos, Texture2D tex, bool notWalkable) : base (pos,tex)
        {
            this.pos = pos;
            this.tex = tex;
            this.notWalkable = notWalkable;
        }

       
    }
}
