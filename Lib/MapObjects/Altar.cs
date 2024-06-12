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
    
    
    public class Altar : InteractableObject
    {
        public String Name { get; set; }
        
        public Point Position { get; set; }
        public DamageTypes DamageType { get; set; }

        public bool IsInteractable { get; set; } = true;

        public void Move(WalkingDirection direction)
        {
            throw new IllegalMovementException();
        }
        public event VoidDelegate OnInteract;
        public event VoidDelegate OnInteractFailed;


        public bool AltarUsed { get; set; } = false;

        public override void Interact(Player p)
        {
            if (AltarUsed == true) { 
                p.CurHealth = p.MaxHealth;
                p.CurMana = p.MaxMana;
                AltarUsed = true;
                OnInteract?.Invoke();
            }
            else OnInteractFailed?.Invoke();
        }
    }
}
