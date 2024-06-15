using Lib.Enums;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Lib.MapObjects
{

    [DataContract]
    public abstract class InteractableObject : IEntity
    {
        [DataMember]
        public string Name {get; set;}
        [DataMember]
        public Point Position { get; set; }
        [DataMember]
        public DamageTypes DamageType { get; set; }
        [DataMember]
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
