using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bomb
{
    class Trap: Cell
    {
        public Trap(int dx, int dy) :base(dx,dy)
        {
            image = Properties.Resources.Empty;

        }
        public override bool Action()
        {
            if (Form1.catchBonus is God == false)
            {
                Form1.lifes--;
                Form1.field[Form1.Human.y, Form1.Human.x] = new VisibleTrap(Form1.Human.x, Form1.Human.y);


            }
            return true;
        }


    }
    class VisibleTrap : Cell
    {
        public VisibleTrap(int dx, int dy) : base(dx, dy)
        {
            image = Properties.Resources.Trap;

        }
       


    }

}
