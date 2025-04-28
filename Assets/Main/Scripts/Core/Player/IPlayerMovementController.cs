using UnityEngine;

namespace TestGame.Player
{
    public interface IPlayerMovementController
    {
        public bool IsGrounded { get; }
        public bool IsJumping { get; }
        Vector3 Velocity { get; }
        bool IsRunning { get; }
    }
}