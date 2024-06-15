using Lib.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Items
{
    public static class ExampleItems
    {
        public static Item Fish
        {
            get => new Item("Fish")
            {
                Name = "Ryba",
                Type = ItemTypes.Consumable,
                Weight = 1,
                ItemModifiers = new Dictionary<ModifierTypes, int> { { ModifierTypes.Healing, 3 } }
            };
        }
        public static Item SmallHealthPotion
        {
            get => new Item("SmallHealthPotion")
            {
                Name = "Mała mikstura zdrowia",
                Type = Enums.ItemTypes.Consumable,
                Weight = 2,
                ItemModifiers = new Dictionary<Enums.ModifierTypes, int> {
                { ModifierTypes.Healing, 5}
            }
            };
        }

        public static Item LargeHealthPotion
        {
            get => new Item("BigHealthPotion")
            {
                Name = "Duża mikstura zdrowia",
                Type = Enums.ItemTypes.Consumable,
                Weight = 4,
                ItemModifiers = new Dictionary<Enums.ModifierTypes, int> {
                { ModifierTypes.Healing, 10}
            }
            };
        }

        public static Item SmallManaPotion
        {
            get => new Item("SmallManaPotion")
            {
                Name = "Mała mikstura many",
                Type = Enums.ItemTypes.Consumable,
                Weight = 2,
                ItemModifiers = new Dictionary<Enums.ModifierTypes, int> {
                { ModifierTypes.ManaRestore, 3}
            }
            };
        }

        public static Item LargeManaPotion
        {
            get => new Item("BigManaPotion")
            {
                Name = "Duża mikstura many",
                Type = Enums.ItemTypes.Consumable,
                Weight = 4,
                ItemModifiers = new Dictionary<Enums.ModifierTypes, int> {
                { ModifierTypes.ManaRestore, 6}
            }
            };
        }

        public static Item Wine
        {
            get => new Item("Wine")
            {
                Name = "Butelka wina",
                Type = Enums.ItemTypes.Consumable,
                Weight = 2,
                ItemModifiers = new Dictionary<Enums.ModifierTypes, int> {
                { ModifierTypes.Strength, 2},
                { ModifierTypes.Dexterity, -1 }
            }
            };
        }


        public static Item IronArmor
        {
            get => new Item("IronArmor")
            {
                Name = "Żelazny pancerz",
                Type = Enums.ItemTypes.Armor,
                Weight = 6,
                ItemModifiers = new Dictionary<Enums.ModifierTypes, int> {
                { ModifierTypes.PhysicalResist, 3},
                { ModifierTypes.FireResist, 1 }
            }
            };
        }

        public static Item WizardRobe
        {
            get => new Item("WizardHat")
            {
                Name = "Kapelusz maga",
                Type = Enums.ItemTypes.Armor,
                Weight = 3,
                ItemModifiers = new Dictionary<Enums.ModifierTypes, int> {
                { ModifierTypes.MagicResist, 3},
                { ModifierTypes.MaxMana, 3 }
            }
            };
        }

        public static Item RogueCloak
        {
            get => new Item("Cape")
            {
                Name = "Peleryna złodzieja",
                Type = Enums.ItemTypes.Armor,
                Weight = 3,
                ItemModifiers = new Dictionary<Enums.ModifierTypes, int> {
                { ModifierTypes.Dexterity, 5},
                    { ModifierTypes.PhysicalResist, 1 }
            }
            };
        }

        public static Item FireRing
        {
            get => new Item("RedRing")
            {
                Name = "Pierścień ognia",
                Type = Enums.ItemTypes.Jewelery,
                Weight = 3,
                ItemModifiers = new Dictionary<Enums.ModifierTypes, int> {
                    { ModifierTypes.FireResist, 3 }
            }
            };
        }

        public static Weapon Sword
        {
            get => new Weapon("Sword", DamageTypes.Physical)
            {
                Name = "Żelazny miecz",
                Type = Enums.ItemTypes.Weapon,
                Weight = 4,
                ItemModifiers = new Dictionary<Enums.ModifierTypes, int> {
                    { ModifierTypes.Strength, 3 }
            }
            };
        }

        public static Weapon WoodStaff
        {
            get => new Weapon("WoodenStaff", DamageTypes.Magic)
            {
                Name = "Drewniany kostur",
                Type = Enums.ItemTypes.Weapon,
                Weight = 3,
                ItemModifiers = new Dictionary<Enums.ModifierTypes, int> {
                    { ModifierTypes.MaxMana, 5 },
                    { ModifierTypes.Strength, 1 }
            }
            };
        }

        public static Weapon RubyStaff
        {
            get => new Weapon("Staff", DamageTypes.Magic)
            {
                Name = "Kostur z rubinem",
                Type = Enums.ItemTypes.Weapon,
                Weight = 3,
                ItemModifiers = new Dictionary<Enums.ModifierTypes, int> {
                    { ModifierTypes.MaxMana, 8 },
                    { ModifierTypes.Strength, 2 },
                    { ModifierTypes.MagicResist, 1 }
            }
            };
        }

        public static RuneStone RuneStone { get => new RuneStone(); }

        public static Item Map
        {
            get => new Item("Map")
            {
                Name = "Mapa lochu",
                Type = ItemTypes.Other,
                Weight = 0,
            };
        }


    }
}
