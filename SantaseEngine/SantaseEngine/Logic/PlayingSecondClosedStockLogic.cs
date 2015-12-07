namespace SantaseEngine.Logic.Handlers
{
    using ClosedStock;
    using Common;
    using SantaseEngine.Logic.Contracts;

    public class PlayingSecondClosedStockLogic : ILogic
    {
        public PlayingSecondClosedStockLogic()
        {
            var playingFirst = new PlayingSecondWinningCardHandler();
            var playLowTrump = new PlayingSecondPlayLowTrumpHandler();
            var playAny = new PlayAnyCardHandler();

            playingFirst.NextHandler = playLowTrump;
            playLowTrump.NextHandler = playAny;

            this.Handler = playingFirst;
        }

        public ILogicHandler Handler { get; set; }
    }
}
