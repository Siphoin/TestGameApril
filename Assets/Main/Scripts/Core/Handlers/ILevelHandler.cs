using UniRx;

namespace TestGame.Core.Handlers
{
    public interface ILevelHandler
    {
        ISubject<GameState> OnGameStateChanged { get; }
    }
}