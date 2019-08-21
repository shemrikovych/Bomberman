using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bomb
{
  public  class Bomb : Cell
    {

        private DateTime bombtime;
        
       
        public Bomb(int dx, int dy, int seconds) : base(dx, dy)
        {
            image = Properties.Resources.Bomb;
            bombtime = DateTime.Now.AddSeconds(seconds);
        }
        public bool Ready()
        {
            var differenceTime = DateTime.Compare(bombtime, DateTime.Now);
            if (differenceTime <= 0)
            {
                return true;
            }
            return false;

        }
        public void AddSeconds(int seconds)
        {
            bombtime = bombtime.AddSeconds(seconds);
        }
    }
}
