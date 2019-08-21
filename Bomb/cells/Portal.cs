using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bomb
{
   public class Portal : Cell
    {
        
        public  Portal(int dx, int dy): base(dx, dy)
        {
            image = Properties.Resources.Portal;
        }
        public override bool Action()
        {
            
                int x = 0;
                int y = 0;
                do
                {
                Random ran = new Random();
                x = ran.Next(0, Form1.field.width);
                    y = ran.Next(0, Form1.field.height);
                } while (Form1.field[y, x] is Empty == false);
                 Form1.Human.x = x;
                 Form1.Human.y = y;
       

            return true; 
        }
    }
}
