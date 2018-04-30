using Assets.Scripts.ScriptableObjects;
using UnityEngine;
using UnityEngine.UI;

public class PauseButton : MonoBehaviour
{
    [SerializeField]
    private GameState _gameState;
    [SerializeField]
    private Sprite _pauseSprite;
    [SerializeField]
    private Sprite _resumeSprite;

    private Image _buttonImage;


    private void Start()
    {
        _buttonImage = GetComponent<Image>();
    }

    public void OnButtonClicked()
    {
        if (_gameState.IsPaused)
        {
            _gameState.IsPaused = false;
            _buttonImage.sprite = _pauseSprite;
        }
        else
        {
            _gameState.IsPaused = true;
            _buttonImage.sprite = _resumeSprite;
        }
    }
}
