using ICSharpCode.AvalonEdit.Utils;
using Raylib_cs;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurboMapReader;

namespace Diablo
{


    class TheGame
    {
        private static Texture2D textureAtlas;
        private static Texture2D textureAtlas2;
        static TiledMap? kartta = new TiledMap();



        public static void gameinit()
        {
            Image imageAtlas = Raylib.LoadImage("Props.png");
            textureAtlas = Raylib.LoadTextureFromImage(imageAtlas);

            Image TilesAtlas = Raylib.LoadImage("Tiles.png");
            textureAtlas2 = Raylib.LoadTextureFromImage(TilesAtlas);

            kartta = MapReader.LoadMapFromFile(@"Map..tmj");

        }
        public static void Draw()
        {
            bool useTilesAtlas;
            Raylib.BeginDrawing();

            for (int layer = 1; layer < kartta.layers.Count; layer++)
            {
                if (layer == 1 || layer == 2)
                {
                    useTilesAtlas = true;
                }
                else
                {
                    useTilesAtlas = false;
                }


                int rows = kartta.layers[layer].height;
                for (int row = 0; row < rows; row++)
                {
                    for (int col = 0; col < kartta.layers[layer].width; col++)
                    {
                        int tileId = kartta.layers[layer].data[row * kartta.layers[layer].width + col];
                        int x = col * kartta.tilewidth;
                        int y = row * kartta.tileheight;
                        if (kartta.layers[layer].data[row * kartta.layers[layer].width + col] != 0)
                            DrawTile(x, y, tileId - 1, useTilesAtlas);
                    }
                }
            }
            Raylib.EndDrawing();
        
        }

        static void DrawTile(int x, int y, int TileId, bool useTilesAtlas)
        {
            int tilesperrow = kartta.tilesetFiles[0].columns;

            float rowf = (TileId / tilesperrow);

            int row = Convert.ToInt32(rowf);
            int column = TileId % tilesperrow;

            if (useTilesAtlas) 
            {
                Raylib.DrawTextureRec(textureAtlas2, new Rectangle(x, y, kartta.tilewidth, kartta.tileheight), new System.Numerics.Vector2(x, y), Color.White);
            }
            else
            {
                Raylib.DrawTextureRec(textureAtlas, new Rectangle(x, y, kartta.tilewidth, kartta.tileheight), new System.Numerics.Vector2(x, y), Color.White);
            }
        }

    }
    
}
