using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lib.Enums;

namespace Lib
{
    public delegate void LevelDelegate(int CurrentLevel);
    public class Player : Character, IEntity
    {
        public WalkingDirection WalkingDirection { get; set; }

        public int Experience { get; set; }

        public int TotalExperience { get; set; }

        public event LevelDelegate OnLevelUp;

        public void Move(WalkingDirection direction)
        {
            base.Move(direction);
            this.WalkingDirection = direction;
            Console.WriteLine(WalkingDirection);

        }

        public void AwardXP(int amount)
        {
            Experience += amount;
            TotalExperience += amount;
            if (Experience > XPToNextLevel()) 
            {
                while (Experience > XPToNextLevel()) 
                {
                    Experience -= XPToNextLevel();
                    Level = Level + 1;
                }
                OnLevelUp?.Invoke(Level);
                
            }
        }

        public int XPToNextLevel()
        {
            //int L = Level + 1;
            //double up = Math.Pow(2, L/7) - Math.Pow(2, 1/7);
            //double down = Math.Pow(2, 1/7) - 1;
            //return (int)((1 / 8) * (Math.Pow(L + 1, 2) - L + 600 * (up / down)));

            int exp = 0;

            for (int i = 1; i < Level; i++) { exp += (int)Math.Floor(i + 300 + Math.Pow(2, i / 7)); }

            return exp/4;
        }
    }
}
