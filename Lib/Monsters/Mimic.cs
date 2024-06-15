using Lib.Enums;
using Lib.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Monsters
{
    public class Mimic : Monster
    {
        
        public Mimic(string name) : base(name)
        {
            isSeen = false;
        }

        public Mimic (string Name, Dictionary<Item, int> lootTable) : base(Name, lootTable)
        {
            isSeen = false;
        }


        public Mimic () : base()
        {

        }
        public bool isSeen;

        public override void TakeDamage(DamageTypes dmgType, int damage)
        {
            base.TakeDamage(dmgType, damage);
            isSeen = true;
        }
    }
}
