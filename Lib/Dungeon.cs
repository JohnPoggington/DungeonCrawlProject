using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Lib.Enums;
using Lib.MapObjects;
using Lib.Monsters;

namespace Lib
{
    public class Dungeon
    {
        public static int MapWidth { get; set; }
        public static int MapHeight { get; set; }

        public int[,] Map;
        //public IEntity[,] Entities;
        public List<IEntity> Entites = new List<IEntity>();

        public bool[,] VisMap;

        private static int seed;

        private Random _mapRandom;

        private static List<String> MediumLevelMonsters = ["Orc", "Zombie", "Earthworm", "Exploder"];

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
            VisMap = new bool[MapWidth, MapHeight];
            FillTwodimensionalArray<bool>(VisMap, false);



        }

        public Dungeon(int width, int height)
        {
            seed = Environment.TickCount;
            
            _mapRandom = new Random(seed);
            MapWidth = width;
            MapHeight = height;
            _FillingPercentage = 60;
            Map = new int[MapWidth, MapHeight];
            VisMap = new bool[MapWidth, MapHeight];
            FillTwodimensionalArray<bool>(VisMap, false);
            
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
            VisMap = new bool[MapWidth, MapHeight];
            FillTwodimensionalArray<bool>(VisMap, false);

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
                            if (y-1 > 0 && !Entites.Any(check => check.Position.Equals(new System.Drawing.Point(x,y-1))) && Map[x,y - 1] == 1)
                            {
                                 ent.Move(WalkingDirection.North);
                            }
                            else if (Entites.Where(e => e is Spikes).Any(check => check.Position.Equals(new System.Drawing.Point(x, y - 1))))
                            {
                                if (ent is Player)
                                {
                                    Spikes s = (Spikes)Entites.Single(s => s is Spikes && s.Position.Equals(new System.Drawing.Point(x, y - 1)));
                                    s.OnStep(((Player)ent));
                                }
                            }
                            
                            else throw new Exceptions.IllegalMovementException();
                            break; 
                        };
                    case WalkingDirection.South:
                        {
                            if (y + 1  < MapHeight && !Entites.Any(check => check.Position.Equals(new System.Drawing.Point(x, y + 1))) && Map[x, y + 1] == 1)
                            {
                                
                                    ent.Move(WalkingDirection.South);
                            }
                            else if (Entites.Where(e => e is Spikes).Any(check => check.Position.Equals(new System.Drawing.Point(x, y + 1))))
                            {
                                if (ent is Player)
                                {
                                    Spikes s = (Spikes)Entites.Single(s => s is Spikes && s.Position.Equals(new System.Drawing.Point(x, y + 1)));
                                    s.OnStep(((Player)ent));
                                }
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
                            else if (Entites.Where(e => e is Spikes).Any(check => check.Position.Equals(new System.Drawing.Point(x + 1, y))))
                                {
                                if (ent is Player)
                                {
                                    Spikes s = (Spikes)Entites.Single(s => s is Spikes && s.Position.Equals(new System.Drawing.Point(x + 1, y)));
                                    s.OnStep(((Player)ent));
                                }
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
                            else if (Entites.Where(e => e is Spikes).Any(check => check.Position.Equals(new System.Drawing.Point(x - 1, y))))
                            {
                                if (ent is Player)
                                {
                                    Spikes s = (Spikes)Entites.Single(s => s is Spikes && s.Position.Equals(new System.Drawing.Point(x - 1, y)));
                                    s.OnStep(((Player)ent));
                                }
                            }
                            else throw new Exceptions.IllegalMovementException();
                            break;
                        };
                        default: { throw  new Exceptions.IllegalMovementException();  }
                }
                if (ent is Player)
                {
                    MakePlayerAreaVisible();
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

        public void PutPlayer(Player p)
        {
            if (!Entites.Any(e => e is Player)) {
                Random rand = new Random();
                int xrand = rand.Next(MapWidth);
                int yrand = rand.Next(MapHeight);
                while (Map[xrand, yrand] != 1 && !Entites.Any(e => e.Position.Equals(new Point(xrand,yrand)))) {
                    xrand = rand.Next(MapWidth);
                    yrand = rand.Next(MapHeight);
                }
                if (p is not null)
                {
                    p.Position = new System.Drawing.Point(xrand, yrand);
                    Entites.Add(p);
                }
                else
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
                        Items = [new Item("Map") { Name = "Mapa lochu", Type = ItemTypes.Other, Weight = 0 }]
                    });

                MakePlayerAreaVisible();
                Console.WriteLine($"Player spawned on {xrand}, {yrand}");



            }
            else throw new Exceptions.PlayerExistsException();
        }

