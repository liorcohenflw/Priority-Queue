# **Priority Queue**
A priority queue implemented by heap. Cross platform operating systems, written in .Net standard.<br />
For priority queue populating none primitives types, implement IComparable is mandatory in order to use queue.<br />
<br />
<br />
## **Getting Started**
Here there will be link to nuget.
<br />
## **Code Examples**
There will be two examples one of max heap and second of min heap:
```rust
public static void Main(string [] args)
{
   IPriorityQueue<int> priorityQueue = PriorityQueueFactory<int>.CreatePriorityQueue(HeapType.MIN);
            priorityQueue.Insert(2);
            priorityQueue.Insert(1);
            priorityQueue.Insert(3);
            priorityQueue.Insert(10);
            while(!priorityQueue.IsEmpty())
            {
              Console.WriteLine(priorityQueue.Remove());
            }
}
```
It will print : <br />
1<br />
2<br />
3<br />
10<br />

There are also way to initialize priority queue with initial size:<br />
```rust
PriorityQueueFactory<int>.CreatePriorityQueue(HeapType.MIN,4);
```
If queue will be initialized as: <br />
```rust
PriorityQueueFactory<int>.CreatePriorityQueue(HeapType.MAX);
```
Than the printings above will be : <br />
10<br />
3<br />
2<br />
1<br />

## Run Time Complexity : <br />
Insert - O(log(n)) <br />
Peek - O(1)  <br />
Remove - O(log(n))  <br />
IsEmpty - O(1)  <br />
Size - O(1)  <br />
Capacity - O(1)  <br />


 

