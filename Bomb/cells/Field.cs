using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using System.Drawing;
using System.Windows.Forms;

namespace Bomb
{

     public class Field

    {

        public readonly int width = 20;
        public readonly int height = 30;
        public Level[] level;
        public static Cell[,] map;
        private int levelPoint;
        public Field()
        {
            
            levelPoint = 0;
            string path = @"level.json";
            using (StreamReader sr = new StreamReader(path))
            {
                level = JsonConvert.DeserializeObject<Level[]>(sr.ReadToEnd());
            }
           
            LoadLevel();
        }
      
        public Cell this[int i, int j]
        {
            get
            {
                return map[i,j];
            }
            set
            {
                map[i, j] = value;
            }
        }
        public  static void Printing(Graphics graphics)
        {
           
            

             foreach (Cell x in map)
                {
                    graphics.DrawImage(x.image,x.x * x.width, x.y * x.height, x.width, x.height);


                }
                

        }
        public bool Cheking(int x, int y)
        {
            if (x >= 0 && y >= 0 && x < width && y < height)
            {
                return true;
            }
            return false;
        }
        public void LoadLevel()
        {
            
            
            Random ran = new Random();
            Level lev = level[levelPoint];
           
            int wallCount = (int)(height * width * lev.walls);
            int coinsCount = (int)(height * width * lev.coins);
           
            int destrWallCount = (int)(height * width * lev.destroidwalls);
            int trapsCount = (int)(height * width * lev.traps);
            List<Cell> list = new List<Cell>();
            map = new Cell[height, width];
            for(int i = 0; i < height; i++)
            {
                for(int j = 0; j < width; j++)
                {
                    map[i, j] = new Empty(j, i);

                }
               
            }
          
            map[height-1, width-1] = new Exit(width-1,height-1);
            list.Add(new Portal(0, 0));
            while (wallCount > 0)
            {
                list.Add(new Wall(0,0));
                wallCount--;
            }
            while (coinsCount > 0)
            {
                list.Add(new Coins(0, 0));
                coinsCount--;
            }
          
            while (destrWallCount > 0)
            {
                list.Add(new DestroidWall(0, 0));
                destrWallCount--;
            }
            while (trapsCount > 0)
            {
                list.Add(new Trap(0, 0));
                trapsCount--;
            }
            while(list.Count > 0)
            {
                int x = ran.Next(0, width);
                int y = ran.Next(0, height);
                if (x == 0 && y == 0)
                    continue;
                if (map[y, x] is Empty)
                {
                    
                    map[y, x] = list[list.Count - 1];
                    map[y, x].x = x;
                    map[y, x].y = y;
                    list.RemoveAt(list.Count - 1);
                }

            }
          


           
        }
        public bool NextLevel()
        {
            levelPoint++;
            if (levelPoint >= level.Length)
            {
                return false;
            }
            LoadLevel();
           
            return true;
        }
    }

}

        

    

