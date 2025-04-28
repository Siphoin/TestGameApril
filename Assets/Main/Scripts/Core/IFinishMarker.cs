using UniRx;

namespace TestGame.Core
{
    public interface IFinishMarker
    {
        ISubject<Unit> OnPlayerEntered { get; }
    }
}