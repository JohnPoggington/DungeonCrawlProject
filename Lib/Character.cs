using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib
{
    public abstract class Character
    {
        public String Name { get; set; }
        public int CurHealth { get; set; }
        public int MaxHealth { get; set; }
        public int Level { get; set; }
        public int PhysicalResist { get; set; }
        public int Dexterity { get; set; }
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
        public virtual void TakeDamage()
        {
            
        }
    }
}
