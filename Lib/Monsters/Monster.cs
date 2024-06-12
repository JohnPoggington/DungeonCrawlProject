using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Monsters
{
    public delegate void DieDelegate(int xp);
    public class Monster : Character
    {
        public int Experience { get; set; }
        //TODO: maybe replace this or put to Character abstract class

        public int XPReward(Character ch)
        {
            int levelDiff = Level - ch.Level;
            int reward = Experience + (50 * levelDiff/2)/2;
            return reward > 0 ? reward : 0;
        }



    }
}
