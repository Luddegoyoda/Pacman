using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.IO;

namespace Pacman
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;

        GamemodeManager gamemodeManager;
        public enum GAMESTATE {MENU, PLAYING, LOST, WON };
        public static GAMESTATE gameState;

        public static int spriteSize = 16;
        public static int tileSize = 32;

        string level;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            gamemodeManager = new GamemodeManager();
            graphics.PreferredBackBufferHeight = 1200;
            graphics.PreferredBackBufferWidth = 1200;
            graphics.ApplyChanges();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            TextureManager.LoadTextures(Content);
            // TODO: use this.Content to load your game content here
        }
        



        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            gamemodeManager.Update(gameTime);




            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            // TODO: Add your drawing code here

            spriteBatch.Begin();
            gamemodeManager.Draw(spriteBatch);
            spriteBatch.End();


            base.Draw(gameTime);
        }

    }
}