        private void PutEntities()
        {
            Random rand = new Random();
            int xrand = rand.Next(MapWidth);
            int yrand = rand.Next(MapHeight);

            List<IEntity> requiredEntities = [new Altar("Magiczny ołtarz"),
            new Monster("Lich")
            {
                Level = 10,
                Experience = 350,
                MaxHealth = 25,
                MaxMana = 0,
                CurHealth = 25,
                CurMana = 0,
                Dexterity = 3,
                PhysicalResist = 0,
                MagicResist = 10,
                FireResist = 2,
                Strength = 12,
                MaxItemWeight = 1,
                DamageType = DamageTypes.Magic,
                Position = new System.Drawing.Point(xrand, yrand),
                Items = new List<Item>()
            },
            new Exploder("Exploder")
            {
                Level = 6,
                Experience = 30 + 10 * 6,
                MaxHealth = 8 + 6,
                MaxMana = 0,
                CurHealth = 8 + 6,
                CurMana = 0,
                Dexterity = 3,
                PhysicalResist = 2,
                MagicResist = 10,
                FireResist = 0,
                Strength = 10,
                MaxItemWeight = 1,
                Position = new System.Drawing.Point(xrand, yrand),
                Items = new List<Item>()
            }, new FishingPond("Staw z rybami", 5)];
                

            requiredEntities.ForEach(e =>
            {
                xrand = rand.Next(MapWidth);
                yrand = rand.Next(MapHeight);
                while (Map[xrand, yrand] != 1)
                {
                    xrand = rand.Next(MapWidth);
                    yrand = rand.Next(MapHeight);
                }

                e.Position = new System.Drawing.Point(xrand, yrand);

                if (e is FishingPond)
                {
                    ((FishingPond)e).OnInteract += delegate
                    {
                        GetPlayer().AddItem(new Item("Fish")
                        {
                            Name = "Ryba",
                            Type = ItemTypes.Consumable,
                            Weight = 1,
                            ItemModifiers = new Dictionary<ModifierTypes, int> { { ModifierTypes.Healing, 3 } }
                        });
                    };
                }

                Entites.Add(e);
 
            });

            for (int i = 0; i < 10;  i++)
            {
                xrand = rand.Next(MapWidth);
                yrand = rand.Next(MapHeight);
                while (Map[xrand, yrand] != 1 && !Entites.Any(e => e.Position.Equals(new Point(xrand, yrand))))
                {
                    xrand = rand.Next(MapWidth);
                    yrand = rand.Next(MapHeight);
                }

                int level = rand.Next(1, 5);

                Entites.Add(new Monster("Goblin") 
                {
                    Level = level,
                    Experience = 25 + 10*level,
                    MaxHealth = 3 + level,
                    MaxMana = 0,
                    CurHealth = 3 + level,
                    CurMana = 0,
                    Dexterity = 1,
                    PhysicalResist = 0,
                    MagicResist = 0,
                    FireResist = 0,
                    Strength = 5,
                    MaxItemWeight = 1,
                    Position = new System.Drawing.Point(xrand, yrand),
                });

                
            }

            for (int i = 0; i < 10; i++)
            {
                xrand = rand.Next(MapWidth);
                yrand = rand.Next(MapHeight);
                while (Map[xrand, yrand] != 1 && !Entites.Any(e => e.Position.Equals(new Point(xrand, yrand))))
                {
                    xrand = rand.Next(MapWidth);
                    yrand = rand.Next(MapHeight);
                }

                int level = rand.Next(1, 5);

                Entites.Add(new Monster("Goblin")
                {
                    Level = level,
                    Experience = 25 + 10 * level,
                    MaxHealth = 3 + level,
                    MaxMana = 0,
                    CurHealth = 3 + level,
                    CurMana = 0,
                    Dexterity = 1,
                    PhysicalResist = 0,
                    MagicResist = 0,
                    FireResist = 0,
                    Strength = 5,
                    MaxItemWeight = 1,
                    Position = new System.Drawing.Point(xrand, yrand),
                });
            }

            

            for (int i = 0; i < 5; i++)
            {
                xrand = rand.Next(MapWidth);
                yrand = rand.Next(MapHeight);
                while (Map[xrand, yrand] != 1 && !Entites.Any(e => e.Position.Equals(new Point(xrand, yrand))))
                {
                    xrand = rand.Next(MapWidth);
                    yrand = rand.Next(MapHeight);
                }

                int level = rand.Next(6, 10);
                int nameId = rand.Next(MediumLevelMonsters.Count);

                String monsterName = MediumLevelMonsters[nameId];

                if (monsterName != "Exploder")
                {
                    Entites.Add(new Monster(monsterName)
                    {
                        Level = level,
                        Experience = 50 + 10 * level,
                        MaxHealth = 12 + level,
                        MaxMana = 0,
                        CurHealth = 12 + level,
                        CurMana = 0,
                        Dexterity = 1 + rand.Next(10),
                        PhysicalResist = 3 + level,
                        MagicResist = 1 + rand.Next(4),
                        FireResist = 1 + rand.Next(4),
                        Strength = 8 + level + rand.Next(1,4),
                        MaxItemWeight = 1,
                        Position = new System.Drawing.Point(xrand, yrand),
                    });
                }
                else
                {
                    Entites.Add(new Exploder(monsterName)
                    {
                        Level = level,
                        Experience = 30 + 10 * level,
                        MaxHealth = 8 + level,
                        MaxMana = 0,
                        CurHealth = 8 + level,
                        CurMana = 0,
                        Dexterity = 3,
                        PhysicalResist = 2,
                        MagicResist = 10,
                        FireResist = 0,
                        Strength = 10,
                        MaxItemWeight = 1,
                        Position = new System.Drawing.Point(xrand, yrand),
                    });
                }
            }

            foreach (var exploder in Entites.Where(e => e is Exploder))
            {
                ((Exploder)exploder).OnExploderDeath += delegate
                {
                    foreach (var ent in GetInteractableEntitiesAroundEnt(exploder))
                    {
                        if (ent is Character)
                        {
                            ((Character)ent).TakeDamage(DamageTypes.Fire, ((Exploder)exploder).Strength / 3);
                        }
                    }

                };
            }

            for (int i = 0; i < 10; i++)
            {
                xrand = rand.Next(MapWidth);
                yrand = rand.Next(MapHeight);
                while (Map[xrand, yrand] != 1 && !Entites.Any(e => e.Position.Equals(new Point(xrand, yrand))))
                {
                    xrand = rand.Next(MapWidth);
                    yrand = rand.Next(MapHeight);
                }

                int level = rand.Next(1, 5);

                Entites.Add(new Spikes(new Point(xrand, yrand))
                {
                    Name = "Kolce",
                });
            }
            
        }

