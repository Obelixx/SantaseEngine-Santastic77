namespace SantaseEngine.Logic.Handlers.Common
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using MyCards;
    using Santase.Logic.Cards;
    using Santase.Logic.Players;

    public class PlayAnyCardHandler : ILogicHandler
    {
        public PlayerAction Handle(PlayerTurnContext context, MyHand hand, ICollection<Card> playedCards, Player77 player)
        {
            if (hand.LowNonTrumps.Count >= 1)
            {
                return player.PlayCard(hand.LowNonTrumps.First());
            }
            else if (hand.HighNonTrumps.Count >= 1)
            {
                return player.PlayCard(hand.HighNonTrumps.First());
            }
            else if (hand.Trumps.Count >= 1)
            {
                return player.PlayCard(hand.Trumps.First().Value);
            }
            else
            {
                return player.PlayCard(hand.Locked.First());
            }
        }
    }
}
