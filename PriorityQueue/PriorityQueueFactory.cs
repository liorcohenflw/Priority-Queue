using System;

namespace PriorityQueue
{
    public class PriorityQueueFactory<T> where T : IComparable<T>
    {
        public static IPriorityQueue<T> CreatePriorityQueue(HeapType heapType)
        {
            ValidateHeapTypeValues(heapType);
            return new PriorityQueue<T>(heapType);
        }

        public static IPriorityQueue<T> CreatePriorityQueue(HeapType heapType, int initialSize)
        {
            ValidateHeapTypeValues(heapType);
            ValidateInitialSize(initialSize);
            return new PriorityQueue<T>(heapType,initialSize);
        }

        private static void ValidateInitialSize(int initialSize)
        {
            if (initialSize < 0)
            {
                throw new Exception();
            }
        }

        private static void ValidateHeapTypeValues(HeapType heapType)
        {
            if (Enum.GetValues(typeof(HeapType)).Length > 2)
            {
                throw new Exception();
            }
        }
    }
}
