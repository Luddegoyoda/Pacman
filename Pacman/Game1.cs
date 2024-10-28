using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SharpDX.Direct2D1.Effects;
using System.Collections.Generic;
using System.IO;

namespace Pacman
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        public static Tile[,] tileArray;
        public static int tileSize = 50;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
        }
        public List<string> ReadFromFile(string fileName)
        {
            StreamReader streamReader = new StreamReader(fileName);
            List<string> result = new List<string>();

            while (!streamReader.EndOfStream)
            {
                string line = streamReader.ReadLine();
                result.Add(line);
                System.Diagnostics.Debug.WriteLine(line);
            }
            streamReader.Close();

            return result;
        }

        public void CreateLevel(string fileName)
        {
            List<string> result = ReadFromFile(fileName);

            tileArray = new Tile[result[0].Length, result.Count];

            for (int i = 0; i < result.Count; i++)
            {
                for (int j = 0; j < result[0].Length; j++)
                {
                    //if (result[i][j] == '')
                    //{
                    //    tileArray[j, i] = new Tile(new Vector2(j * tileSize, i * tileSize), TextureManager.wallTex, true);
                    //}
                   
                }
            }
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }

        //public static bool GetTileAtPosition(Vector2 pos)
        //{
        //    return tileArray[(int)pos.X / tileSize, (int)pos.Y / tileSize].NotWalkable;
        //}
    }
}
