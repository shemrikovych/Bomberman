using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bomb
{
   public class Exit: Cell
    {

        
        public Exit(int dx, int dy) : base(dx, dy)
        {
            image = Properties.Resources.Exit;
        }
        public override bool Action()
        {


            

            if (Form1.field.NextLevel())
            {
                Form1.Human.x = 0;
                Form1.Human.y = 0;
                Form1.EndQueue.Clear();
                Form1.BombQueue.Clear();
                return false;
            }
            else
            {
                
                Console.ReadKey();
            

            }

            return true;
        }
    }
}
