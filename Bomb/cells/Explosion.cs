using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bomb
{
   public class Explosion : Cell
    {
        private DateTime exptime;

        
        public Explosion(int dx, int dy, int seconds) : base(dx, dy)
        {
            image = Properties.Resources.Explosion;
        }

        public bool Ready()
        {
            var differenceTime = DateTime.Compare(exptime, DateTime.Now);
            if (differenceTime <= 0)
            {
                return true;
            }
            return false;

        }
        public override bool Action()
        {


            if (Form1.catchBonus is God == false)
            {
                Form1.lifes--;
                Form1.field[Form1.Human.y, Form1.Human.x] = new Empty(Form1.Human.x, Form1.Human.y);
                 
              
            }
            return true;
        }
    }
}
