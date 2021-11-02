using System;
using System.Collections.Generic;

namespace BlackJack
{
    public class Deck
    {
        int _nrOfDecks;
        List<Card> _cards;
        IRandom _random;
        public Deck(int nrOfDecks, IRandom random)
        {
            _nrOfDecks = nrOfDecks;
            _random = random;
            ResetAndShuffle();
        }

        public void ResetAndShuffle()
        {
            _cards = new List<Card>();
            for (int decks = 0; decks < _nrOfDecks; decks++)
            {
                for (int suit = 0; suit < 4; suit++)
                {
                    for (int value = 1; value < 14; value++)
                    {
                        _cards.Add(new Card(value, (SuitType)suit));
                    }
                }
            }
            Shuffle();
        }

        public void Shuffle()
        {
            List<Card> tmpDeck = new();
            while (_cards.Count > 0)
            {
                int index = _random.Next(_cards.Count);
                Card tmpCard = _cards[index];
                tmpDeck.Add(tmpCard);
                _cards.Remove(tmpCard); 
            }
            _cards = tmpDeck; 
        }


        public Card Draw()
        {
            if (_cards.Count < 10) ResetAndShuffle();

            Card card = _cards[0];
            _cards.Remove(card);
            return card;
        }
    }
}
