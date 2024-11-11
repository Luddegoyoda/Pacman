using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Pacman
{
    public class Menu
    {
        Vector2 buttonPos;
        Button startButton;
        Rectangle menuRectangle;
        
        public Menu()
        {
            buttonPos = new Vector2(0, 50);
            startButton = new Button(TextureManager.startButtonTex, buttonPos);
            menuRectangle = new Rectangle(0, 0, 1000, 1000);
            
        }


        public void Update(GameTime gameTime)
        {
            if (startButton.isPressed()) 
            {
                Game1.gameState +=1;
            }
        }

        public void Draw(SpriteBatch spriteBatch) 
        {
            spriteBatch.Draw(TextureManager.menuTex, menuRectangle, Color.White);
            startButton.Draw(spriteBatch);

        }
    }
}
