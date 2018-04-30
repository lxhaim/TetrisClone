using Assets.Scripts.Core;
using UnityEngine;

namespace Assets.Scripts.MonoBehaviors
{
    public class DefaultTranslator : MonoBehaviour, ITranslator
    {
        public void TranslateRight()
        {
            transform.position += new Vector3(1f, 0f, 0f);
        }

        public void TranslateLeft()
        {
            transform.position += new Vector3(-1f, 0f, 0f);
        }

        public void TranslateDown()
        {
            transform.position += new Vector3(0f, -1f, 0f);
        }

        public void TranslateUp()
        {
            transform.position -= new Vector3(0f, -1f, 0f);
        }
    }
}
