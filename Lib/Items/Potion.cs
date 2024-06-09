using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Items
{
    internal class Potion : Item
    {
        public string Name { get; set; }

        public Potion() 
        {
            Type = Enums.ItemTypes.Consumable;
        }

        public override void Use()
        {
            throw new NotImplementedException();
        }
    }
}
