using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bomb
{
    public class Man: Cell
    {
       
        

    
        public Man(int dx, int dy) : base(dx, dy)
        {
            image = Form1.im;
        }

        
    }
}
