namespace SantaseEngine.Logic.MyCards
{
    using System.Collections.Generic;

    using Santase.Logic.Cards;

    public class CardHelper : IComparer<Card>
    {
        private const int MaxCards = 52;
        
        public static ICollection<Card> OthersCards(CardHelper sorter, ICollection<Card> playedCards, ICollection<Card> myCards)
        {
            SortedSet<Card> allCards = new SortedSet<Card>(sorter)
            {
                new Card(CardSuit.Club, CardType.Ace),
                new Card(CardSuit.Club, CardType.Ten),
                new Card(CardSuit.Club, CardType.King),
                new Card(CardSuit.Club, CardType.Queen),
                new Card(CardSuit.Club, CardType.Jack),
                new Card(CardSuit.Club, CardType.Nine),

                new Card(CardSuit.Diamond, CardType.Ace),
                new Card(CardSuit.Diamond, CardType.Ten),
                new Card(CardSuit.Diamond, CardType.King),
                new Card(CardSuit.Diamond, CardType.Queen),
                new Card(CardSuit.Diamond, CardType.Jack),
                new Card(CardSuit.Diamond, CardType.Nine),

                new Card(CardSuit.Heart, CardType.Ace),
                new Card(CardSuit.Heart, CardType.Ten),
                new Card(CardSuit.Heart, CardType.King),
                new Card(CardSuit.Heart, CardType.Queen),
                new Card(CardSuit.Heart, CardType.Jack),
                new Card(CardSuit.Heart, CardType.Nine),

                new Card(CardSuit.Spade, CardType.Ace),
                new Card(CardSuit.Spade, CardType.Ten),
                new Card(CardSuit.Spade, CardType.King),
                new Card(CardSuit.Spade, CardType.Queen),
                new Card(CardSuit.Spade, CardType.Jack),
                new Card(CardSuit.Spade, CardType.Nine),
            };

            foreach (var card in playedCards)
            {
                allCards.Remove(card);
            }

            foreach (var card in myCards)
            {
                allCards.Remove(card);
            }

            return allCards;
        }
        
        public int Compare(Card x, Card y)
        {
            var result = x.Suit.CompareTo(y.Suit);
            if (result == 0)
            {
                result = x.GetValue().CompareTo(y.GetValue());
            }

            return result;
        }
    }
}
