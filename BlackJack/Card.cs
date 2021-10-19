namespace BlackJack
{
    public class Card
    {
        public int Value { get; set; }
        public SuitType Suit { get; set; }
        public int BlackJackValue { get; set; }

        public Card(int value, SuitType suit)
        {
            Value = value;
            Suit = suit;
        }

        public override string ToString()
        {
            var symbol = Value.ToString();
            
            if (Value == 1) symbol = "Ace";
            if (Value > 10)
            {
                switch( Value ) {
                    case 11:
                        symbol = "Jack";
                        break;
                    case 12:
                        symbol = "Queen";
                        break;
                    case 13:
                        symbol = "King";
                        break;
                    default:
                        throw new System.Exception("WTF!");

                }
            }
            

            return $"{symbol} of {Suit}";
        }
    }
}
