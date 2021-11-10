namespace BlackJack;
public class Player
{
    public List<Card> Hand = new List<Card>();
    public Card LastDrawnCard;
    public int LowValue
    {
        get
        {
            int result = 0;
            foreach (var card in Hand)
            {
                if (card.Value > 9)
                {
                    result += 10;
                }
                else
                {
                    result += card.Value;
                }
            }
            return result;
        }
    }
    public int HighValue
    {
        get
        {
            int result = 0;
            foreach (var card in Hand)
            {
                if (card.Value > 9)
                {
                    result += 10;
                }
                else
                {
                    result += card.Value;
                    if (card.Value == 1)
                        result += 10;
                }
            }
            return result;
        }
    }

    public int BestValue =>
        HighValue <= 21 ? HighValue : LowValue;


    public void Reset()
    {
        Hand = new List<Card>();

    }

    public override string ToString()
    {
        return $"LowValue {LowValue}; HighValue {HighValue}; BestValue {BestValue}";
    }
}
