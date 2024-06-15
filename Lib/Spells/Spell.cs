using Lib.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Lib.Spells
{

    public delegate void SpellDelegate(Spell spell);
    [Serializable]
    public class Spell
    {
        [JsonInclude]
        public int ManaCost {  get; set; }
        [JsonInclude]
        public SpellTypes SpellType { get; set; }
        [JsonInclude]
        public string Name { get; set; }
        [JsonInclude]
        public Dictionary<ModifierTypes, int> SpellModifiers { get; set; }

        public event VoidDelegate OnSpellCast;

        public Spell(String name, SpellTypes type, int cost) 
        {
            Name = name;
            SpellType = type;
            ManaCost = cost;
        }

        public void CastSpell()
        {
            OnSpellCast?.Invoke();
        }

        public override string ToString()
        {
            return $"{Name}, {ManaCost} punktów many, Typ {SpellType}";
        }

        public override bool Equals(object? obj)
        {
            return this.ToString().GetHashCode() == obj.ToString().GetHashCode();
        }

        public bool Equals(String spell) 
        {
            return this.ToString().GetHashCode() == spell.ToString().GetHashCode();
        }
    }
}
