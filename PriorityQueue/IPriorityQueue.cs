using System;

namespace PriorityQueue
{
    public interface IPriorityQueue<T> where T : IComparable<T>
    {
        /// <summary>
        /// Insert item according to heap type.
        /// </summary>
        /// <param name="item"></param>
        void Insert(T item);
        /// <summary>
        /// Peek the optimized item, according to heap type.
        /// </summary>
        /// <returns></returns>
        T Peek();
        /// <summary>
        /// Remove optimized item, according to heap type.
        /// </summary>
        /// <returns></returns>
        T Remove();
        /// <summary>
        /// Checking if queue is empty.
        /// </summary>
        /// <returns></returns>
        bool IsEmpty();
        /// <summary>
        /// Get number of items in queue.
        /// </summary>
        /// <returns></returns>
        int Size();
        /// <summary>
        /// Get capacity of queue. It is adjusted when removing and adding item.
        /// </summary>
        /// <returns></returns>
        int Capacity();
    }
}
