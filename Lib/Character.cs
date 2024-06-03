﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Lib.Enums;

namespace Lib
{
    public abstract class Character : IEntity
    {
        public String Name { get; set; }
        public int CurHealth { get; set; }
        public int MaxHealth { get; set; }
        public int CurMana { get; set; }
        public int MaxMana { get; set; }
        public int Level { get; set; }
        public Point Position { get; set; }
        public int PhysicalResist { get; set; }
        public int FireResist { get; set; }
        public int MagicResist { get; set; }
        public int Dexterity { get; set; }
        public int Strength { get; set; }
        public List<Item> Items { get; set; }

        public int MaxItemWeight { get; set; }

        public virtual void AddItem(Item item)
        {
            int totalWeight = Items.Sum(x => x.Weight);
            if (totalWeight + item.Weight < MaxItemWeight)
            {
                Items.Add(item);
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        public void Move(WalkingDirection direction)
        {
            Console.WriteLine($"Moving {Name}");
            Console.WriteLine($"Old x {Position.X} y {Position.Y}");
            switch (direction)
            {
                case WalkingDirection.North: {
                        //Position.Offset(1, 0);
                        Position = Position + new Size(0, -1);
                        break; 
                    }
                case WalkingDirection.South:
                    {
                        //Position.Offset(-1, 0);
                        Position = Position + new Size(0, 1);
                        break;
                    }
                case WalkingDirection.East:
                    {
                        //Position.Offset(0, 1);
                        Position = Position + new Size(1, 0);
                        break;
                    }
                case WalkingDirection.West:
                    {
                        //Position.Offset(0, -1);
                        Position = Position + new Size(-1, 0);
                        break;
                    }
            }

            Console.WriteLine($"New x {Position.X} y {Position.Y}");
        }

        public virtual void TakeDamage()
        {
            
        }
    }
}
