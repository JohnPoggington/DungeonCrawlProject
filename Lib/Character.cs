using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using Lib.Enums;
using Lib.Items;

namespace Lib
{
    public delegate void DodgedAttackDelegate();
    public delegate void DieDelegate();
    public delegate void CombatDelegate(int damage);
    public delegate void VoidDelegate();
    public abstract class Character : IEntity
    {
        public String Name { get; set; }
        public int CurHealth { get; set; }
        public int MaxHealth { get; set; }
        public int CurMana { get; set; }
        public int MaxMana { get; set; }
        public int Level { get; set; }
        public Point Position { get; set; }
        public int PhysicalResist { get; set; }
        public int FireResist { get; set; }
        public int MagicResist { get; set; }
        public int Dexterity { get; set; }
        public int Strength { get; set; }

        public int Experience { get; set; }
        public List<Item> Items { get; set; }
        public bool IsInteractable { get; set; } = true;
        public DamageTypes DamageType { get; set; } = DamageTypes.Physical;

        public Weapon Weapon { get; set; }

        public Item Armor { get; set; }

        public List<Item> Jewelery = new List<Item>(4);

        public bool IsDead { get { return CurHealth <= 0; } }

        public event DodgedAttackDelegate OnAttackDodge;
        public event DieDelegate OnDeath;
        public event CombatDelegate OnCombat;
        public event VoidDelegate OnEquipFailed;
        public int MaxItemWeight { get; set; }

        public virtual bool AddItem(Item item)
        {
            int totalWeight = 0;
            if (Items.Count() > 0) totalWeight = Items.Sum(x => x.Weight);
            if (totalWeight + item.Weight < MaxItemWeight)
            {
                Items.Add(item);
                //foreach(var modifier in item.ItemModifiers)
                //{
                //    switch (modifier.Key)
                //    {
                //        case ModifierTypes.Strength: Strength += modifier.Value; break;
                //        case ModifierTypes.Dexterity: Dexterity += modifier.Value; break;
                //        case ModifierTypes.MaxHealth: MaxHealth += modifier.Value; break;
                //        case ModifierTypes.MaxMana: MaxMana += modifier.Value; break;
                //        case ModifierTypes.PhysicalResist: PhysicalResist += modifier.Value; break;
                //        case ModifierTypes.MagicResist: MagicResist += modifier.Value; break;
                //        case ModifierTypes.FireResist: FireResist += modifier.Value; break;

                //    }
                //}
                return true;
                
                
            }
            else
            {
                OnEquipFailed?.Invoke();
            }
            return false;
        }

        public virtual void RemoveItem(Item item, bool useItem)
        {
            //Console.WriteLine(item.Type);
            //if (item.Type != ItemTypes.Consumable && item.Type != ItemTypes.Other)
            //{
            //    Console.WriteLine("not consumable");
            //    foreach (var modifier in item.ItemModifiers)
            //    {
            //        switch (modifier.Key) { 

            //            case ModifierTypes.Strength: Strength -= modifier.Value; break;
            //            case ModifierTypes.Dexterity: Dexterity -= modifier.Value; break;
            //            case ModifierTypes.MaxHealth: MaxHealth -= modifier.Value; break;
            //            case ModifierTypes.MaxMana: MaxMana -= modifier.Value; break;
            //            case ModifierTypes.PhysicalResist: PhysicalResist -= modifier.Value; break;
            //            case ModifierTypes.MagicResist: MagicResist -= modifier.Value; break;
            //            case ModifierTypes.FireResist: FireResist -= modifier.Value; break;
            //        }
            //    }
                
            //}
            if (item.Type == ItemTypes.Consumable && useItem)
            {
                Console.WriteLine(item.Type);
                foreach (var modifier in item.ItemModifiers)
                {
                    Console.WriteLine(modifier.Key);
                    switch (modifier.Key)
                    {
                        case ModifierTypes.Healing: Heal(modifier.Value); Console.WriteLine("heal!!!"); break;
                        case ModifierTypes.ManaRestore: RenewMana(modifier.Value); break;
                        case ModifierTypes.Strength: Strength += modifier.Value; break;
                        case ModifierTypes.Dexterity: Dexterity += modifier.Value; break;
                    }
                }
                
            }
            Items.Remove(item);
        }

        public void EquipItem(Item item)
        {
            if (item is Weapon)
            {
                if (Weapon is not null)
                {
                    ApplyModifier(Weapon, true);
                    AddItem(Weapon);

                    
                }
                Weapon = (Weapon)item;
                ApplyModifier(item, false);


            }
            else if ((item.Type == ItemTypes.Armor))
            {
                if (Armor is not null)
                {
                    ApplyModifier(Armor, true);
                    AddItem(Armor);
                    
                }
                Armor = item;
                ApplyModifier(item, false);
            }
            else if (item.Type == ItemTypes.Jewelery)
            {
                if (Jewelery.Count > 4)
                {
                    ApplyModifier(item, false);
                    Jewelery.Add(item);
                    
                }
            }
        }

