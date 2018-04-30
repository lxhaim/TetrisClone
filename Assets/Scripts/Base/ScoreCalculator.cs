using Assets.Scripts.Core;
using Assets.Scripts.ScriptableObjects;
using UnityEngine;

namespace Assets.Scripts.Base
{
    public class ScoreCalculator : IScoreCalculator
    {
        private readonly GameState _gameState;
        private readonly ScoreData _scoreData;

        public ScoreCalculator(GameState gameState, ScoreData scoreData)
        {
            _gameState = gameState;
            _scoreData = scoreData;
        }

        public int GetScoreForClearedLines(int numOfLines)
        {
            if (numOfLines == 0)
            {
                return 0;
            }

            return _scoreData.LineScores[numOfLines - 1] * (_gameState.Level + 1);
        }

        public int GetScoreForTetromino(int numOfMoves)
        {
            return Mathf.Max(_scoreData.TetrominoScore - numOfMoves, 0);
        }
    }
}
