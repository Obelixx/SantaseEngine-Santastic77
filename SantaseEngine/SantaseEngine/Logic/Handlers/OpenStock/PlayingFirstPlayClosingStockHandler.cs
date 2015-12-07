namespace SantaseEngine.Logic.Handlers.OpenStock
{
    using System.Collections.Generic;
    using System.Linq;

    using MyCards;
    using Santase.Logic.Cards;
    using Santase.Logic.Players;

    /// <summary>
    /// Detect close conditions.
    /// </summary>
    public class PlayingFirstPlayClosingStockHandler : ILogicHandler
    {
        private const int PointsToClose = 64;

        public ILogicHandler NextHandler { get; set; }

        public PlayerAction Handle(PlayerTurnContext context, MyHand hand, ICollection<Card> playedCards, Player77 player)
        {
            bool closeConditions = false;
            int pintsSoFar = context.FirstPlayerRoundPoints;

            bool haveTrumpAce = hand.Trumps.ContainsKey(11);
            bool haveTrump10 = hand.Trumps.ContainsKey(10);
            bool haveTrumpKing = hand.Trumps.ContainsKey(4);
            bool haveTrumpQueen = hand.Trumps.ContainsKey(3);

            bool trumpAceIsGone = playedCards.Contains(new Card(context.TrumpCard.Suit, CardType.Ace));

            int acesCount = hand.HighNonTrumps.Count(c => c.Type == CardType.Ace);
            int tensWithGoneAceCount = hand.HighNonTrumps.Count(c => c.Type == CardType.Ten && playedCards.Contains(new Card(c.Suit, CardType.Ace)));

            if (player.PlayerActionValidatorer.IsValid(PlayerAction.CloseGame(), context, hand.AllCards))
            {
                if (haveTrumpAce)
                {
                    pintsSoFar += 11;
                }

                if ((haveTrump10 && haveTrumpAce) || (haveTrump10 && trumpAceIsGone))
                {
                    pintsSoFar += 10;
                }

                if (haveTrumpKing && haveTrumpQueen)
                {
                    pintsSoFar += 40;
                }

                if ((haveTrump10 && haveTrumpAce) || (haveTrump10 && trumpAceIsGone))
                {
                    pintsSoFar += acesCount * 11;
                    pintsSoFar += tensWithGoneAceCount * 10;
                }

                closeConditions = pintsSoFar >= PointsToClose;
            }

            if (closeConditions)
            {
                return player.CloseGame();
            }

            return this.NextHandler.Handle(context, hand, playedCards, player);
        }
    }
}