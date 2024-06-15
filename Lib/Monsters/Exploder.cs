using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Monsters
{
    public delegate void VoidDelegate();
    public class Exploder : Monster
    {

        public event VoidDelegate OnExploderDeath;
        public override void Die()
        {
            base.Die();
            OnExploderDeath?.Invoke();
            
        }

        public Exploder(string name) : base(name) { } 
    }
}
