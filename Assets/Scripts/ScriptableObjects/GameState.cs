using UnityEngine;

namespace Assets.Scripts.ScriptableObjects
{
    [CreateAssetMenu]
    public class GameState : ScriptableObject
    {
        public bool IsPaused;
        public int Score;
        public int LinesCleared;
        public int Level;
        public string PlayerName;

        public void OnEnable()
        {
            ResetData();
            PlayerName = "Player1";
        }

        public void ResetData()
        {
            IsPaused = false;
            Level = 0;
            LinesCleared = 0;
            Score = 0;
        }
    }
}