        public void RemoveJewelery(Item item)
        {
            if (item.Type == ItemTypes.Jewelery)
            {
                ApplyModifier(item, true);
                Jewelery.Remove(item);

            }
        }

        public void UnequipWeapon(Weapon weapon)
        {
            if (Weapon == weapon)
            {
                ApplyModifier(Weapon, true);
                AddItem(Weapon);
                Weapon = null;
            }
        }

        public void UnequipArmor(Item item)
        {
            if (item.Type == ItemTypes.Armor)
            {

                ApplyModifier(item, true);
                AddItem(item);
                Armor = null;
            }
        }

        private void ApplyModifier(Item item, bool isRemoving)
        {
            
            foreach (var modifier in item.ItemModifiers)
            {
                if (!isRemoving)
                {
                    switch (modifier.Key)
                    {
                        case ModifierTypes.Strength: Strength += modifier.Value; break;
                        case ModifierTypes.Dexterity: Dexterity += modifier.Value; break;
                        case ModifierTypes.MaxHealth: MaxHealth += modifier.Value; break;
                        case ModifierTypes.MaxMana: MaxMana += modifier.Value; break;
                        case ModifierTypes.PhysicalResist: PhysicalResist += modifier.Value; break;
                        case ModifierTypes.MagicResist: MagicResist += modifier.Value; break;
                        case ModifierTypes.FireResist: FireResist += modifier.Value; break;

                    }
                }
                if (isRemoving)
                {
                        switch (modifier.Key)
                        {

                            case ModifierTypes.Strength: Strength -= modifier.Value; break;
                            case ModifierTypes.Dexterity: Dexterity -= modifier.Value; break;
                            case ModifierTypes.MaxHealth: MaxHealth -= modifier.Value; break;
                            case ModifierTypes.MaxMana: MaxMana -= modifier.Value; break;
                            case ModifierTypes.PhysicalResist: PhysicalResist -= modifier.Value; break;
                            case ModifierTypes.MagicResist: MagicResist -= modifier.Value; break;
                            case ModifierTypes.FireResist: FireResist -= modifier.Value; break;
                        }
                    
                }
            }
        }

        private void UseItem(Item item)
        {

        }

        public virtual int CurrentWeight { get => Items.Sum(x => x.Weight); }

        public virtual void Move(WalkingDirection direction)
        {
            Console.WriteLine($"Moving {Name}");
            Console.WriteLine($"Old x {Position.X} y {Position.Y}");
            switch (direction)
            {
                case WalkingDirection.North: {
                        //Position.Offset(1, 0);
                        Position = Position + new Size(0, -1);
                        break; 
                    }
                case WalkingDirection.South:
                    {
                        //Position.Offset(-1, 0);
                        Position = Position + new Size(0, 1);
                        break;
                    }
                case WalkingDirection.East:
                    {
                        //Position.Offset(0, 1);
                        Position = Position + new Size(1, 0);
                        break;
                    }
                case WalkingDirection.West:
                    {
                        //Position.Offset(0, -1);
                        Position = Position + new Size(-1, 0);
                        break;
                    }
            }

            Console.WriteLine($"New x {Position.X} y {Position.Y}");
        }

        public virtual void Die()
        {
            OnDeath?.Invoke();
        }
        
        public virtual void Heal(int points)
        {
            CurHealth += points;
            if (CurHealth > MaxHealth) { CurHealth = MaxHealth; }
        }

        public virtual void RenewMana(int points)
        {
            CurMana += points;
            if (CurMana > MaxMana) { CurMana = MaxMana; }
        }

        public virtual void TakeDamage(DamageTypes dmgType, int damage)
        {

            Random random = new Random();
            if (random.Next(100) < Dexterity/3)
            {
                OnAttackDodge?.Invoke();
            }
            else
            {
                 switch (dmgType) 
                {
                    case DamageTypes.Physical:
                        {
                            damage -= PhysicalResist; break;
                        }
                    case DamageTypes.Fire:
                        {
                            damage -= FireResist; break;
                        }
                    case DamageTypes.Magic:
                        {
                            damage -= MagicResist; break;
                        }
                }
                if (damage < 0)
                {
                    damage = 0;
                }
                CurHealth -= damage;
                OnCombat?.Invoke(damage);
                if (CurHealth <= 0) 
                {
                    CurHealth = 0;
                    Die();
                }
            }


        }

        public override string ToString()
        {
            return $"{Name} poziomu {Level}";
        }

    }
}
