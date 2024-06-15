using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lib.Enums;
using Lib.Exceptions;

namespace Lib.MapObjects
{
    public delegate void VoidDelegate();
    public class Spikes : IEntity
    {
        //TODO: SPIKES!!!

        public string Name { get; set; }
        public Point Position { get; set; }

        public event VoidDelegate OnEntityStep;

        public void Move(WalkingDirection direction)
        {
            throw new IllegalMovementException();
        }

        public bool IsInteractable { get; set; } = false;

        public bool AreFound { get; private set; } = false;
        public DamageTypes DamageType { get; set; }

        public Spikes(Point position) { this.Position = position; }

        public void OnStep(Player p)
        {
            p.TakeDamage(DamageType, 5);
            AreFound = true;
            OnEntityStep?.Invoke();
        }
    }
}
