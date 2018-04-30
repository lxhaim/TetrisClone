using System;
using System.Collections.Generic;
using Assets.Scripts.Core;
using UnityEngine;

namespace Assets.Scripts.Base
{
    public class TetrisGrid : ITetrisGrid
    {
        private readonly Transform[,] _grid;

        private int Height
        {
            get { return _grid.GetLength(0); }
        }

        private int Width
        {
            get { return _grid.GetLength(1); }
        }

        public event Action GridOverflowed = delegate { };

        public TetrisGrid(int height, int width)
        {
            _grid = new Transform[height, width];
        }

        #region ITetrisGrid Implementation

        public int ClearFullLines()
        {
            int clearedLinesCount = 0;
            for (int y = 0; y < Height; y++)
            {
                if (IsLineFull(y))
                {
                    ClearLine(y);
                    clearedLinesCount++;
                    y--;
                }
            }

            return clearedLinesCount;
        }

        public bool TryInsert(IEnumerable<Transform> transforms)
        {

            foreach (var transform in transforms)
            {
                int x = Mathf.RoundToInt(transform.position.x);
                int y = Mathf.RoundToInt(transform.position.y);

                _grid[y, x] = transform;
            }

            if (IsOverflowed())
            {
                GridOverflowed();
                return false;
            }

            return true;
        }

        public bool IsValidPosition(IEnumerable<Transform> transforms)
        {
            foreach (var transform in transforms)
            {
                int x = Mathf.RoundToInt(transform.position.x);
                int y = Mathf.RoundToInt(transform.position.y);

                if (!IsInsideGrid(x, y) || _grid[y,x] != null)
                {
                    return false;
                }
            }

            return true;
        }

        #endregion

        #region Private Methods

        private bool IsOverflowed()
        {
            for (int i = 0; i < Width; i++)
            {
                if (_grid[Height - 2, i] != null)
                {
                    return true;
                }
            }

            return false;
        }

        private bool IsInsideGrid(int x, int y)
        {
            return x >= 0 && x < Width && y >= 0 && y < Height;
        }

        private bool IsLineFull(int y)
        {
            for (int x = 0; x < Width; x++)
            {
                if (_grid[y,x] == null)
                {
                    return false;
                }
            }

            return true;
        }

        private void ClearLine(int lineY)
        {
            for (int x = 0; x < Width; x++)
            {
                GameObject.Destroy(_grid[lineY,x].gameObject);
                _grid[lineY,x] = null;
            }

            for (int y = lineY + 1; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    var minoToMove = _grid[y,x];
                    if (minoToMove != null)
                    {
                        minoToMove.position -= new Vector3(0, 1, 0);
                        _grid[y-1,x] = minoToMove;
                        _grid[y,x] = null;
                    }

                }
            }
        }

        #endregion
    }
}
