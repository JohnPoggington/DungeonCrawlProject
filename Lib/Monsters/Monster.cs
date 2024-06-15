using Lib.Items;
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

        //private List<Item> _LootTable = [ExampleItems.SmallHealthPotion,
        //    ExampleItems.SmallManaPotion,
        //    ExampleItems.LargeHealthPotion,
        //    ExampleItems.LargeManaPotion];

        private Dictionary<Item, int> _LootTable = new Dictionary<Item, int>() {
            { ExampleItems.SmallHealthPotion, 7 },
            { ExampleItems.LargeHealthPotion, 5 },
            { ExampleItems.SmallManaPotion, 7 },
            { ExampleItems.LargeManaPotion, 5 },
            { ExampleItems.FireRing, 4 },
            { ExampleItems.Wine, 7 },
            { ExampleItems.RogueCloak, 3 },
            { ExampleItems.Fish, 13 }
        };


        public int XPReward(Character ch)
        {
            int levelDiff = Level - ch.Level;
            int reward = Experience + (50 * levelDiff/2)/2;
            return reward > 0 ? reward : 0;
        }

        public Monster(String name)
        {
            this.Name = name;

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
                if (chosenItems.Count > 0)
                    Items.Add(chosenItems[choice]);
            }
        }

        //public Monster(String name, int level, int maxHP, int maxMana, int str, int dex, int basexp, int ) { }

       



    }
}
