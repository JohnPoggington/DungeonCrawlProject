using Lib.Items;
using Lib.Monsters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Lib.MapObjects
{
    public class Chest : InteractableObject
    {

        private Dictionary<Item, int> _LootTable = new Dictionary<Item, int>() 
        {
            { ExampleItems.IronArmor, 10 },
            { ExampleItems.FireRing, 20 },
            { ExampleItems.WizardRobe, 10 },
            { ExampleItems.RogueCloak, 10 }
        };

        public List<Item> Items;

        public Chest(string name) : base(name)
        {
            Items = new List<Item>();

            Random rand = new Random();

            Items = new List<Item>();

            int tries = rand.Next(10);

            for (int i = 0; i < tries; i++)
            {
                //int index = rand.Next(_LootTable.Count());
                //Items.Add(_LootTable[index]);

                int chance = rand.Next(100);

                List<Item> chosenItems = _LootTable.Where(i => i.Value < chance).Select(k => k.Key).ToList();

                int choice = rand.Next(chosenItems.Count());

                Items.Add(chosenItems[choice]);
            }

            if (Items.Count == 0)
            {
                int chance = rand.Next(2);

                if (chance == 0)
                {
                    Items.Add(ExampleItems.SmallHealthPotion);
                }
                if (chance == 1) 
                {
                    Items.Add(ExampleItems.SmallManaPotion);
                }
            }
        }

        public event VoidDelegate OnInteract;

        public override void Interact(Player p)
        {
            OnInteract?.Invoke();
        }
    }
}
