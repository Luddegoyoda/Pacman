using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SharpDX.Direct2D1.Effects;
using SharpDX.Win32;
using System.Collections.Generic;
using System.IO;

namespace Pacman
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;

        public static Tile[,] tileArray;
        public static int tileSize = 16;

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

            base.Initialize();
        }

        protected override void LoadContent()
        {
            level = new string("Pac-man_map");
            spriteBatch = new SpriteBatch(GraphicsDevice);
            CreateLevel(level);
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
                    if (result[i][j] == 'N')//North sprite
                    {
                        tileArray[j, i] = new Tile(new Vector2(j * tileSize, i * tileSize), TextureManager.UpWallTex, true);
                    }
                    if (result[i][j] == 'B')//Bottom sprite
                    {
                        tileArray[j, i] = new Tile(new Vector2(j * tileSize, i * tileSize), TextureManager.DownWallTex, true);
                    }
                    if (result[i][j] == 'W')//West sprite
                    {
                        tileArray[j, i] = new Tile(new Vector2(j * tileSize, i * tileSize), TextureManager.WestWallTex, true);
                    }
                    if (result[i][j] == 'E')//East sprite
                    {
                        tileArray[j, i] = new Tile(new Vector2(j * tileSize, i * tileSize), TextureManager.EastWallTex, true);
                    }
                    if (result[i][j] == 'Q')//NorthWest sprite
                    {
                        tileArray[j, i] = new Tile(new Vector2(j * tileSize, i * tileSize), TextureManager.NWwallTex, true);
                    }
                    if (result[i][j] == 'H')//NorthEast sprite
                    {
                        tileArray[j, i] = new Tile(new Vector2(j * tileSize, i * tileSize), TextureManager.NEwallTex, true);
                    }
                    if (result[i][j] == 'Z')//SouthWest sprite
                    {
                        tileArray[j, i] = new Tile(new Vector2(j * tileSize, i * tileSize), TextureManager.SWwallTex, true);
                    }
                    if (result[i][j] == 'X')//SouthEast sprite
                    {
                        tileArray[j, i] = new Tile(new Vector2(j * tileSize, i * tileSize), TextureManager.SEwallTex, true);
                    }
                    if (result[i][j] == 'F')//Food (pellets) sprite
                    {
                        tileArray[j, i] = new Tile(new Vector2(j * tileSize, i * tileSize), TextureManager.FoodTex, false);
                    }
                    if (result[i][j] == 'M')//Mat sprite
                    {
                        tileArray[j, i] = new Tile(new Vector2(j * tileSize, i * tileSize), TextureManager.MatTex, false);
                    }
                    if (result[i][j] == 'P')//player sprite
                    {
                        tileArray[j, i] = new Tile(new Vector2(j * tileSize, i * tileSize), TextureManager.PlayerlTex, false);
                    }
                    if (result[i][j] == 'G')//Ghosts sprite
                    {
                        tileArray[j, i] = new Tile(new Vector2(j * tileSize, i * tileSize), TextureManager.GhostTex, false);
                    }
                    if (result[i][j] == 'S')//Super pellet (Power up) sprite
                    {
                        tileArray[j, i] = new Tile(new Vector2(j * tileSize, i * tileSize), TextureManager.Super_pelletTex, false);
                    }
                    else
                    {
                        tileArray[j, i] = new Tile(new Vector2(j * tileSize, i * tileSize), TextureManager.VoidTex, false);
                    }

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
