using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib
{
    public abstract class Item
    {
        public abstract string Name { get; set; }
        public int Weight { get; set; }
        
    }
}
