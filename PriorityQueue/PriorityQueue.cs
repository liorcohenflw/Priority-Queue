using System;

namespace PriorityQueue
{
    public enum HeapType
    {
        MAX,
        MIN
    };
    internal class PriorityQueue<T> : IPriorityQueue<T> where T : IComparable<T>
    {
        private readonly HeapType _heapType;
        private T[] _heap;
        private int _size;
        private int _currentIndex = 1;
        private const int InitialSize = 8;
        public PriorityQueue(HeapType heapType)
        {
            _heapType = heapType;
            _heap = new T[InitialSize+1];
        }

        public PriorityQueue(HeapType heapType, int initialSize)
        {
            _heapType = heapType;
            _heap = new T[initialSize + 1];
        }
       
        public void Insert(T item)
        {
           
          
            if(_size >= _heap.Length - 1)
            {
                UpScaleArray();
            }
            InsertItem(item);
        }

        private void DownScaleArray()
        {
            var newArray = new T[((_heap.Length - 1)/2) + 1];
            for (int i = 1; i < newArray.Length; i++)
            {
                newArray[i] = _heap[i];
            }
            _heap = newArray;
        }

        private void InsertItem(T item)
        {
            _size++;
            HeapMoveItemUpTheTree(item);
            _currentIndex++;
        }

        private void HeapMoveItemUpTheTree(T item)
        {
            _heap[_currentIndex] = item;
            var indexTemp = _currentIndex;
            while (indexTemp > 1 && IsParentNeedToBeExchanged(indexTemp))
            {
                T temp = _heap[Parent(indexTemp)];
                _heap[Parent(indexTemp)] = _heap[indexTemp];
                _heap[indexTemp] = temp;
                indexTemp = Parent(indexTemp);
            }
        }

        private bool IsParentNeedToBeExchanged(int itemIndex)
        {
            if (_heapType == HeapType.MAX)
            {
                return _heap[Parent(itemIndex)].CompareTo(_heap[itemIndex]) < 0;
            }
            return  _heap[Parent(itemIndex)].CompareTo(_heap[itemIndex]) > 0;
        }

        private static int Parent(int i)
        {
            return i / 2;
        }

        private void UpScaleArray()
        {
            var newArray = new T[((_heap.Length - 1) *2) + 1];
            for (var i = 1; i <= _size; i++)
            {
                newArray[i] = _heap[i];
            }
            _heap = newArray;
        }

        public T Peek()
        {
            return _heap[1];
        }

        public T Remove()
        {
            if (_currentIndex - 1 <= 0)
            {
                throw new Exception();
            }
            T answer = _heap[1];
            _heap[1] = _heap[_currentIndex - 1];
            _size--;
            Heapify(1);
            _currentIndex--;
            if (_size > 0 && _size < Capacity() / 2)
            {
                DownScaleArray();
            }
            return answer;
        }

        private void Heapify(int itemIndex)
        {
            bool canProceed = true;
            int optimizedIndex = itemIndex;
            while (canProceed)
            {
                var left = Left(itemIndex);
                var right = Right(itemIndex);
        
                if(left <= _size)
                {
                    optimizedIndex = ChooseOptimizedIndex(left, itemIndex);
                }
              

                if (right <= _size)
                {
                    optimizedIndex = ChooseOptimizedIndex(right, optimizedIndex);
                }

                if (optimizedIndex != itemIndex)
                {
                    T temp = _heap[optimizedIndex];
                    _heap[optimizedIndex] = _heap[itemIndex];
                    _heap[itemIndex] = temp;
                }
                else
                {
                    canProceed = false;
                }
                itemIndex = optimizedIndex;
            }
          
        }

        private int ChooseOptimizedIndex(int itemIndex1, int itemIndex2)
        {
            if (_heapType == HeapType.MAX)
            {
                return _heap[itemIndex1].CompareTo(_heap[itemIndex2]) > 0 ? itemIndex1 : itemIndex2;
            }
            return _heap[itemIndex1].CompareTo(_heap[itemIndex2]) > 0 ? itemIndex2 : itemIndex1;
        }

        public static int Right(int i)
        {
            return 2 * i;
        }

        public static int Left(int i)
        {
            return 2 * i + 1;
        }

        public bool IsEmpty() => _size == 0;

        public int Size()
        {
            return _size;
        }

        public int Capacity()
        {
            return _heap.Length - 1;
        }
    }
}
