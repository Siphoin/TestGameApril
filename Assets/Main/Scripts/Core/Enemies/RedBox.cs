using System.Collections;
using TestGame.Configs.RedBoxConfigs;
using TestGame.Core.Player.Markers;
using TestGame.HealthSystem;
using UnityEngine;
using Zenject;

namespace TestGame.Core.Enemies
{
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(BoxCollider))]
    public class RedBox : MonoBehaviour
    {
        [Inject] private RedBoxSettings _settings;
        [Inject] private IHealthComponent _playerHealthComponent;

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out PlayerMarker _))
            {
                _playerHealthComponent.Damage(_settings.Damage);
                Debug.Log(_playerHealthComponent.Health);
            }
        }
    }
}