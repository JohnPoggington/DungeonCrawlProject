using Lib.Enums;
using Lib.Exceptions;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Lib.MapObjects
{

    [DataContract]
    public class Altar : InteractableObject
    {

        public event VoidDelegate OnInteract;
        public event VoidDelegate OnInteractFailed;
        [DataMember]
        public bool AltarUsed { get; set; } = false;
        public Altar(String name) : base(name)
        {

        }
        
        public override void Interact(Player p)
        {
            if (AltarUsed == false) { 
                p.CurHealth = p.MaxHealth;
                p.CurMana = p.MaxMana;
                AltarUsed = true;
                OnInteract?.Invoke();
            }
            else OnInteractFailed?.Invoke();
        }
    }
}
