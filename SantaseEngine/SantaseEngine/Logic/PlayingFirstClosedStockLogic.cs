namespace SantaseEngine.Logic.Handlers
{
    using ClosedStock;
    using Common;
    using SantaseEngine.Logic.Contracts;

    public class PlayingFirstClosedStockLogic : ILogic
    {
        public PlayingFirstClosedStockLogic()
        {
            var playingFirst = new PlayingFirstWinningCardsHandler();
            var announce20or40 = new PlayingFirstPlayAnnounceHandler();
            var playAny = new PlayAnyCardHandler();

            playingFirst.NextHandler = announce20or40;
            announce20or40.NextHandler = playAny;

            this.Handler = playingFirst;
        }

        public ILogicHandler Handler { get; set; }
    }
}
