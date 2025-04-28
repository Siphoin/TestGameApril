using System.Collections;
using TestGame.HealthSystem;
using UniRx;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace TestGame.Core.Handlers
{
    public class LevelHandler : MonoBehaviour, ILevelHandler
    {
        [Inject] private IHealthComponent _playerHealthComponent;

        private CompositeDisposable _disposable = new();
        private IFinishMarker _finishMarker;
        private Subject<GameState> _onGameStateChanged = new();

        public GameState GameState { get; private set; } = GameState.Playing;
        public ISubject<GameState> OnGameStateChanged => _onGameStateChanged;

        private void OnEnable()
        {
            _playerHealthComponent.OnDead.Subscribe(_ =>
            {
                _disposable.Clear();
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
               
            }).AddTo(_disposable);

           InitFinishMarker();
        }

        private void OnDisable()
        {
            _disposable.Clear();
        }

        private void InitFinishMarker ()
        {
            _finishMarker = FindAnyObjectByType<FinishMarker>();
            _finishMarker.OnPlayerEntered.Subscribe(_ =>
            {
                _disposable.Clear();
                GameState = GameState.Win;
                _onGameStateChanged.OnNext(GameState);

            }).AddTo(_disposable);
        }
    }
}