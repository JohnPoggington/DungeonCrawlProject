using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lib.Spells;

namespace Lib.Items
{
    public class RuneStone : Item
    {
        public Spell Spell;
        public RuneStone(Spell spell) : base("RuneStone")
        {
            Spell = spell;
            Name = "Magiczny kamień";
        }

        public RuneStone() : base("RuneStone")
        {
            Name = "Magiczny kamień";
            List<Spell> availibleSpells = [ExampleSpells.Heal, ExampleSpells.MagicMissile, ExampleSpells.Explode];
            Random rand = new Random();

            Spell = availibleSpells[rand.Next(availibleSpells.Count)];

            Type = Enums.ItemTypes.Consumable;

            Weight = 2;
        }
    }
}
