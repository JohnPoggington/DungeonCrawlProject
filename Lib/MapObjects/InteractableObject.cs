using Lib.Enums;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.MapObjects
{
    public abstract class InteractableObject : IEntity
    {
        public string Name {get; set;}

        public Point Position { get; set; }
        public DamageTypes DamageType { get; set; }
        public bool IsInteractable { get; set; }

        public event VoidDelegate OnInteract;
        public event VoidDelegate OnInteractFailed;
        public InteractableObject(String name)
        {
            this.Name = name;
            this.IsInteractable = true;
        }

        public void Move(WalkingDirection direction)
        {
            throw new NotImplementedException();
        }

        public abstract void Interact(Player p);
    }
}
