namespace SantaseEngine.Logic
{
    using Handlers;
    using Handlers.Common;
    using SantaseEngine.Logic.Contracts;
    using SantaseEngine.Logic.Handlers.OpenStock;

    public class PlayingFirstOpenStockLogic : ILogic
    {
        public PlayingFirstOpenStockLogic()
        {
            var detectCloseContitions = new PlayingFirstPlayClosingStockHandler();
            var playFirst = new PlayingFirstPlayChangeTrumpHandler();
            var announce20or40 = new PlayingFirstPlayAnnounceHandler();
            var playLow = new PlayingFirstPlayLowNonTrumpHandler();
            var playAny = new PlayAnyCardHandler();

            detectCloseContitions.NextHandler = playFirst;
            playFirst.NextHandler = announce20or40;
            announce20or40.NextHandler = playLow;
            playLow.NextHandler = playAny;

            this.Handler = playFirst;
        }
        
        public ILogicHandler Handler { get; set; }
    }
}
