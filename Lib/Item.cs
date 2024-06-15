using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Lib.Enums;

namespace Lib
{
    public class Item : IComparable<Item>
    {
        [JsonInclude]
        public string Name { get; set; }
        [JsonInclude]
        public int Weight { get; set; }

        [JsonInclude]
        public ItemTypes Type { get; set; }

        [JsonInclude]
        public string SpriteName { get; set; }

        [JsonInclude]
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
            ItemModifiers = new Dictionary<ModifierTypes, int>();
        }

        public void Use()
        {
            OnUse?.Invoke();
        }
        
    }
}
