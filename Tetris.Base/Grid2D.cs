namespace Tetris.Base
{
    public class Grid2D<T>
    {
        private readonly T[,] _grid;

        public Grid2D(int height, int width)
        {
            _grid = new T[width, height];
        }

        public void Insert(T item, int x, int y)
        {
            _grid[x, y] = item;
        }

        public bool IsFree(int x, int y)
        {
            if (y >= _grid.GetLength(1))
            {
                return true;
            }

            if (x >= _grid.GetLength(0) ||
                x < 0 ||
                y < 0)
            {
                return false;
            }

            return _grid[x, y] == null;
        }

        public int ClearFullLines()
        {
            int clearLineCount = 0;
            for (int y = 0; y < _grid.GetLength(1); y++)
            {
                if (IsLineFull(y))
                {
                    
                }
            }
        }

        private bool IsLineFull(int y)
        {
            for (int x = 0; x < _grid.GetLength(0); x++)
            {
                if (_grid[x, y] == null)
                {
                    return false;
                }
            }

            return true;
        }

        private void ClearLine(int y)
        {
            for (int x = 0; x < _grid.GetLength(0); x++)
            {
                _grid[x, y] = default(T);
            }

            for (int i = y + 1; i < _grid.GetLength(1); i++)
            {
                for (int x = 0; x < _grid.GetLength(0); x++)
                {
                    _grid[x, i - 1] = _grid[x, i];
                    _grid[x, i] = default(T);
                }
            }
        }
    }
}
