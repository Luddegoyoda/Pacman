using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.IO;
using static Pacman.Game1;

namespace Pacman
{
    public class GamemodeManager
    {

        public static Tile[,] tileArray;
        public static int score;
        public static int foodEaten;

        public static int foodGoal;

        string fileName = "map.txt";
        bool mapCreated;
        bool menuCreated;
        Button startButton;

        public static List<Vector2> teleporters = new List<Vector2>();

        public GamemodeManager()
        {
            // Initialize the button with a texture and position.
            startButton = new Button(TextureManager.startButtonTex, new Vector2(500-TextureManager.startButtonTex.Width/2, 500 - TextureManager.startButtonTex.Height/2));
        }




        public void Update(GameTime gameTime)
        {
            
            switch (Game1.gameState)
            {
                case GAMESTATE.MENU:
                    if (!mapCreated)
                    {
                        CreateLevel(fileName);
                        mapCreated = true;
                    }
                    if (startButton.isPressed())
                    {
                        Game1.gameState = Game1.GAMESTATE.PLAYING;
                    }

                    break;
                case GAMESTATE.PLAYING:
                    if (foodEaten >= foodGoal)
                    {
                        Game1.gameState = GAMESTATE.WON;
                    }
                    break;
                case GAMESTATE.LOST:

                    break;
                case GAMESTATE.WON:

                    break;

            }
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
                    if (result[i][j] == 'R')//North sprite
                    {
                        tileArray[j, i] = new Tile(new Vector2(j * Game1.tileSize, i * Game1.tileSize), TextureManager.Tileset, false, AnimationManager.UpWallRec);
                    }
                    if (result[i][j] == 'B')//Bottom sprite
                    {
                        tileArray[j, i] = new Tile(new Vector2(j * Game1.tileSize, i * Game1.tileSize), TextureManager.Tileset, false, AnimationManager.DownWallTex);
                    }
                    if (result[i][j] == 'W')//West sprite
                    {
                        tileArray[j, i] = new Tile(new Vector2(j * Game1.tileSize, i * Game1.tileSize), TextureManager.Tileset, false, AnimationManager.WestWallTex);
                    }
                    if (result[i][j] == 'E')//East sprite
                    {
                        tileArray[j, i] = new Tile(new Vector2(j * Game1.tileSize, i * Game1.tileSize), TextureManager.Tileset, false, AnimationManager.EastWallTex);
                    }
                    if (result[i][j] == 'Q')//NorthWest sprite
                    {
                        tileArray[j, i] = new Tile(new Vector2(j * Game1.tileSize, i * Game1.tileSize), TextureManager.Tileset, false, AnimationManager.NWwallTex);
                    }
                    if (result[i][j] == 'H')//NorthEast sprite
                    {
                        tileArray[j, i] = new Tile(new Vector2(j * Game1.tileSize, i * Game1.tileSize), TextureManager.Tileset, false, AnimationManager.NEwallTex);
                    }
                    if (result[i][j] == 'Z')//SouthWest sprite
                    {
                        tileArray[j, i] = new Tile(new Vector2(j * Game1.tileSize, i * Game1.tileSize), TextureManager.Tileset, false, AnimationManager.SWwallTex);
                    }
                    if (result[i][j] == 'X')//SouthEast sprite
                    {
                        tileArray[j, i] = new Tile(new Vector2(j * Game1.tileSize, i * Game1.tileSize), TextureManager.Tileset, false, AnimationManager.SEwallTex);
                    }
                    if (result[i][j] == 'V')//void
                    {
                        tileArray[j, i] = new Tile(new Vector2(j * Game1.tileSize, i * Game1.tileSize), TextureManager.blackTex, true, new Rectangle(j * Game1.tileSize, i* Game1.tileSize, Game1.tileSize, Game1.tileSize));
                    }
                    if (result[i][j] == 'F')//Food (pellets) sprite
                    {
                        tileArray[j, i] = new Tile(new Vector2(j * Game1.tileSize, i * Game1.tileSize), TextureManager.blackTex, true, new Rectangle(j * Game1.tileSize, i * Game1.tileSize, Game1.tileSize, Game1.tileSize));
                        EntityManager.foodLocations.Add(tileArray[j, i].pos);
                    }
                    if (result[i][j] == 'M')//Mat sprite
                    {
                        tileArray[j, i] = new Tile(new Vector2(j * Game1.tileSize, i * Game1.tileSize), TextureManager.blackTex, true, new Rectangle(j * Game1.tileSize, i * Game1.tileSize, Game1.tileSize, Game1.tileSize));
                    }
                    if (result[i][j] == 'P')//player sprite
                    {
                        tileArray[j, i] = new Tile(new Vector2(j * Game1.tileSize, i * Game1.tileSize), TextureManager.blackTex, true, new Rectangle(j * Game1.tileSize, i * Game1.tileSize, Game1.tileSize, Game1.tileSize));
                    }
                    if (result[i][j] == 'G')//Ghosts sprite
                    {
                        tileArray[j, i] = new Tile(new Vector2(j * Game1.tileSize, i * Game1.tileSize), TextureManager.blackTex, true, new Rectangle(j * Game1.tileSize, i * Game1.tileSize, Game1.tileSize, Game1.tileSize));
                    }
                    if (result[i][j] == 'S')//Super pellet (Power up) sprite
                    {
                        tileArray[j, i] = new Tile(new Vector2(j * Game1.tileSize, i * Game1.tileSize), TextureManager.blackTex, true, new Rectangle(j * Game1.tileSize, i * Game1.tileSize, Game1.tileSize, Game1.tileSize));
                        EntityManager.powerupLocations.Add(tileArray[j, i].pos);
                    }
                    if (result[i][j] == 'T')//TP
                    {
                        var teleporterTile = new Tile(new Vector2(j * Game1.tileSize, i * Game1.tileSize), TextureManager.blackTex, true, new Rectangle(j * Game1.tileSize, i * Game1.tileSize, Game1.tileSize, Game1.tileSize));
                        tileArray[j, i] = teleporterTile;
                        teleporters.Add(teleporterTile.pos);
                    }
                    //else
                    //{
                    //    tileArray[j, i] = new Tile(new Vector2(j * Game1.tileSize, i * Game1.tileSize), TextureManager.blackTex, true, new Rectangle(0,0,Game1.tileSize,Game1.tileSize));
                    //}

                }
            }
        }

        public static bool GetTileAtPosition(Vector2 pos)
        {
            try
            {
                return tileArray[(int)pos.X / tileSize, (int)pos.Y / tileSize].notWalkable;
            }
            catch { return false; }

        }

        public static void SetTileWalkable(Vector2 pos)
        {  
            tileArray[(int)pos.X / tileSize, (int)pos.Y / tileSize] = new Tile(new Vector2((int)pos.Y / tileSize * Game1.tileSize, (int)pos.X / tileSize * Game1.tileSize),
               TextureManager.blackTex, true, new Rectangle((int)pos.Y / tileSize * Game1.tileSize, (int)pos.X / tileSize * Game1.tileSize, Game1.tileSize, Game1.tileSize));
        }

        public void Draw(SpriteBatch spriteBatch)
        {

            if (Game1.gameState == Game1.GAMESTATE.MENU)
            {
                // Draw menu background and start button
                spriteBatch.Draw(TextureManager.menuTex, new Rectangle(0, 0, 960, 1000), Color.White);
                startButton.Draw(spriteBatch);
            }   
            else if(Game1.gameState == Game1.GAMESTATE.PLAYING)
            {
                foreach (Tile tile in tileArray)
                {
                    tile.Draw(spriteBatch);
                }
            }
        }
    }
}
