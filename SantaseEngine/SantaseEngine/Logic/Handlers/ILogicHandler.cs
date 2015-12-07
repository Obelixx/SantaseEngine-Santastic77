namespace SantaseEngine.Logic.Handlers
{
    using System.Collections.Generic;
    using Santase.Logic.Cards;
    using Santase.Logic.Players;
    using SantaseEngine.Logic.MyCards;

    public interface ILogicHandler
    {
        PlayerAction Handle(PlayerTurnContext context, MyHand hand, ICollection<Card> playedCards, Player77 player);
    }
}