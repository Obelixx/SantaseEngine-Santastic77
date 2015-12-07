namespace SantaseEngine.Logic.Handlers.ClosedStock
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using MyCards;
    using Santase.Logic.Cards;
    using Santase.Logic.Players;

    /// <summary>
    /// Play WinningCardsFirst
    /// </summary>
    public class PlayingFirstWinningCardsHandler : ILogicHandler
    {
        public ILogicHandler NextHandler { get; set; }

        public PlayerAction Handle(PlayerTurnContext context, MyHand hand, ICollection<Card> playedCards, Player77 player)
        {
            var sorter = new CardHelper();
            var othersCards = CardHelper.OthersCards(sorter, playedCards, hand.AllCards);

            foreach (var item in hand.Trumps)
            {
                if (!othersCards.Any(c => c.GetValue() > item.Value.GetValue()))
                {
                    return player.PlayCard(item.Value);
                }
            }

            foreach (var item in hand.HighNonTrumps)
            {
                if (!othersCards.Any(c => c.GetValue() > item.GetValue()) && othersCards.Any(c => c.GetValue() < item.GetValue()))
                {
                    return player.PlayCard(item);
                }
            }

            foreach (var item in hand.LowNonTrumps.Reverse())
            {
                if (!othersCards.Any(c => c.GetValue() > item.GetValue()) && othersCards.Any(c => c.GetValue() < item.GetValue()))
                {
                    return player.PlayCard(item);
                }
            }

            return this.NextHandler.Handle(context, hand, playedCards, player);
        }
    }
}
