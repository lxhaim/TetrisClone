using System;
using Assets.Scripts.Core;
using Assets.Scripts.ScriptableObjects;

namespace Assets.Scripts.Base
{
    public class LevelManager : ILevelManager
    {
        private readonly GameState _gameState;
        private readonly int _linesToIncLevel;
        private readonly int _maxLevel;

        public LevelManager(GameState gameState, int linesToInc, int maxLevel)
        {
            _gameState = gameState;
            _linesToIncLevel = linesToInc;
            _maxLevel = maxLevel;
        }

        public int GetCurrentLevel()
        {
            return Math.Min(_maxLevel, _gameState.LinesCleared / _linesToIncLevel);
        }
    }
}
