using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lib.Enums;

namespace Lib
{
    public class Dungeon
    {
        public static int MapWidth { get; set; }
        public static int MapHeight { get; set; }

        public int[,] Map;
        //public IEntity[,] Entities;
        public List<IEntity> Entites = new List<IEntity>();

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
            _FillingPercentage = 35;
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

        public void MoveEntity(IEntity entity, WalkingDirection direction)
        {
            

            IEntity ent = Entites.Find(toFind => toFind.Equals(entity));

            if (ent is not null)
            {
                int x = ent.Position.X;
                int y = ent.Position.Y;

                //Console.WriteLine(Map[x - 1, y + 1] + "" + Map[x, y + 1] + Map[x + 1, y + 1]);
                //Console.WriteLine(Map[x - 1, y] + "P" + Map[x + 1, y]);
                //Console.WriteLine(Map[x - 1, y - 1] + "" + Map[x, y - 1] + Map[x + 1, y - 1]);

                switch (direction)
                {
                    case WalkingDirection.North: { 
                            if (y-1 > 0 && !Entites.Any(check => check.Position.Equals(new System.Drawing.Point(x,y+1))) && Map[x,y - 1] == 1)
                            {
                                ent.Move(WalkingDirection.North);
                            }
                            else throw new Exceptions.IllegalMovementException();
                            break; 
                        };
                    case WalkingDirection.South:
                        {
                            if (y + 1  < MapHeight && !Entites.Any(check => check.Position.Equals(new System.Drawing.Point(x, y - 1))) && Map[x, y + 1] == 1)
                            {
                                ent.Move(WalkingDirection.South);
                            }
                            else throw new Exceptions.IllegalMovementException();
                            break;
                        };
                    case WalkingDirection.East:
                        {
                            if (x + 1 < MapWidth && !Entites.Any(check => check.Position.Equals(new System.Drawing.Point(x + 1, y))) && Map[x + 1, y] == 1)
                            {
                                ent.Move(WalkingDirection.East);
                            }
                            else throw new Exceptions.IllegalMovementException();
                            break;
                        };
                    case WalkingDirection.West:
                        {
                            if (x - 1 > 0 && !Entites.Any(check => check.Position.Equals(new System.Drawing.Point(x - 1, y))) && Map[x - 1, y] == 1)
                            {
                                ent.Move(WalkingDirection.West);
                            }
                            else throw new Exceptions.IllegalMovementException();
                            break;
                        };
                        default: { throw  new Exceptions.IllegalMovementException();  }
                }
            }

            
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
            PutEntities();
            

        }

        private void PutEntities()
        {
            Random rand = new Random();
            int xrand = rand.Next(MapWidth);
            int yrand = rand.Next(MapHeight);

            if (Map[xrand, yrand] == 1)
            {
                Entites.Add(new Player()
                {
                    Name = "Playa",
                    Level = 1,
                    MaxHealth = 20,
                    CurHealth = 20,
                    MaxMana = 5,
                    CurMana = 5,
                    Dexterity = 3,
                    PhysicalResist = 1,
                    MagicResist = 1,
                    FireResist = 1,
                    Strength = 5,
                    Experience = 0,
                    MaxItemWeight = 20,
                    Position = new System.Drawing.Point(xrand, yrand),
                    Items = new List<Item>()
                });
                Console.WriteLine($"Player spawned on {xrand}, {yrand}");
            }
            else PutEntities();
        }

        public Player GetPlayer()
        {
            return Entites.OfType<Player>().FirstOrDefault();
        }

        private void GenerateNoise()
        {

            SimplexNoise.Noise.Seed = seed;
            float[,] vals = SimplexNoise.Noise.Calc2D(MapWidth, MapHeight, 0.1f);
            Console.WriteLine($"vals width {vals.GetLength(0)} vals height {vals.GetLength(1)}");

            for (int x = 1; x < MapWidth; x++)
            {
                for (int y = 1; y < MapHeight; y++)
                {
                    //Console.WriteLine("x " + x + " y " + y);
                    // Map[x, y] = (_mapRandom.Next(0, 100) < _FillingPercentage) ? 1 : 0;
                    Console.WriteLine($"x {x} y {y}");
                    //0 is wall, 1 is floor
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