        public Player GetPlayer()
        {
            return Entites.OfType<Player>().FirstOrDefault();
        }

        public void Attack(Character char1, Character char2)
        {

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

        private void FillTwodimensionalArray<T>(T[,] array, T value)
        {
            System.Threading.Tasks.Parallel.For(0, MapWidth, x =>
            {
                for (int j = 0; j < MapHeight; j++)
                    array[x, j] = value;

            });
        }

        private void MakePlayerAreaVisible()
        {
            Player p = GetPlayer();

            Point entpos = p.Position;

            for (int i = entpos.X - 2; i <= entpos.X + 2; i++)
            {
                for (int j = entpos.Y - 2; j <= entpos.Y + 2; j++)
                {
                    if (i >= 0 && i < Dungeon.MapWidth && j >= 0 && j < Dungeon.MapHeight)
                    {
                        VisMap[i, j] = true; 
                    }
                }
            }
        }

        public List<IEntity> GetInteractableEntitiesAroundEnt(IEntity ent)
        {
            List<IEntity> validEnts = Entites.Where(e => e.IsInteractable && (
                e.Position.Equals(new Point(ent.Position.X, ent.Position.Y - 1)) ||
                e.Position.Equals(new Point(ent.Position.X, ent.Position.Y + 1)) ||
                e.Position.Equals(new Point(ent.Position.X + 1, ent.Position.Y)) ||
                e.Position.Equals(new Point(ent.Position.X - 1, ent.Position.Y))
            )).ToList();

            return validEnts;
        }

        public static void Combat(Player ch1, Monster ch2)
        {
            if (ch1.Dexterity >  ch2.Dexterity)
            {
                ch2.TakeDamage(ch1.DamageType, ch1.Strength/2);
                if (!ch2.IsDead)
                    ch1.TakeDamage(ch2.DamageType, ch2.Strength/2);
            }
            else
            {
                ch1.TakeDamage(ch2.DamageType, ch2.Strength/2);
                if (!ch1.IsDead)
                    ch2.TakeDamage(ch1.DamageType, ch1.Strength/2);
            }

            if (ch2.IsDead)
                ch1.AwardXP(ch2.XPReward(ch1));
            
        }







    }
}
