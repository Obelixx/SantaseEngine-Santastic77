namespace SantaseEngine.Logic.Handlers.Common
{
    using System.Collections.Generic;
    using System.Linq;

    using MyCards;
    using Santase.Logic.Cards;
    using Santase.Logic.Players;

    /// <summary>
    /// Did i have 20/40 to announce?
    /// </summary>
    public class PlayingFirstPlayAnnounceHandler : ILogicHandler
    {
        public ILogicHandler NextHandler { get; set; }

        public PlayerAction Handle(PlayerTurnContext context, MyHand hand, ICollection<Card> playedCards, Player77 player)
        {
            var queenCardsWithKing = hand.Locked.Where(c => c.Type == CardType.Queen && hand.Locked.Contains(new Card(c.Suit, CardType.King))).ToList();
            if (context.State.CanAnnounce20Or40 && queenCardsWithKing.Count >= 1)
            {
                if (queenCardsWithKing.Contains(new Card(context.TrumpCard.Suit, CardType.Queen)))
                {
                    return player.PlayCard(queenCardsWithKing.Where(c => c.Suit == context.TrumpCard.Suit).First());
                }
            }

            if (queenCardsWithKing.Count == 1)
            {
                return player.PlayCard(queenCardsWithKing.First());
            }

            return this.NextHandler.Handle(context, hand, playedCards, player);
        }
    }
}
