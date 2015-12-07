namespace SantaseEngine.Logic.MyCards
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Santase.Logic.Cards;
    using Santase.Logic.Players;

    public class MyHand
    {
        public MyHand(PlayerTurnContext context, ICollection<Card> hand, ICollection<Card> playedCards)
        {
            var comparer = new CardHelper();

            this.AllCards = new SortedSet<Card>(comparer);
            this.Trumps = new SortedDictionary<int, Card>();
            this.LowNonTrumps = new SortedSet<Card>(comparer);
            this.HighNonTrumps = new SortedSet<Card>(comparer);
            this.Locked = new SortedSet<Card>(comparer);

            var trumpSuit = context.TrumpCard.Suit;
            var trumpValue = context.TrumpCard.GetValue();

            foreach (var card in hand)
            {
                if (!context.State.ShouldObserveRules && (card.Type == CardType.Queen || card.Type == CardType.King))
                {
                    this.Locked.Add(card);
                }
                else if (card.Suit == trumpSuit)
                {
                    this.Trumps.Add(card.GetValue(), card);
                }
                else
                {
                    if (card.Type == CardType.Ace || card.Type == CardType.Ten)
                    {
                        this.HighNonTrumps.Add(card);
                    }
                    else
                    {
                        this.LowNonTrumps.Add(card);
                    }
                }

                this.AllCards.Add(card);
            }

            var cardsToMove = new List<Card>();
            foreach (var card in this.Locked)
            {
                var theOtherCard = new Card(card.Suit, this.ReverseQueenAndKingType(card.Type));
                if (playedCards.Contains(theOtherCard) || (!context.IsFirstPlayerTurn && context.FirstPlayedCard.Equals(theOtherCard)))
                {
                    cardsToMove.Add(card);
                }
            }

            foreach (var card in cardsToMove)
            {
                this.Locked.Remove(card);
                if (card.Suit == trumpSuit)
                {
                    this.Trumps.Add(card.GetValue(), card);
                }
                else
                {
                    this.LowNonTrumps.Add(card);
                }
            }

            this.Locked.OrderBy(c => c.Suit == trumpSuit ? 2 : 1);

            this.IsJackOrNineTrumpCard = context.TrumpCard.Type == CardType.Nine || context.TrumpCard.Type == CardType.Jack;
        }

        public ISet<Card> AllCards { get; set; }

        public IDictionary<int, Card> Trumps { get; set; }
        
        public ISet<Card> LowNonTrumps { get; set; }

        public ISet<Card> HighNonTrumps { get; set; }

        public ISet<Card> Locked { get; set; }

        public bool IsJackOrNineTrumpCard { get; set; }

        private CardType ReverseQueenAndKingType(CardType cardtypeToReverse)
        {
            if (cardtypeToReverse == CardType.Queen)
            {
                return CardType.King;
            }

            if (cardtypeToReverse == CardType.King)
            {
                return CardType.Queen;
            }

            throw new ArgumentException("Error: Bad CardType passed!");
        }
    }
}