namespace SantaseEngine.Logic.Handlers.ClosedStock
{
    using System.Collections.Generic;
    using System.Linq;

    using MyCards;
    using Santase.Logic.Cards;
    using Santase.Logic.Players;

    /// <summary>
    /// Play low trump card.
    /// </summary>
    public class PlayingSecondPlayLowTrumpHandler : ILogicHandler
    {
        public ILogicHandler NextHandler { get; set; }

        public PlayerAction Handle(PlayerTurnContext context, MyHand hand, ICollection<Card> playedCards, Player77 player)
        {
            if (hand.Trumps.Count >= 1)
            {
                return player.PlayCard(hand.Trumps.First().Value);
            }

            return this.NextHandler.Handle(context, hand, playedCards, player);
        }
    }
}
