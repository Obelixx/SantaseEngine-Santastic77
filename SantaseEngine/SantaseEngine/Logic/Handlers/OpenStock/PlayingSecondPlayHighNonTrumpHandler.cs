namespace SantaseEngine.Logic.Handlers.OpenStock
{
    using System.Collections.Generic;
    using System.Linq;

    using MyCards;
    using Santase.Logic.Cards;
    using Santase.Logic.Players;

    /// <summary>
    /// Compromise
    /// </summary>
    public class PlayingSecondPlayHighNonTrumpHandler : ILogicHandler
    {
        public ILogicHandler NextHandler { get; set; }

        public PlayerAction Handle(PlayerTurnContext context, MyHand hand, ICollection<Card> playedCards, Player77 player)
        {
            if (hand.HighNonTrumps.Count >= 1)
            {
                return player.PlayCard(hand.HighNonTrumps.First());
            }

            return this.NextHandler.Handle(context, hand, playedCards, player);
        }
    }
}
