using System;

namespace Assets.Scripts.Base
{
    [Serializable]
    public class ScoreInfo
    {
        public string PlayerName { get; private set; }
        public int Score { get; private set; }

        public ScoreInfo(string name, int score)
        {
            PlayerName = name;
            Score = score;
        }
    }
}
