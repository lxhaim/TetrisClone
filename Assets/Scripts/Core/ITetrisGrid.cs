using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Core
{
    public interface ITetrisGrid
    {
        event Action GridOverflowed;
        bool TryInsert(IEnumerable<Transform> transforms);
        bool IsValidPosition(IEnumerable<Transform> transforms);
        int ClearFullLines();
    }
}
