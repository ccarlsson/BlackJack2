using System;

namespace BlackJack
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();

            game.PlayerDraw();
            game.DealerDraw();
            game.PlayerDraw();
            game.DealerDraw();

            Console.WriteLine("Dealern har:");
            Console.WriteLine(game.Dealer.LastDrawnCard);
            

            while (true)
            {
                Console.WriteLine("Du har:");
                foreach (var card in game.Player.Hand)
                {
                    Console.WriteLine(card);
                }
                Console.WriteLine($"The total is {game.Player.BestValue}");

                Console.WriteLine("Vill du forstätta och dra ett kort till? (Y/n)");
                if (Console.ReadKey().KeyChar.ToString().ToLower() != "y") break;

                
                game.PlayerDraw();
                
                if (game.Status == GameStatus.Lost) break; 
            }

            while (game.Status == GameStatus.Playing)
            {
                game.DealerDraw();
            }


        }
    }
}
