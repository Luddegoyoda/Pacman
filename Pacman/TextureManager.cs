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
        public static Texture2D blackTex;
        public static Texture2D menuTex;
        public static Texture2D startButtonTex;
        public static Texture2D victory;
        public static Texture2D gameOver;
        public static Texture2D level1;
        public static Texture2D level2;
        public static SpriteFont font;
        
        public static void LoadTextures(ContentManager content)
        {
            startButtonTex = content.Load<Texture2D>("Startknapp");
            spriteSheet = content.Load<Texture2D>("SpriteSheet");
            Tileset = content.Load<Texture2D>("Tileset");
            blackTex = content.Load<Texture2D>("blackTex"); 
            menuTex = content.Load<Texture2D>("Pacman menu");
            victory = content.Load<Texture2D>("Pacman Victory");
            gameOver = content.Load<Texture2D>("Game Over");
            level1 = content.Load<Texture2D>("Level 1");
            level2 = content.Load<Texture2D>("Level 2");
            font = content.Load<SpriteFont>("font"); 
            

        
        }
    }
}
