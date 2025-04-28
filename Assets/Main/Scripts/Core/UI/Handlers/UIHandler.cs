using TestGame.Core.Handlers;
using UniRx;
using UnityEngine;
using Zenject;

namespace TestGame.Core.UI.Handlers
{
    public class UIHandler : MonoBehaviour
    {
        [SerializeField] private WinWindow _winWindow;
        [Inject] private ILevelHandler _levelHandler;

        private CompositeDisposable _compositeDisposable = new();

        private void OnEnable()
        {
            _levelHandler.OnGameStateChanged.Subscribe(state =>
            {
                _compositeDisposable.Clear();
                _winWindow.Show();

            }).AddTo(_compositeDisposable);
        }

        private void OnDisable()
        {
            _compositeDisposable?.Clear();
        }
    }
}