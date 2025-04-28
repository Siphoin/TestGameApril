using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace TestGame.Core.UI
{
    public class WinWindow : MonoBehaviour
    {
        [SerializeField] private Button _restartButton;
        [SerializeField] private Button _quitButton;

        private void OnEnable()
        {
            _quitButton.onClick.AddListener(Quit);
            _restartButton.onClick.AddListener(Restart);
        }

        private void OnDisable()
        {
            _quitButton.onClick.RemoveListener(Quit);
            _restartButton.onClick.RemoveListener(Restart);
        }

        private void Restart () => SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        private void Quit ()
        {
            Application.Quit();
#if UNITY_EDITOR
            if (Application.isPlaying)
            {
                UnityEditor.EditorApplication.isPlaying = false;
            }
#endif
        }

        internal void Show() => gameObject.SetActive(true);
    }
}