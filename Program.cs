using System;

class Program
{
    static void Main()
    {
        int score = 0;
        int lives = 3;

        int basket = 10;
        int coinX = 10;
        int coinY = 3;

        int speed = 120;

        Random random = new Random();

        Console.CursorVisible = false;

        while (lives > 0)
        {
           
            while (Console.KeyAvailable)
            {
                ConsoleKey key = Console.ReadKey(true).Key;

                if (key == ConsoleKey.LeftArrow && basket > 1)
                    basket--;

                if (key == ConsoleKey.RightArrow && basket < 24)
                    basket++;
            }

            Console.Clear();


            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.SetCursorPosition(5, 0);
            Console.Write("******** COIN CATCHER ********");

       
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(3, 1);
            Console.Write("Catch the falling coin!");

      
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(coinX, coinY);
            Console.Write("O");


            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.SetCursorPosition(basket, 15);
            Console.Write("[###]");

       
            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(0, 16);
            Console.Write("--------------------------------");

         
            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(2, 18);
            Console.Write("Score: " + score);

           
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(20, 18);
            Console.Write("Lives: " + lives);

           
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.SetCursorPosition(3, 20);
            Console.Write("Put the Coin in the Basket!");

            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(7, 21);
            Console.Write("<- LEFT       RIGHT ->");

            
            coinY++;

        
            if (coinY >= 15)
            {
                if (coinX >= basket && coinX <= basket + 4)
                {
                    score++;

                   // after the 5 coin drop the speed increases
                    if (score % 5 == 0 && speed > 40)
                    {
                        speed -= 15;
                    }
                }
                else
                {
                    lives--;
                }

                
                coinX = random.Next(1, 25);
                coinY = 3;
            }

            
            System.Threading.Thread.Sleep(speed);
        }

       
        Console.Clear();

        Console.ForegroundColor = ConsoleColor.Red;
        Console.SetCursorPosition(7, 5);
        Console.Write("********************");
        Console.SetCursorPosition(7, 6);
        Console.Write("*    GAME OVER     *");
        Console.SetCursorPosition(7, 7);
        Console.Write("********************");

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.SetCursorPosition(10, 9);
        Console.Write("Score: " + score);

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.SetCursorPosition(5, 11);
        Console.Write("Press any key to exit...");

        Console.ResetColor();
        Console.ReadKey();
    }
}