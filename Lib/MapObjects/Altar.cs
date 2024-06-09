using Lib.Enums;
using Lib.Exceptions;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.MapObjects
{
    public delegate void AltarDelegate();
    public delegate void UsedAltarDelegate();
    public class Altar : IEntity
    {
        public String Name { get; set; }
        
        public Point Position { get; set; }
        public DamageTypes DamageType { get; set; }

        public void Move(WalkingDirection direction)
        {
            throw new IllegalMovementException();
        }

        public event AltarDelegate OnAltarUsed;
        public event UsedAltarDelegate OnUsedAltarInteract;

        public bool AltarUsed { get; set; } = false;

        public void Interact(Player p)
        {
            if (AltarUsed == true) { 
                p.CurHealth = p.MaxHealth;
                p.CurMana = p.MaxMana;
                AltarUsed = true;
                OnAltarUsed?.Invoke();
            }
            else OnUsedAltarInteract?.Invoke();
        }
    }
}
