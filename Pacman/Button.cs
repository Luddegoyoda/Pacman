using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Pacman
{
    public class Button
    {
        private Texture2D tex;
        private Vector2 pos;
        private Rectangle buttonRectangle;
        private MouseState currentMouseState, previousMouseState;
        private Color buttonColor;

        public Button(Texture2D tex, Vector2 pos)
        {
            this.tex = tex;
            this.pos = pos;
            buttonColor = Color.White;
            buttonRectangle = new Rectangle((int)pos.X, (int)pos.Y, tex.Width, tex.Height);
        }

        public bool isPressed()
        {
            bool pressed = false;
            currentMouseState = Mouse.GetState();

            if (buttonRectangle.Contains(currentMouseState.Position))
            {
                buttonColor = Color.Gray; // Highlight on hover

                if (currentMouseState.LeftButton == ButtonState.Pressed && previousMouseState.LeftButton == ButtonState.Released && pressed == false)
                {
                    previousMouseState = currentMouseState;
                    pressed = true;
                    return true;
                }
                else if (currentMouseState.LeftButton == ButtonState.Pressed && previousMouseState.LeftButton == ButtonState.Released && pressed == true)
                {
                    previousMouseState = currentMouseState;
                    pressed = false;
                    return false;
                }
            }
            else
            {
                buttonColor = Color.White; // Reset color when not hovering
            }

            previousMouseState = currentMouseState; // Always update previous state
            return false;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(tex, pos, buttonColor);
        }
    }
}
