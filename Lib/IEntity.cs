using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lib.Enums;

namespace Lib
{
    public interface IEntity
    {
        public Point Position { get; set; }

        public void Move(WalkingDirection direction);
    }
}
