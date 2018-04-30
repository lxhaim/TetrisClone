using Assets.Scripts.ScriptableObjects;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.MonoBehaviors
{
    public class UIUpdater : MonoBehaviour
    {
        [SerializeField]
        private GameState _gameState;
        [SerializeField]
        private Text _scoreValue;
        [SerializeField]
        private Text _levelValue;
        [SerializeField]
        private Text _linesValue;

        private void Update()
        {
            _scoreValue.text = _gameState.Score.ToString();
            _levelValue.text = _gameState.Level.ToString();
            _linesValue.text = _gameState.LinesCleared.ToString();
        }
    }
}
