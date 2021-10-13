using System.Collections.Generic;

namespace BlackJack
{
    public class Game
    {
        private Player _player;
        private Player _dealer;

        private Deck _deck = new Deck(1);

        public GameStatus Status = GameStatus.Playing;

        public Game(Player player, Player dealer, Deck deck)
        {
            _player = player;
            _dealer = dealer;
            _deck = deck;
        }

        public void Reset()
        {
            _player.Reset();
            _dealer.Reset();
            Status = GameStatus.Playing;
        }

        public void PlayerDraw()
        {
            Card card = _deck.Draw();
            _player.Hand.Add(card);
            _player.LastDrawnCard = card;

            if (_player.BestValue > 21)
            {
                Status = GameStatus.Lost;
            }
            if (_player.BestValue == 21 && _player.Hand.Count == 2)
            {
                Status = GameStatus.BlackJack;
            }
        }

        public void DealerDraw()
        {
            Card card = _deck.Draw();
            _dealer.Hand.Add(card);
            _dealer.LastDrawnCard = card;

            if (_dealer.BestValue < 17)
                return;
            else if (_dealer.BestValue > 21)
                Status = GameStatus.Won;
            else if (_dealer.BestValue < _player.BestValue)
                Status = GameStatus.Won;
            else if (_dealer.BestValue > _player.BestValue)
                Status = GameStatus.Lost;
            else
                Status = GameStatus.Tie;
        }

        public Card DealerLastDrawnCard => _dealer.LastDrawnCard; 
        public IEnumerable<Card> PlayerHand => _player.Hand;
        public IEnumerable<Card> DealerHand => _dealer.Hand; 
        public int DealerBestValue => _dealer.BestValue;
        public int PlayerBestValue => _player.BestValue;
        
    }
}
