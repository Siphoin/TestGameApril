// PlayerMovementController.cs
using System;
using TestGame.Configs.Player;
using TestGame.HealthSystem;
using UniRx;
using UnityEngine;
using Zenject;

namespace TestGame.Player
{
    public class PlayerMovementController : MonoBehaviour, IPlayerMovementController
    {
        [SerializeField] private Transform _groundCheck;

        private CharacterController _characterController;
        private PlayerMovementSettings _settings;
        private Vector3 _velocity;
        private bool _isGrounded;
        private Vector3 _lastMoveDirection;
        private CompositeDisposable _disposable = new();
        [Inject] private IHealthComponent _playerHealthComponent;

        public bool IsGrounded => _isGrounded;
         public Vector3 Velocity => _velocity;
        public bool IsJumping => !_isGrounded;

        public bool IsRunning { get; private set; }

        [Inject]
        public void Construct(PlayerMovementSettings settings)
        {
            _settings = settings;
        }

        private void Awake()
        {
            if (!TryGetComponent(out _characterController))
            {
                throw new NullReferenceException("CharacterController component is missing!");
            }
        }

        private void Update()
        {
            HandleGroundCheck();
            HandleMovement();
            HandleJump();
            HandleGravity();
            HandleRotation();
        }

        private void HandleGroundCheck()
        {
            _isGrounded = Physics.CheckSphere(
                _groundCheck.position,
                _settings.GroundRadius,
                _settings.GroundLayer
            );


            if (_isGrounded && _velocity.y < 0)
            {
                _velocity.y = -2f;
            }
        }

        private void HandleMovement()
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            Vector3 moveDirection = new Vector3(horizontalInput, 0, 0);

            if (moveDirection.magnitude > 0.1f)
            {
                _lastMoveDirection = moveDirection;
                IsRunning = true;
                _characterController.Move(moveDirection * _settings.MoveSpeed * Time.deltaTime);
            }

            else
            {
                IsRunning = false;
            }
        }

        private void HandleJump()
        {
            if (_isGrounded && Input.GetButtonDown("Jump"))
            {
                _velocity.y = Mathf.Sqrt(_settings.JumpForce * -2f * _settings.Gravity);
            }
        }

        private void HandleGravity()
        {
            _velocity.y += _settings.Gravity * Time.deltaTime;
            _characterController.Move(_velocity * Time.deltaTime);
        }

        private void HandleRotation()
        {
            if (_lastMoveDirection.magnitude > 0.1f)
            {
                Quaternion targetRotation = Quaternion.LookRotation(_lastMoveDirection);
                transform.rotation = Quaternion.Slerp(
                    transform.rotation,
                    targetRotation,
                    _settings.RotationSpeed * Time.deltaTime
                );
            }
        }

        private void OnControllerColliderHit(ControllerColliderHit hit)
        {
            if (hit.normal.x != 0)
            {
                _velocity.x = 0;
            }
        }

        private void OnEnable()
        {
            _playerHealthComponent.OnDead.Subscribe(_ =>
            {
                enabled = false;
                _disposable.Clear();

            }).AddTo(_disposable);
        }

        private void OnDisable()
        {
            _disposable.Clear();
        }
    }
}