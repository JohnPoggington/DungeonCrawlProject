using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lib.Enums;

namespace Lib
{
    public abstract class Item
    {
        public string Name { get; set; }
        public int Weight { get; set; }

        public ItemTypes Type { get; set; }

        public abstract void Use();
        
    }
}
