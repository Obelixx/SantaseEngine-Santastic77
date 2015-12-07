namespace SantaseEngine.Logic.Handlers.OpenStock
{
    using System.Collections.Generic;
    using System.Linq;

    using MyCards;
    using Santase.Logic.Cards;
    using Santase.Logic.Players;

    /// <summary>
    /// Did i have J trump or 9 when J is UP ? 
    /// </summary>
    public class PlayingSecondPlayLowTrumpHandler : ILogicHandler
    {
        public ILogicHandler NextHandler { get; set; }

        public PlayerAction Handle(PlayerTurnContext context, MyHand hand, ICollection<Card> playedCards, Player77 player)
        {
            var lowTrumps = hand.Trumps.Where(c => c.Key == 2 || (c.Key == 0 && hand.IsJackOrNineTrumpCard) || c.Key >= 10).ToList();
            if (lowTrumps.Count >= 1)
            {
                return player.PlayCard(lowTrumps.First().Value);
            }

            return this.NextHandler.Handle(context, hand, playedCards, player);
        }
    }
}
