using Lib.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Items
{
    public class Weapon : Item
    {
        public Weapon(string spriteName, DamageTypes dmgType) : base(spriteName)
        {
            Type = Enums.ItemTypes.Weapon;
            DamageType = dmgType;
        }

        public DamageTypes DamageType { get; set; }
    }
}
