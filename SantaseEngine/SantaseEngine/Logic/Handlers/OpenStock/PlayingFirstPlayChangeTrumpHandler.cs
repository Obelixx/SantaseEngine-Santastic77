namespace SantaseEngine.Logic.Handlers.OpenStock
{
    using System.Collections.Generic;
    using MyCards;
    using Santase.Logic.Cards;
    using Santase.Logic.Players;

    /// <summary>
    /// Change trump without J
    /// </summary>
    public class PlayingFirstPlayChangeTrumpHandler : ILogicHandler
    {
        public ILogicHandler NextHandler { get; set; }

        public PlayerAction Handle(PlayerTurnContext context, MyHand hand, ICollection<Card> playedCards, Player77 player)
        {
            if (context.State.CanChangeTrump && !hand.IsJackOrNineTrumpCard)
            {
                if (player.PlayerActionValidatorer.IsValid(PlayerAction.ChangeTrump(), context, hand.AllCards))
                {
                    return player.ChangeTrump(context.TrumpCard);
                }
            }

            return this.NextHandler.Handle(context, hand, playedCards, player);
        }
    }
}
