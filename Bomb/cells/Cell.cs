using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bomb
{
   public abstract class Cell
    {

        public int x;
        public int y;
        public Image image;
        public  int width = 50;
        public int height = 50;
        public virtual void Draw()
        {
            Graphics g = null;
            g.DrawImage(image, x, y, width, height);
        }
        public Cell(int dx, int dy)
        {
            image = Properties.Resources.Down;
            x = dx;
            y = dy;
        }
       
        virtual public bool Action()
        {
            return true;
        }


    }
}
