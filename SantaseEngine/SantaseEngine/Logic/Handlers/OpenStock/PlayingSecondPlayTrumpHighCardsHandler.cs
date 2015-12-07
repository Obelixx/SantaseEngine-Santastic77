namespace SantaseEngine.Logic.Handlers.OpenStock
{
    using System.Collections.Generic;
    using System.Linq;

    using MyCards;
    using Santase.Logic.Cards;
    using Santase.Logic.Players;

    /// <summary>
    /// Is it high card to trump it? (with J(free 9)) ?
    /// </summary>
    public class PlayingSecondPlayTrumpHighCardsHandler : ILogicHandler
    {
        public ILogicHandler NextHandler { get; set; }

        public PlayerAction Handle(PlayerTurnContext context, MyHand hand, ICollection<Card> playedCards, Player77 player)
        {
            if (context.FirstPlayedCard.GetValue() >= 10 && context.FirstPlayedCard.Suit != context.TrumpCard.Suit)
            {
                var trumps = hand.Trumps.Where(c => (!(c.Value.GetValue() == 0) && hand.IsJackOrNineTrumpCard) || !(c.Value.GetValue() == 2) || c.Value.GetValue() == 3 || c.Value.GetValue() == 4).ToList();
                if (trumps.Count >= 1)
                {
                    return player.PlayCard(trumps.First().Value);
                }
            }

            return this.NextHandler.Handle(context, hand, playedCards, player);
        }
    }
}
