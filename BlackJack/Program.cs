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
            Console.WriteLine("Du har:");
            foreach (var card in game.Player.Hand)
            {
                Console.WriteLine(card);
            }
        }
    }
}
