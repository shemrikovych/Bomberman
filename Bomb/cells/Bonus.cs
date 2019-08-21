using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bomb
{
    public class Bonus: Bomb
    {
        public Bonus(int dx, int dy,int seconds) : base(dx, dy, seconds) { }
        public override bool Action()
        {

            if (Form1.bonus is AddLife)
            {
                Form1.bonus = null;
                Form1.lifes++;
               
            }
            else
            {

                Form1.catchBonus = Form1.bonus;
                Form1.catchBonus.AddSeconds(15);

            }

            Form1.field[Form1.Human.y, Form1.Human.x] = new Empty(Form1.Human.x, Form1.Human.y);
            
            return true;
        }
    }
}
