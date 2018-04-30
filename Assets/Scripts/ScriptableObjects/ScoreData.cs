using UnityEngine;

namespace Assets.Scripts.ScriptableObjects
{
    [CreateAssetMenu]
    public class ScoreData : ScriptableObject
    {
        public int[] LineScores;
        public int TetrominoScore;
    }
}
