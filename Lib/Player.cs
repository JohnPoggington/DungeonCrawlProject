using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib
{
    public class Player : Character, IEntity
    {
        public WalkingDirection WalkingDirection { get; set; }

        public void Move(WalkingDirection direction)
        {
            base.Move(direction);
            this.WalkingDirection = direction;
            Console.WriteLine(WalkingDirection);

        }
    }
}
