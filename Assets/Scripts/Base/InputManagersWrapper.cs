using System;
using System.Collections.Generic;
using Assets.Scripts.Core;

namespace Assets.Scripts.Base
{
    public class InputManagersWrapper : IInputManager
    {
        public event Action MoveRight = delegate { };
        public event Action MoveLeft = delegate { };
        public event Action MoveDown = delegate { };
        public event Action Land = delegate { };
        public event Action Rotate = delegate { };

        public InputManagersWrapper(IEnumerable<IInputManager> inputMangers)
        {
            foreach (var inputManager in inputMangers)
            {
                inputManager.Land += InputManagerOnLand;
                inputManager.MoveDown += InputManagerOnMoveDown;
                inputManager.MoveLeft += InputManagerOnMoveLeft;
                inputManager.MoveRight += InputManagerOnMoveRight;
                inputManager.Rotate += InputManagerOnRotate;
            }
        }

        private void InputManagerOnRotate()
        {
            Rotate();
        }

        private void InputManagerOnMoveRight()
        {
            MoveRight();
        }

        private void InputManagerOnMoveLeft()
        {
            MoveLeft();
        }

        private void InputManagerOnMoveDown()
        {
            MoveDown();
        }

        private void InputManagerOnLand()
        {
            Land();
        }

        
    }
}
