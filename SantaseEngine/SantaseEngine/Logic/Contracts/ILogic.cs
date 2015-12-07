namespace SantaseEngine.Logic.Contracts
{
    using SantaseEngine.Logic.Handlers;

    public interface ILogic
    {
        ILogicHandler Handler { get; set; }
    }
}