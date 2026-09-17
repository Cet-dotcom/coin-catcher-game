using System;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        // Basket position
        int basketX = 250;

        // Coin position
        int coinX = 250;
        int coinY = 80;

        // Game information
        int score = 0;
        int lives = 3;

        // Coin speed
        int speed = 5;

        // Game timer
        Timer timer = new Timer();

        Random random = new Random();

        public Form1()
        {
            InitializeComponent();

          
            this.Text = "Coin Catcher";
            this.ClientSize = new Size(600, 500);
            this.BackColor = Color.FromArgb(25, 25, 35);
            this.KeyPreview = true;
            this.DoubleBuffered = true;

           
            timer.Interval = 30;
            timer.Tick += GameLoop;

            
            this.KeyDown += MoveBasket;

          
            timer.Start();
        }

        void GameLoop(object sender, EventArgs e)
        {
            
            coinY = coinY + speed;

            
            if (coinY >= 380)
            {
              
                if (coinX >= basketX && coinX <= basketX + 100)
                {
                    score++;

                   
                    if (score % 5 == 0)
                    {
                        speed++;
                    }
                }
                else
                {
                   
                    lives--;
                }

                
                coinX = random.Next(20, 550);
                coinY = 80;
            }

           
            if (lives <= 0)
            {
                timer.Stop();

                MessageBox.Show(
                    "GAME OVER!\n\nYour Score: " + score,
                    "Coin Catcher",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                
                score = 0;
                lives = 3;
                speed = 5;

                basketX = 250;
                coinX = random.Next(20, 550);
                coinY = 80;

                timer.Start();
            }

           
            Invalidate();
        }

     
        void MoveBasket(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                basketX = basketX - 25;
            }

            if (e.KeyCode == Keys.Right)
            {
                basketX = basketX + 25;
            }

           
            if (basketX < 10)
            {
                basketX = 10;
            }

            if (basketX > 490)
            {
                basketX = 490;
            }

            
            Invalidate();
        }

      
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics g = e.Graphics;

          

            using (Font titleFont = new Font(
                "Arial",
                24,
                FontStyle.Bold))
            {
                g.DrawString(
                    "COIN CATCHER",
                    titleFont,
                    Brushes.Cyan,
                    190,
                    20
                );
            }

           
          

            g.FillEllipse(
                Brushes.Gold,
                coinX,
                coinY,
                35,
                35
            );

         
            using (Font coinFont = new Font(
                "Arial",
                16,
                FontStyle.Bold))
            {
                g.DrawString(
                    "$",
                    coinFont,
                    Brushes.DarkOrange,
                    coinX + 10,
                    coinY + 5
                );
            }

           
            g.FillRectangle(
                Brushes.Orange,
                basketX,
                380,
                100,
                30
            );

            using (Pen basketPen = new Pen(
                Color.Yellow,
                5))
            {
                g.DrawLine(
                    basketPen,
                    basketX,
                    380,
                    basketX + 100,
                    380
                );
            }

           

            using (Font textFont = new Font(
                "Arial",
                15,
                FontStyle.Bold))
            {
                g.DrawString(
                    "Score: " + score,
                    textFont,
                    Brushes.Lime,
                    20,
                    430
                );

               

                g.DrawString(
                    "Lives: " + lives,
                    textFont,
                    Brushes.Red,
                    470,
                    430
                );

               

                g.DrawString(
                    "Put the Coin in the Basket!",
                    textFont,
                    Brushes.White,
                    170,
                    455
                );

                g.DrawString(
                    "←  LEFT                 RIGHT  →",
                    textFont,
                    Brushes.Magenta,
                    160,
                    480
                );
            }
        }

       
        private void Form1_Load(object sender, EventArgs e)
        {
        }
    }
}