using UnityEngine;

namespace TestGame.Configs.Player
{

    [CreateAssetMenu(fileName = "PlayerMovementSettings", menuName = "Settings/PlayerMovement")]
    public class PlayerMovementSettings : ScriptableObject
    {
        [Header("Movement")]
        [SerializeField] private float _moveSpeed = 6f;
        [SerializeField] private float _jumpForce = 8f;
        [SerializeField] private float _gravity = -20f;
        [SerializeField] private float _rotationSpeed = 10f;

        [Header("Ground Check")]
        [SerializeField] private float _groundRadius = 0.2f;
        [SerializeField] private LayerMask _groundLayer;

        public float MoveSpeed => _moveSpeed;
        public float JumpForce => _jumpForce;
        public float Gravity => _gravity;
        public float RotationSpeed => _rotationSpeed;
        public float GroundRadius => _groundRadius;
        public LayerMask GroundLayer => _groundLayer;
    }
}
