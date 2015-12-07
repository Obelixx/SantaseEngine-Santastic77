namespace SantaseEngine.Logic.Handlers.OpenStock
{
    using System.Collections.Generic;

    using Common;
    using MyCards;
    using Santase.Logic.Cards;
    using Santase.Logic.Players;
    using SantaseEngine.Logic.Handlers;

    /// <summary>
    /// Is it trump?
    /// </summary>
    public class PlayingSecondPlayOnTrumpsHandler : ILogicHandler
    {
        public ILogicHandler NextHandler { get; set; }

        public PlayerAction Handle(PlayerTurnContext context, MyHand hand, ICollection<Card> playedCards, Player77 player)
        {
            var playedCardIsTrump = context.TrumpCard.Suit == context.FirstPlayedCard.Suit;

            if (playedCardIsTrump)
            {
                return new PlayAnyCardHandler().Handle(context, hand, playedCards, player);
            }

            return this.NextHandler.Handle(context, hand, playedCards, player);
        }
    }
}
