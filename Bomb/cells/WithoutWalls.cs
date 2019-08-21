using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bomb
{
    public class WithoutWalls: Bonus
    {
        public WithoutWalls(int dx, int dy, int seconds) : base(dx,dy,seconds)
        {
            image = Properties.Resources.Wall;
        }
      

    }
}
