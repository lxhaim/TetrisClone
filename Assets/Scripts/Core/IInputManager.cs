using System;

namespace Assets.Scripts.Core
{
    public interface IInputManager
    {
        event Action MoveRight;
        event Action MoveLeft;
        event Action MoveDown;
        event Action Land;
        event Action Rotate;
    }
}
