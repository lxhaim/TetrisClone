using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Tetris.Core;

namespace Tetris.Base
{
    public class RandomItemProvider<T> : IRandomProvider<T>
    {
        private readonly Random _randomProvider;
        private readonly IList<T> _items;

        public RandomItemProvider(IEnumerable<T> items)
        {
            _items = items.ToList<T>();
            _randomProvider = new Random();
        }

        public T GetRandom()
        {
            int randomSelectionIndex = _randomProvider.Next(0, _items.Count);
            return _items[randomSelectionIndex];
        }
    }
}
