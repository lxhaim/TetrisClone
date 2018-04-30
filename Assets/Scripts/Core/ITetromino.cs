using System;
using UnityEngine;

namespace Assets.Scripts.Core
{
    public interface ITetromino : IPausable
    {
        event Action MoveSucceed;
        event Action MoveFailed;
        event Action Rotated;
        event Action<int> Landed;

        void Initialize(ITetrisGrid grid, IInputManager inputManager, float speed);
        Sprite GetPreview();
    }
}
