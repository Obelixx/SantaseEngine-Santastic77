namespace SantaseEngine
{
    using System;
    using System.Collections.Generic;

    using Logic;
    using Logic.Handlers;

    using Logic.MyCards;
    using Santase.Logic.Cards;
    using Santase.Logic.PlayerActionValidate;
    using Santase.Logic.Players;

    public class Player77 : BasePlayer
    {
        protected readonly ICollection<Card> PlayedCards = new List<Card>();

        public Player77()
                : this("Santastic77")
        {
        }

        public Player77(string name)
        {
            this.Name = name;
            this.PlayerActionValidatorer = new PlayerActionValidator();
        }

        public override string Name { get; }

        public IPlayerActionValidator PlayerActionValidatorer { get; }

        public override PlayerAction GetTurn(PlayerTurnContext context)
        {
            var hand = new MyHand(context, this.Cards, this.PlayedCards);
            ILogicHandler logicHandler;
            if (context.State.ShouldObserveRules)
            {
                if (context.IsFirstPlayerTurn)
                {
                    logicHandler = new PlayingFirstClosedStockLogic().Handler;
                }
                else
                {
                    logicHandler = new PlayingSecondClosedStockLogic().Handler;
                }
            }
            else
            {
                if (context.IsFirstPlayerTurn)
                {
                    logicHandler = new PlayingFirstOpenStockLogic().Handler;
                }
                else
                {
                    logicHandler = new PlayingSecondOpenStockLogic().Handler;
                }
            }

            return logicHandler.Handle(context, hand, this.PlayedCards, this);
        }

        public override void EndRound()
        {
            this.PlayedCards.Clear();
            base.EndRound();
        }

        public override void EndTurn(PlayerTurnContext context)
        {
            this.PlayedCards.Add(context.FirstPlayedCard);
            this.PlayedCards.Add(context.SecondPlayedCard);
        }

        public new PlayerAction ChangeTrump(Card trumpCard)
        {
            this.Cards.Remove(new Card(trumpCard.Suit, CardType.Nine));
            this.Cards.Add(trumpCard);
            return PlayerAction.ChangeTrump();
        }

        public new PlayerAction PlayCard(Card card)
        {
            this.Cards.Remove(card);
            return PlayerAction.PlayCard(card);
        }

        public new PlayerAction CloseGame()
        {
            return PlayerAction.CloseGame();
        }
    }
}
