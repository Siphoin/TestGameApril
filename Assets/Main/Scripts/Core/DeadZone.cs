using TestGame.Core.Player.Markers;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace TestGame.Core
{
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(BoxCollider))]
    public class DeadZone : MonoBehaviour
    {

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out PlayerMarker _))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }
}