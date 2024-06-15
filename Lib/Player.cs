using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lib.Enums;
using Lib.Items;

namespace Lib
{
    public delegate void LevelDelegate(int CurrentLevel, int OldLevel);
    public class Player : Character
    {
        public WalkingDirection WalkingDirection { get; set; }

                
        public int TotalExperience { get; set; }

        public event LevelDelegate OnLevelUp;

        public override void Move(WalkingDirection direction)
        {
            base.Move(direction);
            this.WalkingDirection = direction;
            Console.WriteLine(WalkingDirection);

        }

        public void AwardXP(int amount)
        {
            Random rand = new Random();
            Experience += amount;
            TotalExperience += amount;
            if (Experience > XPToNextLevel()) 
            {
                int oldLvl = Level;
                while (Experience > XPToNextLevel()) 
                {
                    Experience -= XPToNextLevel();
                    Level = Level + 1;

                    int resist = rand.Next(3);

                    switch (resist)
                    {
                        case 0:PhysicalResist++;break;
                        case 1:MagicResist++;break;
                        case 2:FireResist++;break;
                    }

                }
                MaxHealth += (Level - oldLvl) * 3;
                CurHealth = MaxHealth;
                MaxMana += (Level - oldLvl) * 3;
                CurMana = MaxMana;
                MaxItemWeight += 5;
                OnLevelUp?.Invoke(Level, oldLvl);
                
            }
        }

        public int XPToNextLevel()
        {
            //int L = Level + 1;
            //double up = Math.Pow(2, L/7) - Math.Pow(2, 1/7);
            //double down = Math.Pow(2, 1/7) - 1;
            //return (int)((1 / 8) * (Math.Pow(L + 1, 2) - L + 600 * (up / down)));

            int exp = 0;

            if (Level == 1) { return 83; }
            else
            for (int i = 1; i < Level; i++) { exp += (int)Math.Floor(i + 300 + Math.Pow(2, i / 7)); }

            return exp/4;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
