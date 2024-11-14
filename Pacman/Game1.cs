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

        public enum GAMESTATE {MENU, PLAYING, LOST, WON };
        public static GAMESTATE gameState = 0;

        public static int screenWidth = 960;


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

            if (gameState == GAMESTATE.PLAYING)
            {
                entityManager.Update(gameTime);
            }
            if (gameState == GAMESTATE.MENU)
            {
                
                GamemodeManager.score = 0;
            }



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

        public static void SaveScoreToFile()
        {
            List<string> scores = ReadScoreFromFile();
            int[] higherThanIndex = new int[5];
            StreamWriter sw = new StreamWriter("highscores.txt");
            for (int i = 1; i < scores.Count + 1; i++)
            {
                if (GamemodeManager.score > int.Parse(scores[^i]))
                {
                    higherThanIndex[i-1] = i;
                    continue;
                }
                
            }
            int savedIndex = 0;
            for (int i = 0; i < higherThanIndex.Length; i++)
            {
                if (i == higherThanIndex.Length-1)
                {
                    savedIndex = higherThanIndex[i];
                    break;
                }
                if (higherThanIndex[i] > higherThanIndex[i+1])
                {
                    savedIndex = higherThanIndex[i];
                    higherThanIndex[i + 1] = higherThanIndex[i];
                }
            }
            if (savedIndex != 0)
            {
                scores[^savedIndex] = GamemodeManager.score.ToString();
                
            }
            foreach (string hscore in scores)
            {
                sw.WriteLine(hscore);
            }
            sw.Close();


        }

        public static List<string> ReadScoreFromFile()
        {
            List<string> scores = new List<string>();
            string file = "highscores.txt";
            if (File.Exists(file))
            {
                StreamReader sr = new StreamReader(file);
                while (!sr.EndOfStream)
                {
                    scores.Add(sr.ReadLine());
                }
                sr.Close();
            }
            return scores;
        }
    }
}
