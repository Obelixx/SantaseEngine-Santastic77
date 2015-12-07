namespace SantaseEngine.Logic.Handlers.OpenStock
{
    using System.Collections.Generic;
    using System.Linq;

    using MyCards;
    using Santase.Logic.Cards;
    using Santase.Logic.Players;

    /// <summary>
    /// Did i have non-trump 9 or J to play?
    /// Did i have free(with played other) Q or K (hand design)?
    /// </summary>
    public class PlayingFirstPlayLowNonTrumpHandler : ILogicHandler
    {
        public ILogicHandler NextHandler { get; set; }

        public PlayerAction Handle(PlayerTurnContext context, MyHand hand, ICollection<Card> playedCards, Player77 player)
        {
            if (hand.LowNonTrumps.Count >= 1)
            {
                return player.PlayCard(hand.LowNonTrumps.First());
            }

            return this.NextHandler.Handle(context, hand, playedCards, player);
        }
    }
}
