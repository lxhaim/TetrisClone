using System;
using System.Collections.Generic;
using Assets.Scripts.Base;
using Assets.Scripts.Core;
using Assets.Scripts.ScriptableObjects;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.MonoBehaviors
{
    [RequireComponent(typeof(RandomPrefabsSpawner))]
    [RequireComponent(typeof(SoundManager))]
    public class Game : MonoBehaviour
    {
        [SerializeField]
        private Vector3 _previewPosition;

        [SerializeField]
        private int _gridHeight;
        [SerializeField]
        private int _gridWidth;
        [SerializeField]
        private int _maxLevel;

        [SerializeField]
        private GameState _gameState;
        [SerializeField]
        private ScoreData _scoreData;
        [SerializeField]
        private LevelSpeedData _speedData;
        [SerializeField]
        private HighScoresData _highScores;
        [SerializeField]

        private ITetrisGrid _grid;
        private ISpawner<GameObject> _spawner;
        private SoundManager _soundManager;
        private IInputManager _inputManager;
        private IScoreCalculator _scoreCalculator;
        private ILevelManager _levelManager;
        private ITetromino _currentTetromino;
        private ITetromino _nextTetromino;
        private GameObject _preview;

        private void Update()
        {
            if (_gameState.IsPaused)
            {
                _currentTetromino.Pause();
                _soundManager.Pause();
            }
            else
            {
                _currentTetromino.Resume();
                _soundManager.Resume();
            }
        }

        private void Start()
        {
            _gameState.ResetData();
            _grid = new TetrisGrid(_gridHeight, _gridWidth);
            _grid.GridOverflowed += GridOnGridOverflowed;

            _soundManager = GetComponent<SoundManager>();
            _spawner = GetComponent<RandomPrefabsSpawner>();
            _inputManager = new InputManagersWrapper(new List<IInputManager>()
            {
                GetComponent<InputManager>(),
                GetComponent<TouchInputManager>()
            });

            _scoreCalculator = new ScoreCalculator(_gameState, _scoreData);
            _levelManager = new LevelManager(_gameState, 10, _maxLevel);
            _preview = new GameObject("Preview", new Type[] {typeof(SpriteRenderer) });
            _preview.transform.position = _previewPosition;

            _currentTetromino = CreateTetromino();
            InitializeCurrentTetromino();

            _nextTetromino = CreateTetromino();
            SetUpPreview();
        }

        private void SetUpPreview()
        {
            var spriteRenderer = _preview.GetComponent<SpriteRenderer>();
            spriteRenderer.sprite = _nextTetromino.GetPreview();
        }

        private void GridOnGridOverflowed()
        {
            _highScores.AddScore(new ScoreInfo(_gameState.PlayerName, _gameState.Score));
            SceneManager.LoadScene("MainMenu");
        }

        private void CurrentTetrominoOnLanded(int numOfMoves)
        {
            int linesCleard = _grid.ClearFullLines();
            if (linesCleard > 0)
            {
                _gameState.LinesCleared += linesCleard;
                _gameState.Level = _levelManager.GetCurrentLevel();
                _soundManager.PlayLineClearedSound();
            }
            
            _gameState.Score += _scoreCalculator.GetScoreForClearedLines(linesCleard) +
                _scoreCalculator.GetScoreForTetromino(numOfMoves);

            UnbindCurrentTetromino();
            _currentTetromino = _nextTetromino;
            InitializeCurrentTetromino();
            
            _nextTetromino = CreateTetromino();
            SetUpPreview();
        }

        private ITetromino CreateTetromino()
        {
            return _spawner.Spawn().GetComponent<ITetromino>();
        }

        private void InitializeCurrentTetromino()
        {
            _currentTetromino.Initialize(_grid, _inputManager, _speedData.SpeedPerLevel[Mathf.Min(_gameState.Level, _maxLevel)]);
            _currentTetromino.BindTetrominoToSound(_soundManager);
            _currentTetromino.Landed += CurrentTetrominoOnLanded;
        }

        private void UnbindCurrentTetromino()
        {
            _currentTetromino.UnbindTetrominoFromSound(_soundManager);
            _currentTetromino.Landed -= CurrentTetrominoOnLanded;
        }
    }
}
