namespace BlackJack
{
    public class Game
    {
        public Player Player = new Player();
        public Player Dealer = new Player();

        public Deck Deck = new Deck(1);
        public GameStatus Status = GameStatus.Playing;

        public Game()
        {

        }

        public void Reset()
        {
            Player.Reset();
            Dealer.Reset();
            Status = GameStatus.Playing;
        }

        public void PlayerDraw()
        {
            Card card = Deck.Draw();
            Player.Hand.Add(card);
            Player.LastDrawnCard = card;

            if (Player.BestValue > 21)
            {
                Status = GameStatus.Lost;
            }
            if (Player.BestValue == 21 && Player.Hand.Count == 2)
            {
                Status = GameStatus.BlackJack;
            }
        }

        public void DealerDraw()
        {
            Card card = Deck.Draw();
            Dealer.Hand.Add(card);
            Dealer.LastDrawnCard = card;

            if (Dealer.BestValue < 17)
                return;
            else if (Dealer.BestValue > 21)
                Status = GameStatus.Won;
            else if (Dealer.BestValue < Player.BestValue)
                Status = GameStatus.Won;
            else if (Dealer.BestValue > Player.BestValue)
                Status = GameStatus.Lost;
            else
                Status = GameStatus.Tie;
        }
    }
}
