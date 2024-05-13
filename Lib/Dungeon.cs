using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib
{
    public class Dungeon
    {
        public static int MapWidth { get; set; }
        public static int MapHeight { get; set; }

        public int[,] Map;

        private static int seed;

        private Random _mapRandom;

        [Range(0,100)]
        private int _FillingPercentage;

        public Dungeon()
        {
            seed = Environment.TickCount;
            _mapRandom = new Random(seed);
            MapWidth = 25;
            MapHeight = 25;
            _FillingPercentage = 50;
            Map = new int[MapWidth, MapHeight];


        }

        public Dungeon(int width, int height)
        {
            seed = Environment.TickCount;
            _mapRandom = new Random(seed);
            MapWidth = width;
            MapHeight = height;
            _FillingPercentage = 60;
            Map = new int[MapWidth, MapHeight];
        }

        public Dungeon(int mapseed)
        {
            seed = mapseed;
            _mapRandom = new Random(mapseed);
            SimplexNoise.Noise.Seed = mapseed;
            _FillingPercentage = 50;
            MapWidth = 25;
            MapHeight = 25;
            Map = new int[MapWidth, MapHeight];
        }

        public void GenerateMap()
        {
            Console.WriteLine(MapWidth + " x " + MapHeight);
            GenerateNoise();


            for (int i = 0; i < 5; i++)
            {
                SmoothMap();
            }

            RemoveSecludedCells();
            RecoverEdgeCells();
        }

        private void GenerateNoise()
        {

            float[,] vals = SimplexNoise.Noise.Calc2D(MapHeight, MapWidth, 0.1f);

            for (int x = 1; x < MapWidth; x++)
            {
                for (int y = 1; y < MapHeight; y++)
                {
                    //Console.WriteLine("x " + x + " y " + y);
                    // Map[x, y] = (_mapRandom.Next(0, 100) < _FillingPercentage) ? 1 : 0;
                    Map[x,y] = vals[x, y] < 255 * (_FillingPercentage * 0.01) ? 1 : 0;
                    
                }
            }

        }

        private int getNeighborsCellCount(int x, int y, int[,] map)
        {
            int neighbors = 0;
            for (int i = -1;i <= 1; i++)
            {
                for (int j = -1;j <= 1; j++)
                {
                    neighbors += map[i + x, j + y];
                }
            }
            neighbors -= map[x, y];
            return neighbors;
        }

        private void SmoothMap()
        {
            for (int x = 1; x < MapWidth - 1; x++)
            {
                for(int y = 1;y < MapHeight - 1; y++)
                {
                    int neighbors = getNeighborsCellCount(x, y, Map);

                    if (neighbors > 4) 
                    {
                        Map[x,y] = 1;
                        
                    }
                    else if (neighbors < 4)
                    {
                        Map[x, y] = 0;
                    }
                }
            }
        }

        private void RemoveSecludedCells()
        {
            for (int x = 1; x < MapWidth - 1; x++)
            {
                for (int y = 1; y < MapHeight -1; y++)
                {
                    Map[x, y] = (getNeighborsCellCount(x, y, Map) <= 0) ? 0 : Map[x, y];
                }
            }
        }

        private void RecoverEdgeCells()
        {
            for (int x = 1; x < MapWidth - 1; x++)
            {
                for (int y = 1; y < MapHeight - 1; y++)
                {
                    if (x == 0 || x == MapWidth - 1 || y == 0 || y == MapHeight - 1)
                        Map[x, y] = 0;
                }
            }
        }




    }
}
