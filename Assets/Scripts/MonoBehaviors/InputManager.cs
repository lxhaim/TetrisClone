using System;
using Assets.Scripts.Core;
using UnityEngine;

namespace Assets.Scripts.MonoBehaviors
{
    public class InputManager : MonoBehaviour, IInputManager
    {
        public event Action MoveRight = delegate {};
        public event Action MoveLeft = delegate {};
        public event Action MoveDown = delegate {};
        public event Action Land = delegate {};
        public event Action Rotate = delegate {};

        // Update is called once per frame
        void Update () {

            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                MoveRight();
            }

            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                MoveLeft();
            }

            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                Rotate();
            }

            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                MoveDown();
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                Land();
            }
        }
    }
}
