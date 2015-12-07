namespace SantaseEngine.Logic.Handlers.OpenStock
{
    using System.Collections.Generic;
    using System.Linq;

    using MyCards;
    using Santase.Logic.Cards;
    using Santase.Logic.Players;

    /// <summary>
    /// Did i have 10 or Ace (same suit)?
    /// </summary>
    public class PlayingSecondPlay10orAceHandler : ILogicHandler
    {
        public ILogicHandler NextHandler { get; set; }

        public PlayerAction Handle(PlayerTurnContext context, MyHand hand, ICollection<Card> playedCards, Player77 player)
        {
            // did i have 10 or Ace (same suit)
            var higherTenOrAce = hand.HighNonTrumps.Where(c => c.Suit == context.FirstPlayedCard.Suit &&
                                                                c.GetValue() > context.FirstPlayedCard.GetValue())
                                                                .Reverse()
                                                                .ToList();
            if (higherTenOrAce.Count >= 1)
            {
                return player.PlayCard(higherTenOrAce.First());
            }

            return this.NextHandler.Handle(context, hand, playedCards, player);
        }
    }
}
