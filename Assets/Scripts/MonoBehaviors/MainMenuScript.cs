using Assets.Scripts.ScriptableObjects;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Assets.Scripts.MonoBehaviors
{
    public class MainMenuScript : MonoBehaviour
    {
        [SerializeField]
        private GameState _gameState;

        [SerializeField]
        private InputField _inputField;

        [SerializeField]
        private Color _inputFieldErrorColor;

        [SerializeField]
        private float _inputFieldColorTimeout;

        private float _inputFieldColorTimer;

        public void OnStart()
        {
            if (string.IsNullOrEmpty(_inputField.text))
            {
                _inputField.image.color = _inputFieldErrorColor;
                return;
            }

            _gameState.PlayerName = _inputField.text;
            SceneManager.LoadScene("Game");
        }

        public void OnExit()
        {
            Application.Quit();
        }

        private void Update()
        {
            _inputFieldColorTimer += Time.deltaTime;
            if (_inputFieldColorTimer >= _inputFieldColorTimeout)
            {
                _inputFieldColorTimer = 0;
                _inputField.image.color = Color.white;

            }
        }
    }
}
