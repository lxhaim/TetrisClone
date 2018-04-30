using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.MonoBehaviors
{
    public class HomeButton : MonoBehaviour
    {
        public void OnClick()
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
}
