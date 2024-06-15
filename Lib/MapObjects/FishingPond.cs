using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.MapObjects
{
    public class FishingPond : InteractableObject
    {
        public FishingPond(String name, int fishes) : base(name) { _fishes = fishes; }

        private Random random = new Random();

        private int _fishes;

        public event VoidDelegate OnInteract;
        public event VoidDelegate OnInteractFailed;
        public event VoidDelegate OnNoFishes;

        public override void Interact(Player p)
        {
            int chance = random.Next(1, 100);

            if (_fishes > 0 )
            {
                if (chance < 25)
                {
                    OnInteract?.Invoke();
                    _fishes--;
                }
                else
                {
                    OnInteractFailed?.Invoke();
                }
            }
            else { OnNoFishes?.Invoke(); }
        }
    }
}
