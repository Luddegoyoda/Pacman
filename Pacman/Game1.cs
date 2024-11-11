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
        EntityManager entityManager;

        Menu menu;
        public enum GAMESTATE {MENU, PLAYING, LOST, WON };
        public static GAMESTATE gameState = 0;

        public static int spriteSize = 16;
        public static int tileSize = 32;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            
            graphics.PreferredBackBufferHeight = 1000;
            graphics.PreferredBackBufferWidth = 1000;
            graphics.ApplyChanges();

            

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            TextureManager.LoadTextures(Content);
            SoundManager.LoadAllSounds(Content);
            gamemodeManager = new GamemodeManager();
            entityManager = new EntityManager();
            entityManager.player = new Player(new Vector2(400, 400), TextureManager.spriteSheet, new Rectangle(0, 0, spriteSize, spriteSize));

            // TODO: use this.Content to load your game content here
        }
        



        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            gamemodeManager.Update(gameTime);

            entityManager.Update(gameTime);


            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            // TODO: Add your drawing code here

            spriteBatch.Begin();


            gamemodeManager.Draw(spriteBatch);
            if (gameState == GAMESTATE.PLAYING)
            {
                entityManager.Draw(spriteBatch);
            }
            spriteBatch.End();


            base.Draw(gameTime);
        }

    }
}
