using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.MapObjects
{
    public class TestObj : InteractableObject
    {
        public override void Interact(Player p)
        {
            throw new NotImplementedException();
        }

        public TestObj(string Name) : base(Name) { }
    }
}
