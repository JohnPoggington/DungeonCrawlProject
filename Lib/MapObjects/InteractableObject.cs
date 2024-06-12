using Lib.Enums;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.MapObjects
{
    public delegate void VoidDelegate();
    public abstract class InteractableObject : IEntity
    {
        public string Name {get; set;}

        public Point Position { get; set; }
        public DamageTypes DamageType { get; set; }
        public bool IsInteractable { get; set; }

        public event VoidDelegate OnInteract;
        public event VoidDelegate OnInteractFailed;

        public void Move(WalkingDirection direction)
        {
            throw new NotImplementedException();
        }

        public abstract void Interact(Player p);
    }
}
