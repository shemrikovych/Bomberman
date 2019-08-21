using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bomb
{
    public partial class Form1 : Form
    {
        Random ran = new Random();
        public static Image im = Properties.Resources.Right;
        private static Graphics g;
        private Field Level { get; set; }
        private Label Info { get; set; }
        private Panel[,] Map { get; set; }
        private Panel Hero { get; set; }
        private int ElementSize { get; set; }
        public static int lifes;
        public static int bombs;
        public static int countCoins = 0;
        public static Bonus catchBonus;
        static public Field field;
        static public Man Human;
        static public Queue<Bomb> BombQueue = new Queue<Bomb>();
        static public Queue<Bomb> EndQueue = new Queue<Bomb>();
        static public Bonus bonus = null;
        public Form1()
        {
            InitializeComponent();
            field = new Field();
            Human = new Man(0, 0);



        }

        private void Form1_Load(object sender, EventArgs e)
        {

            lifes = 3;
            bombs = 6;
            Random ran = new Random();
            ElementSize = Math.Min((int)(Size.Height) / Field.map.GetLength(0), (int)(Size.Width) / Field.map.GetLength(1)); ; 
            field.LoadLevel();
            Render();
            Sounds.Play();
            timer1.Enabled = true;



        }
        private void Render()
        {
            Map = new Panel[Field.map.GetLength(0), Field.map.GetLength(1)];
            Hero = new Panel();
            Info = new Label();


            for (int i = 0; i < Map.GetLength(0); i++)
            {
                for (int j = 0; j < Map.GetLength(1); j++)
                {
                    Map[i, j] = new Panel();
                    Map[i, j].Parent = this;
                    Map[i, j].BackgroundImageLayout = ImageLayout.Stretch;
                    UpdatePanel(field[i, j], true);
                    Controls.Add(Map[i, j]);
                }
            }

            Info.Parent = this;
            Info.Width = 200;
            UpdateInfo();

            Hero.Parent = this;
            Hero.BringToFront();
            Hero.BackgroundImageLayout = ImageLayout.Stretch;
            UpdateHero(true);
        }
       public void UpdatePanel(Cell element, bool updateImage = false)
        {
            Map[element.y, element.x].Size = new Size(ElementSize, ElementSize);
            Map[element.y, element.x].Location = new Point(element.x * ElementSize,
                element.y * ElementSize);
            if (updateImage) Map[element.y, element.x].BackgroundImage = field[element.y, element.x].image;

           
           
        }

        private void UpdateHero(bool updateImage = false)
        {
            Hero.Size = new Size(ElementSize, ElementSize);
            Hero.Location = new Point(Human.x * ElementSize,
                Human.y * ElementSize);
            if (updateImage) Hero.BackgroundImage = Human.image;
        }
        private void UpdateInfo()
        {
            Info.Location = new Point(Size.Height - 150);
           
            Info.Text = $"Health: {lifes}  Coins: {countCoins}  Bombs: {bombs}";
        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;
           // Field.Printing(g);
           // g.DrawImage(Human.image, Human.x * Human.width, Human.y * Human.height, Human.width, Human.height);
        }

        public static void ShowCoins()
        {
            const int plusLife = 8;

            if (countCoins >= plusLife)
            {
                lifes++;
                countCoins = 0;

            }

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {

            int stepx = Human.x;
            int stepy = Human.y;
            if (e.KeyCode == Keys.Left && stepx > 0)
            {
                stepx--;

            }
            else if (e.KeyCode == Keys.Right && field.width - 1 > stepx )
            {
                stepx++;
            }
            else if (e.KeyCode == Keys.Up && stepy > 0)
            {
                stepy--;
            }
            else if (e.KeyCode == Keys.Down && field.height - 1 > stepy)
            {
                stepy++;
            }
            if (catchBonus is WithoutWalls ||
                      (field[stepy, stepx] is DestroidWall == false && field[stepy, stepx] is Wall == false))
            {
                Human.x = stepx;
                Human.y = stepy;
            }
            if (e.KeyCode == Keys.F && bombs > 0)
            {
                Bomb bomb = new Bomb(Human.x, Human.y, 5);
                field[Human.y, Human.x] = bomb;
                BombQueue.Enqueue(bomb);
                bombs--;
                UpdatePanel(field[Human.y, Human.x], true);
            }

            UpdateHero(true);
            UpdateInfo();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            
            if (BombQueue.Count > 0) 
                {
                Bomb first = BombQueue.Peek();



                if (first.Ready())
                {
                    BombQueue.Dequeue();
                    field[first.y, first.x] = new Explosion(first.x, first.y, 2);
                    UpdatePanel(field[first.y, first.x ], true);
                    for (int dx = -1; dx <= 1; dx++)
                    {
                        for (int dy = -1; dy <= 1; dy++)
                        {
                            if (dx == dy || dx + dy == 0)
                                continue;
                            if (field.Cheking(first.x + dx, first.y + dy) &&
                               (field[first.y + dy, first.x + dx] is DestroidWall ||
                                field[first.y + dy, first.x + dx] is Empty ||
                                field[first.y + dy, first.x + dx] is Explosion))
                            {
                                field[first.y + dy, first.x + dx] = new Explosion(first.x + dx, first.y + dy, 2);
                                UpdatePanel(field[first.y + dy, first.x + dx], true);

                            }




                        }


                    }


                    first.AddSeconds(2);
                    EndQueue.Enqueue(first);

                }


            }

            if (EndQueue.Count > 0)
            {
                Bomb first1 = EndQueue.Peek();

                if (first1.Ready())
                {

                    EndQueue.Dequeue();
                    if (field[first1.y, first1.x] is Explosion && (field[first1.y, first1.x] as Explosion).Ready())
                    {
                        field[first1.y, first1.x] = new Empty(first1.x, first1.y);
                        UpdatePanel(field[first1.y, first1.x], true);
                    }
                    for (int dx = -1; dx <= 1; dx++)

                    {
                        for (int dy = -1; dy <= 1; dy++)
                        {
                            if (dx == dy || dx + dy == 0)
                                continue;


                            if (field.Cheking(first1.x + dx, first1.y + dy) &&
                            field[first1.y + dy, first1.x + dx] is Explosion &&
                           (field[first1.y + dy, first1.x + dx] as Explosion).Ready())
                            {

                                field[first1.y + dy, first1.x + dx] = new Empty(first1.x + dx, first1.y + dy);
                                UpdatePanel(field[first1.y + dy, first1.x + dx], true);
                            }
                            
                               


                        }
                    }
                  

                }


            }

            if (field[Human.y, Human.x] is Explosion)
            {

                field[Human.y, Human.x].Action();
                if(lifes <= 0)
                {
                    MessageBox.Show($"Вы проиграли. Кол-во монет {countCoins}, кол-во бомб {bombs}, кол-во жизней {lifes}");
                    Close();
                }
            }

            if (field[Human.y, Human.x] is Coins)
            {

                field[Human.y, Human.x].Action();
                UpdatePanel(field[Human.y, Human.x], true);
            }
            if(field[Human.y,Human.x] is Portal)
            {
                field[Human.y, Human.x].Action();
                UpdatePanel(field[Human.y, Human.x], true);
            }
            if (field[Human.y, Human.x] is Exit)
            {
                field[Human.y, Human.x].Action();
                MessageBox.Show($"Вы умничка! Кол-во монет {countCoins}, кол-во бомб {bombs}, кол-во жизней {lifes}"  );
                Close();
               
            }
            if (field[Human.y, Human.x] is Trap)
            {
                field[Human.y, Human.x].Action();
                UpdatePanel(field[Human.y, Human.x], true);
                if (lifes <= 0)
                {
                    MessageBox.Show($"Вы проиграли. Кол-во монет {countCoins}, кол-во бомб {bombs}, кол-во жизней {lifes}");
                    Close();
                }
            }

            if (field[Human.y, Human.x] is Bonus)
            {
                field[Human.y, Human.x].Action();
                UpdatePanel(field[Human.y, Human.x], true);
            }
          

            int randInt = ran.Next(0, 15);

            if (bonus == null && randInt == 0)
            {

                int x = 0;
                int y = 0;

                do
                {
                    x = ran.Next(0, field.width);
                    y = ran.Next(0, field.height);

                }
                while (field[y, x] is Empty == false);
                int bonusInt = ran.Next(0, 3);
                switch (bonusInt)
                {
                    case 0:
                        bonus = new AddLife(x, y, 7);

                       
                        break;
                    case 1:
                        bonus = new God(x, y, 7);
                        
                        break;
                    case 2:
                        bonus = new WithoutWalls(x, y, 7);
                        
                        break;
                }
                field[y, x] = bonus;
                UpdatePanel(bonus, true);

            }
            if (bonus != null && bonus.Ready())
            {
                field[bonus.y, bonus.x] = new Empty(bonus.x, bonus.y);
                UpdatePanel(field[bonus.y, bonus.x], true);
                bonus = null;
              


            }
            if (catchBonus != null && catchBonus.Ready())
            {
                catchBonus = null;
                bonus = null;  

            }


        }
    }
}

