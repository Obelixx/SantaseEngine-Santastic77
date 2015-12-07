namespace SantaseEngine.Logic
{
    using Handlers;
    using Handlers.Common;
    using SantaseEngine.Logic.Contracts;
    using SantaseEngine.Logic.Handlers.OpenStock;

    public class PlayingSecondOpenStockLogic : ILogic
    {
        public PlayingSecondOpenStockLogic()
        {
            var playingSecond = new PlayingSecondPlayOnTrumpsHandler();
            var playTrump = new PlayingSecondPlayTrumpHighCardsHandler();
            var play10OrAce = new PlayingSecondPlay10orAceHandler();
            var playLowNonTrump = new PlayingSecondPlayLowNonTrumpHandler();
            var playLowTrump = new PlayingSecondPlayLowTrumpHandler();
            var playHighNonTrump = new PlayingSecondPlayHighNonTrumpHandler();
            var playAny = new PlayAnyCardHandler();

            playingSecond.NextHandler = play10OrAce;
            play10OrAce.NextHandler = playLowNonTrump;
            playLowNonTrump.NextHandler = playLowTrump;
            playLowTrump.NextHandler = playHighNonTrump;
            playingSecond.NextHandler = playTrump;
            playTrump.NextHandler = playAny;

            this.Handler = playingSecond;
        }

        public ILogicHandler Handler { get; set; }
    }
}
