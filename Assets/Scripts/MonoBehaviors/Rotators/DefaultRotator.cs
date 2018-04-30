using Assets.Scripts.Core;
using UnityEngine;

namespace Assets.Scripts.MonoBehaviors.Rotators
{
    public class DefaultRotator : MonoBehaviour, IRotator
    {
        private readonly float _rotationAngle = -90f;

        public void RotateCW()
        {
            transform.Rotate(0, 0, _rotationAngle);
        }

        public void RotateCCW()
        {
            transform.Rotate(0, 0, -_rotationAngle);
        }
    }
}
