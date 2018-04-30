using System;
using System.Linq;
using Assets.Scripts.Core;
using UnityEngine;

namespace Assets.Scripts.MonoBehaviors
{
    [RequireComponent(typeof(IRotator))]
    [RequireComponent(typeof(ITranslator))]
    public class Tetromino : MonoBehaviour, ITetromino
    {
        [SerializeField]
        private Sprite _preview;

        private ITranslator _translator;
        private IRotator _rotator;
        private ITetrisGrid _gameGrid;
        private IInputManager _inputManager;

        private float _gravityTimer;
        private float _currentGravityTimer = 0;
        private bool _isRunning;
        private int _numOfMoves = 0;
        

        #region ITetromino Implementation

        public event Action Rotated = delegate { };
        public event Action<int> Landed = delegate { };
        public event Action MoveSucceed = delegate { };
        public event Action MoveFailed = delegate { };
        
        #endregion
        private void Start()
        {
            _translator = GetComponent<ITranslator>();
            _rotator = GetComponent<IRotator>();
            
        }

        private void Update()
        {
            _currentGravityTimer += Time.deltaTime;
            if (_currentGravityTimer > _gravityTimer)
            {
                InputManagerOnMoveDown();
            }
        }

        // TODO: can be injected using zenject
        public void Initialize(ITetrisGrid grid, IInputManager inputManager, float speed)
        {
            _gameGrid = grid;
            _inputManager = inputManager;
            _gravityTimer = speed;
            SubscriveToInput();
            gameObject.SetActive(true);
        }

        public Sprite GetPreview()
        {
            return _preview;
        }

        public void Pause()
        {
            _isRunning = false;
        }

        public void Resume()
        {
            _isRunning = true;
        }

        #region Input Handling

        private void InputManagerOnMoveDown()
        {
            if (!_isRunning)
            {
                return;
            }

            _currentGravityTimer = 0;
            _translator.TranslateDown();

            if (IsValidPosition())
            {
                MoveSucceed();
                _numOfMoves++;
            }
            else
            {
                _translator.TranslateUp();
                LandTetromino();
            }
        }

        private void InputManagerOnLand()
        {
            if (!_isRunning)
            {
                return;
            }

            do
            {
                _translator.TranslateDown();

            } while (IsValidPosition());

            _translator.TranslateUp();
            LandTetromino();
        }

        private void InputManagerOnRotate()
        {
            if (!_isRunning)
            {
                return;
            }

            _rotator.RotateCW();

            if (IsValidPosition())
            {
                Rotated();
            }
            else
            {
                MoveFailed();
                _rotator.RotateCCW();
            }
            
        }

        private void InputManagerOnMoveRight()
        {
            if (!_isRunning)
            {
                return;
            }

            _translator.TranslateRight();

            if (IsValidPosition())
            {
                MoveSucceed();
            }
            else
            {
                _translator.TranslateLeft();
                MoveFailed();
            }
        }

        private void InputManagerOnMoveLeft()
        {
            if (!_isRunning)
            {
                return;
            }

            _translator.TranslateLeft();

            if (IsValidPosition())
            {
                MoveSucceed();
            }
            else
            {
                _translator.TranslateRight();
                MoveFailed();
            }
        }

        private void SubscriveToInput()
        {
            _inputManager.MoveLeft += InputManagerOnMoveLeft;
            _inputManager.MoveRight += InputManagerOnMoveRight;
            _inputManager.Rotate += InputManagerOnRotate;
            _inputManager.MoveDown += InputManagerOnMoveDown;
            _inputManager.Land += InputManagerOnLand;
        }

        private void UnsubscriveFromInput()
        {
            _inputManager.MoveLeft -= InputManagerOnMoveLeft;
            _inputManager.MoveRight -= InputManagerOnMoveRight;
            _inputManager.Rotate -= InputManagerOnRotate;
            _inputManager.MoveDown -= InputManagerOnMoveDown;
            _inputManager.Land -= InputManagerOnLand;
        }

        #endregion

        private void LandTetromino()
        {
            UnsubscriveFromInput();
            enabled = false;
            if (_gameGrid.TryInsert(transform.Cast<Transform>()))
            {
                Landed(_numOfMoves);
            }
        }

        private bool IsValidPosition()
        {
            return _gameGrid.IsValidPosition(transform.Cast<Transform>());
        }
    }
}
