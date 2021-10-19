using System;

namespace BlackJack
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();
            bool gameOn = true;


            while (gameOn)
            {

                game.PlayerDraw();
                game.DealerDraw();
                game.PlayerDraw();
                game.DealerDraw();

                Console.WriteLine("Dealern har:");
                Console.WriteLine(game.Dealer.LastDrawnCard);


                while (true && game.Status != GameStatus.BlackJack)
                {
                    Console.WriteLine("Du har:");
                    foreach (var card in game.Player.Hand)
                    {
                        Console.WriteLine(card);
                    }
                    Console.WriteLine($"The total is {game.Player.BestValue}");

                    Console.WriteLine("Vill du forstätta och dra ett kort till? (y/N)");
                    if (Console.ReadKey(true).Key != ConsoleKey.Y) break;


                    game.PlayerDraw();

                    if (game.Status == GameStatus.Lost) break;
                }

                while (game.Status == GameStatus.Playing)
                {
                    game.DealerDraw();
                }

                Console.WriteLine("Du har:");
                foreach (var card in game.Player.Hand)
                {
                    Console.WriteLine(card);
                }
                Console.WriteLine($"The total is {game.Player.BestValue}");

                Console.WriteLine("Dealern har:");
                foreach (var card in game.Dealer.Hand)
                {
                    Console.WriteLine(card);
                }
                Console.WriteLine($"The total is {game.Dealer.BestValue}");

                switch (game.Status)
                {
                    case GameStatus.Won:
                        Console.WriteLine("Grattis du vann!");
                        break;
                    case GameStatus.Lost:
                        Console.WriteLine("Dealern vann!");
                        break;
                    case GameStatus.Tie:
                        Console.WriteLine("Det blev lika!");
                        break;
                    case GameStatus.BlackJack:
                        Console.WriteLine("Grattis du vann!");
                        break;
                    default:
                        break;
                }

                Console.Write("Vill du spela igen? (y/N)");
                gameOn = Console.ReadKey(true).Key == ConsoleKey.Y ? true : false;
                game.Reset();
            }
        }
    }
}
