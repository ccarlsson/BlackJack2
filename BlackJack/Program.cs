using System;

namespace BlackJack
{
    class Program
    {
        static void Main(string[] args)
        {
            Player player = new Player();
            Player dealer = new Player();
            Deck deck = new Deck(1, new BlackJackRandom());

            Game game = new Game(player, dealer, deck);
            bool gameOn = true;
            double playerWins = 0;
            double dealerWins = 0;

            while (gameOn)
            {

                game.PlayerDraw();
                game.DealerDraw();
                game.PlayerDraw();
                game.DealerDraw();



                while (true)
                {
                    Console.Clear();
                    Console.WriteLine("Dealern har:");
                    Console.WriteLine(game.DealerLastDrawnCard);

                    Console.WriteLine("Du har:");
                    foreach (var card in game.PlayerHand)
                    {
                        Console.WriteLine(card);
                    }
                    Console.WriteLine($"The total is {game.PlayerBestValue}");

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
                foreach (var card in game.PlayerHand)
                {
                    Console.WriteLine(card);
                }
                Console.WriteLine($"The total is {game.PlayerBestValue}");

                Console.WriteLine("Dealern har:");
                foreach (var card in game.DealerHand)
                {
                    Console.WriteLine(card);
                }
                Console.WriteLine($"The total is {game.DealerBestValue}");

                switch (game.Status)
                {
                    case GameStatus.Won:
                        Console.WriteLine("Grattis du vann!");
                        playerWins += 1;
                        break;
                    case GameStatus.Lost:
                        Console.WriteLine("Dealern vann!");
                        dealerWins += 1;
                        break;
                    case GameStatus.Tie:
                        Console.WriteLine("Det blev lika!");
                        break;
                    case GameStatus.BlackJack:
                        Console.WriteLine("Grattis du vann!");
                        playerWins += 1.5;
                        break;
                    default:
                        break;
                }

                Console.WriteLine("Vill du spela igen? (y/N)");
                gameOn = Console.ReadKey(true).Key == ConsoleKey.Y ? true : false;
                if (gameOn)
                {
                    Console.WriteLine("____________________________________");
                    Console.WriteLine("====================================");
                }
                game.Reset();
            }

            Console.WriteLine($"Du vann {playerWins} gånger, Dealern vann {dealerWins} gånger.");
        }
    }
}
