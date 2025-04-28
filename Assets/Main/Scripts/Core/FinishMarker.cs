using System.Collections;
using TestGame.Core.Player.Markers;
using TestGame.HealthSystem;
using UniRx;
using UnityEngine;
using Zenject;

namespace TestGame.Core
{
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(BoxCollider))]
    public class FinishMarker : MonoBehaviour, IFinishMarker
    {
        private Subject<Unit> _onPlayerEntered = new();

        public ISubject<Unit> OnPlayerEntered => _onPlayerEntered;

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out PlayerMarker _))
            {
                  _onPlayerEntered.OnNext(Unit.Default);
                enabled = false;
            }
        }
    }
}