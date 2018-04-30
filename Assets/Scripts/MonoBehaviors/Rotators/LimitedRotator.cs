using System;
using Assets.Scripts.Core;
using UnityEngine;

namespace Assets.Scripts.MonoBehaviors.Rotators
{
    public class LimitedRotator : MonoBehaviour, IRotator
    {
        private readonly Vector3 _baseRotation = new Vector3(0f, 0f, 0f);
        private readonly Vector3 _rotation = new Vector3(0f, 0f, 270f);

        public void RotateCW()
        {
            Rotate();
        }

        public void RotateCCW()
        {
            Rotate();
        }

        private void Rotate()
        {
            Vector3 currentRotation = transform.rotation.eulerAngles;
            if (currentRotation == _baseRotation)
            {
                transform.rotation = Quaternion.Euler(_rotation);
            }
            else
            {
                transform.rotation = Quaternion.Euler(_baseRotation);
            }
        }
    }
}
