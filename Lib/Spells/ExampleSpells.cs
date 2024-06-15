using Lib.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Spells
{
    public static class ExampleSpells
    {
        public static Spell Heal { get => new Spell("Leczenie", Enums.SpellTypes.SelfTarget, 5)
        {
            SpellModifiers = new Dictionary<Enums.ModifierTypes, int>
            {
                { ModifierTypes.Healing, 5 }
            }
        };
        }

        public static Spell MagicMissile
        {
            get => new Spell("Magiczny pocisk", Enums.SpellTypes.SingleTarget, 5)
            {
                SpellModifiers = new Dictionary<Enums.ModifierTypes, int>
            {
                { ModifierTypes.Damage, 3 }
            }
            };
        }

        public static Spell Explode
        {
            get => new Spell("Wybuch energii", Enums.SpellTypes.AreaOfEffect, 10)
            {
                SpellModifiers = new Dictionary<Enums.ModifierTypes, int>
            {
                { ModifierTypes.Damage, 5 }
            }
            };
        }
    }
}
