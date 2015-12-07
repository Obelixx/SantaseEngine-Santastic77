namespace SantaseEngine.Logic.Handlers.ClosedStock
{
    using System.Collections.Generic;
    using System.Linq;

    using MyCards;
    using Santase.Logic.Cards;
    using Santase.Logic.Players;

    /// <summary>
    /// Play winning card
    /// </summary>
    public class PlayingSecondWinningCardHandler : ILogicHandler
    {
        public ILogicHandler NextHandler { get; set; }

        public PlayerAction Handle(PlayerTurnContext context, MyHand hand, ICollection<Card> playedCards, Player77 player)
        {
            var firstCard = context.FirstPlayedCard;
            var firstCardIsTrump = firstCard.Suit == context.TrumpCard.Suit;
            if (firstCardIsTrump)
            {
                var biggerTrumps = hand.Trumps.Where(c => c.Value.GetValue() > firstCard.GetValue()).ToList();
                if (biggerTrumps.Count >= 1)
                {
                    biggerTrumps.Reverse();
                    return player.PlayCard(biggerTrumps.First().Value);
                }
                else if (hand.Trumps.Count >= 1)
                {
                    return player.PlayCard(hand.Trumps.First().Value);
                }
            }
            else
            {
                var sorter = new CardHelper();
                var sameSuite = new SortedSet<Card>(sorter);
                foreach (var card in hand.LowNonTrumps.Where(c => c.Suit == firstCard.Suit))
                {
                    sameSuite.Add(card);
                }

                foreach (var card in hand.HighNonTrumps.Where(c => c.Suit == firstCard.Suit))
                {
                    sameSuite.Add(card);
                }

                var biggerNonTrumps = sameSuite.Where(c => c.GetValue() > firstCard.GetValue()).ToList();
                if (biggerNonTrumps.Count >= 1)
                {
                    biggerNonTrumps.Reverse();
                    return player.PlayCard(biggerNonTrumps.First());
                }
                else if (sameSuite.Count >= 1)
                {
                    return player.PlayCard(sameSuite.First());
                }
            }

            return this.NextHandler.Handle(context, hand, playedCards, player);
        }
    }
}
