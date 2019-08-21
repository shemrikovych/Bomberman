﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bomb
{
   public class Wall: Cell
    {
        
        public Wall(int dx, int dy) : base(dx, dy)
        {
            image = Properties.Resources.Wall;
        }
    }
   
}
