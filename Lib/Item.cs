using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lib.Enums;

namespace Lib
{
    public class Item : IComparable<Item>
    {
        public string Name { get; set; }
        public int Weight { get; set; }

        public ItemTypes Type { get; set; }

        public string SpriteName { get; set; }

        public Dictionary<ModifierTypes, int> ItemModifiers { get; set; }

        public event VoidDelegate OnUse;

        public int CompareTo(Item? other)
        {
            if (this.Weight > other.Weight) return -1;
            else if (this.Weight < other.Weight) { return 1; }
            return 0;
        }

        public Item (string spriteName)
        {
            SpriteName = spriteName;
        }

        public void Use()
        {
            OnUse?.Invoke();
        }
        
    }
}
