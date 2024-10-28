using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Pacman
{
    public class TextureManager
    {

        public static Texture2D spriteSheet;
        public static Texture2D Tileset;
        public static void LoadTextures(ContentManager content)
        {
            spriteSheet = content.Load<Texture2D>("SpriteSheet");
            Tileset = content.Load<Texture2D>("Tileset"); 
        
        }
        }
}
