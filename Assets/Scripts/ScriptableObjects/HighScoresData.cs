using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Base;
using UnityEngine;

namespace Assets.Scripts.ScriptableObjects
{
    [CreateAssetMenu]
    public class HighScoresData : ScriptableObject
    {
        [SerializeField]
        private int _maxNumOfScores;

        [SerializeField]
        private List<ScoreInfo> _highScores;

        public List<ScoreInfo> HighScores
        {
            get
            {
                return new List<ScoreInfo>(_highScores);
            }
        }

        public void AddScore(ScoreInfo score)
        {
            if (_highScores == null)
            {
                _highScores = new List<ScoreInfo>();
            }

            _highScores.Add(score);       
            _highScores.Sort((score1, score2) => score2.Score.CompareTo(score1.Score));
            var newHighScores = _highScores.Take(_maxNumOfScores).ToList();

            _highScores.Clear();
            _highScores.AddRange(newHighScores);
        }
    }
}
