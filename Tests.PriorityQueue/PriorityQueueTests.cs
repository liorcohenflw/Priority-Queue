using System.Collections.Generic;
using NUnit.Framework;
using PriorityQueue;

namespace Tests.PriorityQueue
{
    public class PriorityQueueTests
    {
        private const int SizeOfQueue = 4;
        private const int CapacityDouble = 8;
        
        [Test]
        public void Insert_Check_Size()
        {
            IPriorityQueue<int> priorityQueue = PriorityQueueFactory<int>.CreatePriorityQueue(HeapType.MIN);
            priorityQueue.Insert(2);
            priorityQueue.Insert(1);
            priorityQueue.Insert(3);
            priorityQueue.Insert(10);
            Assert.True(priorityQueue.Size() == SizeOfQueue);
        }

        [Test]
        public void InsertMoreThanInitialSize_CapacityDoubled()
        {
            IPriorityQueue<int> priorityQueue = PriorityQueueFactory<int>.CreatePriorityQueue(HeapType.MIN,4);
            priorityQueue.Insert(1);
            priorityQueue.Insert(2);
            priorityQueue.Insert(3);
            priorityQueue.Insert(4);
            priorityQueue.Insert(5);
            Assert.True(priorityQueue.Capacity() == CapacityDouble);
        }

        [Test]
        public void InsertInRandomOrder_RemoveInOrder()
        {
            IPriorityQueue<int> priorityQueue = PriorityQueueFactory<int>.CreatePriorityQueue(HeapType.MIN, 4);
            priorityQueue.Insert(3);
            priorityQueue.Insert(2);
            priorityQueue.Insert(1);
            priorityQueue.Insert(5);
            priorityQueue.Insert(4);
            priorityQueue.Insert(10);
            priorityQueue.Insert(8);
            priorityQueue.Insert(7);
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            queue.Enqueue(4);
            queue.Enqueue(5);
            queue.Enqueue(7);
            queue.Enqueue(8);
            queue.Enqueue(10);
            while (!priorityQueue.IsEmpty())
            {
                var item = priorityQueue.Remove();
                var itemExpected = queue.Dequeue();
                Assert.AreEqual(item,itemExpected);
            }
        }

        [Test]
        public void InsertThanRemove_CheckIsEmpty()
        {
            IPriorityQueue<int> priorityQueue = PriorityQueueFactory<int>.CreatePriorityQueue(HeapType.MIN, 4);
            priorityQueue.Insert(3);
            priorityQueue.Insert(2);
            priorityQueue.Insert(1);
            priorityQueue.Insert(5);
            priorityQueue.Remove();
            priorityQueue.Remove();
            priorityQueue.Remove();
            priorityQueue.Remove();
            Assert.True(priorityQueue.IsEmpty());
        }
    }
}