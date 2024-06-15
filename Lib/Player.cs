using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lib.Enums;
using Lib.Items;
using Lib.Spells;

namespace Lib
{
    public delegate void LevelDelegate(int CurrentLevel, int OldLevel);
    public delegate void SpellDelegate(Spell spell);
    public class Player : Character
    {
        public WalkingDirection WalkingDirection { get; set; }

        public List<Spells.Spell> Spells { get; set; }
        
        public int TotalExperience { get; set; }

        public event LevelDelegate OnLevelUp;

        public event SpellDelegate OnSpellLearned;
        public event SpellDelegate OnSpellLearnFailed;

        public override void Move(WalkingDirection direction)
        {
            base.Move(direction);
            this.WalkingDirection = direction;
            Console.WriteLine(WalkingDirection);

        }

        public void AwardXP(int amount)
        {
            Random rand = new Random();
            Experience += amount;
            TotalExperience += amount;
            if (Experience > XPToNextLevel()) 
            {
                int oldLvl = Level;
                while (Experience > XPToNextLevel()) 
                {
                    Experience -= XPToNextLevel();
                    Level = Level + 1;

                    int resist = rand.Next(3);

                    switch (resist)
                    {
                        case 0:PhysicalResist++;break;
                        case 1:MagicResist++;break;
                        case 2:FireResist++;break;
                    }

                }
                MaxHealth += (Level - oldLvl) * 3;
                CurHealth = MaxHealth;
                MaxMana += (Level - oldLvl) * 3;
                CurMana = MaxMana;
                MaxItemWeight += 5;
                OnLevelUp?.Invoke(Level, oldLvl);
                
            }
        }

        public int XPToNextLevel()
        {
            
            int exp = 0;

            if (Level == 1) { return 83; }
            else
            for (int i = 1; i < Level; i++) { exp += (int)Math.Floor(i + 300 + Math.Pow(2, i / 7)); }

            return exp/4;
        }

        public bool LearnSpell(Spell spell)
        {
            if (!Spells.Contains(spell))
            {
                Spells.Add(spell);
                return true;
            }
            return false;
        }

        public bool CastSpell(Spell spell)
        {
            if (Spells.Contains(spell))
            {
                if (CurMana >= spell.ManaCost)
                {
                    spell.CastSpell();
                    CurMana -= spell.ManaCost;
                    return true;
                }
            }
            else throw new Exceptions.IllegalSpellCastException();
            return false;
        }

        public Spell GetSpell(String spell)
        {
            Spell ret = Spells.Find(s => s.Equals(spell));
            return ret;
        }

        public override void RemoveItem(Item item, bool useItem)
        {
            base.RemoveItem(item, useItem);
            if (item is RuneStone)
            {
                bool success = LearnSpell(((RuneStone)item).Spell);

                if (success)
                {
                    OnSpellLearned?.Invoke(((RuneStone)item).Spell);
                }
                if (!success)
                {
                    OnSpellLearnFailed?.Invoke(((RuneStone)item).Spell);
                }
            }
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
