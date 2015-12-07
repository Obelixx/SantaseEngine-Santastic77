namespace SantaseEngine.Logic.Handlers.OpenStock
{
    using System.Collections.Generic;
    using System.Linq;

    using MyCards;
    using Santase.Logic.Cards;
    using Santase.Logic.Players;

    /// <summary>
    /// Did i have Q or K(played or others played card) (same suit) ?
    /// Did i have other non-trump?
    /// </summary>
    public class PlayingSecondPlayLowNonTrumpHandler : ILogicHandler
    {
        public ILogicHandler NextHandler { get; set; }

        public PlayerAction Handle(PlayerTurnContext context, MyHand hand, ICollection<Card> playedCards, Player77 player)
        {
            var playedCardValue = context.FirstPlayedCard.GetValue();

            var otherHigherFreeNonTrump = hand.LowNonTrumps.Where(c => c.GetValue() > playedCardValue).Reverse().ToList();

            if (otherHigherFreeNonTrump.Count >= 1)
            {
                    return player.PlayCard(otherHigherFreeNonTrump.First());
            }
            else if (hand.LowNonTrumps.Count >= 1)
            {
                return player.PlayCard(hand.LowNonTrumps.First());
            }

            return this.NextHandler.Handle(context, hand, playedCards, player);
        }
    }
}
