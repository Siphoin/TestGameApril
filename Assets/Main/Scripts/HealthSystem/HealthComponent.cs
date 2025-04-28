using System.Collections;
using UnityEngine;
using UniRx;
namespace TestGame.HealthSystem
{
    public class HealthComponent : MonoBehaviour, IHealthComponent
    {
        private Subject<Unit> _onDead = new();
        [SerializeField] private float _health = 100;
        private float _startHealth;

        public ISubject<Unit> OnDead => _onDead;

        public float Health => _health;

        private void Awake()
        {
            _startHealth = _health;
        }

        public void Damage (int amount)
        {
            _health = Mathf.Clamp(_health -  amount, 0, _startHealth);

            if (_health <= 0)
            {
                _onDead.OnNext(Unit.Default);
                enabled = false;
            }
        }
    }
}