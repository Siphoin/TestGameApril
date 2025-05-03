using UnityEngine;
using Zenject;
using TestGame.HealthSystem;
using UniRx;
namespace TestGame.Player
{
   

    public class PlayerAnimatorController : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private PlayerMovementController _movementController;
        [SerializeField] private Animator _animator;

        [Header("Animation Settings")]
        [SerializeField] private float _runThreshold = 0.1f;
        [SerializeField] private float _animationSmoothTime = 0.1f;

        [Inject] private IHealthComponent _playerHealthComponent;
        private CompositeDisposable _disposable = new();

        private int _isRunHash;
        private int _jumpHash;
        private int _groundedHash;
        private int _idleHash;
        private float _currentSpeedBlend;

        private void Awake()
        {
            _isRunHash = Animator.StringToHash("IsRun");
            _jumpHash = Animator.StringToHash("Jump");
            _groundedHash = Animator.StringToHash("Grounded");
            _idleHash = Animator.StringToHash("Idle");
        }

        private void Update()
        {
            UpdateMovementAnimations();
            UpdateJumpAndFallAnimations();
            UpdateIdleState();
        }

        private void UpdateMovementAnimations()
        {
            _animator.SetBool(_isRunHash, _movementController.IsRunning);
        }

        private void UpdateJumpAndFallAnimations()
        {
            _animator.SetBool(_groundedHash, _movementController.IsGrounded);
            _animator.SetBool(_jumpHash, _movementController.IsJumping);
            

        }

        private void UpdateIdleState()
        {
            bool isIdle = _currentSpeedBlend < 0.01f && _movementController.IsGrounded;
            _animator.SetBool(_idleHash, isIdle);
        }

        private void OnDisable()
        {
            _disposable.Clear();
        }

        private void OnEnable()
        {
            _playerHealthComponent.OnDead.Subscribe(_ =>
            {
                _animator.SetBool(_idleHash, true);
                _animator.SetBool(_jumpHash, false);
                _animator.SetBool(_isRunHash, false);
                enabled = false;
                _disposable.Clear();

            }).AddTo(_disposable);
        }
    }
}
