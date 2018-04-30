using Assets.Scripts.ScriptableObjects;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.MonoBehaviors
{
    public class HighScoreManager : MonoBehaviour
    {
        [SerializeField]
        private HighScoresData _highScores;

        [SerializeField]
        private GameObject _itemPrefab;

        // Use this for initialization
        void Start()
        {
            foreach (var highScore in _highScores.HighScores)
            {
                var item = Instantiate(_itemPrefab, this.transform);
                item.transform.Find("Username").GetComponent<Text>().text = highScore.PlayerName;
                item.transform.Find("Score").GetComponent<Text>().text = highScore.Score.ToString();
            }
        }
    }
}
