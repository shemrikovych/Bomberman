using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bomb
{
    public class Coins: Cell
    {
        
        public Coins(int dx, int dy) : base(dx, dy)
        {
            image = Properties.Resources.Coins;
        }
      public override  bool Action()
        {
           
            Form1.ShowCoins();
            Form1.countCoins++;
            image = Properties.Resources.Empty;
            Form1.field[Form1.Human.y, Form1.Human.x] = new Empty(Form1.Human.x, Form1.Human.y);

            return true;
            
        }
    }
}
