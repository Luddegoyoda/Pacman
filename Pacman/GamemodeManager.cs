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

        string fileName = "map.txt";
        bool mapCreated;

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
                    break;
                case GAMESTATE.PLAYING:

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
                    if (result[i][j] == 'N')//North sprite
                    {
                        tileArray[j, i] = new Tile(new Vector2(j * Game1.tileSize, i * Game1.tileSize), TextureManager.Tileset, true, AnimationManager.UpWallRec);
                    }
                    if (result[i][j] == 'B')//Bottom sprite
                    {
                        tileArray[j, i] = new Tile(new Vector2(j * Game1.tileSize, i * Game1.tileSize), TextureManager.Tileset, true, AnimationManager.DownWallTex);
                    }
                    if (result[i][j] == 'W')//West sprite
                    {
                        tileArray[j, i] = new Tile(new Vector2(j * Game1.tileSize, i * Game1.tileSize), TextureManager.Tileset, true, AnimationManager.WestWallTex);
                    }
                    if (result[i][j] == 'E')//East sprite
                    {
                        tileArray[j, i] = new Tile(new Vector2(j * Game1.tileSize, i * Game1.tileSize), TextureManager.Tileset, true, AnimationManager.EastWallTex);
                    }
                    if (result[i][j] == 'Q')//NorthWest sprite
                    {
                        tileArray[j, i] = new Tile(new Vector2(j * Game1.tileSize, i * Game1.tileSize), TextureManager.Tileset, true, AnimationManager.NWwallTex);
                    }
                    if (result[i][j] == 'H')//NorthEast sprite
                    {
                        tileArray[j, i] = new Tile(new Vector2(j * Game1.tileSize, i * Game1.tileSize), TextureManager.Tileset, true, AnimationManager.NEwallTex);
                    }
                    if (result[i][j] == 'Z')//SouthWest sprite
                    {
                        tileArray[j, i] = new Tile(new Vector2(j * Game1.tileSize, i * Game1.tileSize), TextureManager.Tileset, true, AnimationManager.SWwallTex);
                    }
                    if (result[i][j] == 'X')//SouthEast sprite
                    {
                        tileArray[j, i] = new Tile(new Vector2(j * Game1.tileSize, i * Game1.tileSize), TextureManager.Tileset, true, AnimationManager.SEwallTex);
                    }
                    if (result[i][j] == 'V')//void
                    {
                        tileArray[j, i] = new Tile(new Vector2(j * Game1.tileSize, i * Game1.tileSize), TextureManager.blackTex, true, new Rectangle(j * Game1.tileSize, i* Game1.tileSize, Game1.tileSize, Game1.tileSize));
                    }
                    if (result[i][j] == 'F')//Food (pellets) sprite
                    {
                        tileArray[j, i] = new Tile(new Vector2(j * Game1.tileSize, i * Game1.tileSize), TextureManager.blackTex, true, new Rectangle(j * Game1.tileSize, i * Game1.tileSize, Game1.tileSize, Game1.tileSize));
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
                    }
                    if (result[i][j] == 'T')//TP
                    {
                        tileArray[j, i] = new Tile(new Vector2(j * Game1.tileSize, i * Game1.tileSize), TextureManager.blackTex, true, new Rectangle(j * Game1.tileSize, i * Game1.tileSize, Game1.tileSize, Game1.tileSize));
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
            return tileArray[(int)pos.X / tileSize, (int)pos.Y / tileSize].notWalkable;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (Tile tile in tileArray)
            {
                tile.Draw(spriteBatch);
            }
        }
    }
}
