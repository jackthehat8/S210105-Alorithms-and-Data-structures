using System;
using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//TO DO
//A minimum heap
//A maximum heap

namespace S210105_Alorithms_and_Data_structures
{
    class Program
    {
        static int[] bubbleSort(int[] array)
        {
            bool swapped = true;
            int temp;

            while (swapped)
            {
                swapped = false;
                for (int i = 0; i < array.Length - 1; i++) //10 
                {
                    if (array[i] > array[i + 1])
                    {
                        temp = array[i];
                        array[i] = array[i + 1];
                        array[i + 1] = temp;
                        swapped = true;
                    }
                    else if (swapped != true)
                        swapped = false;
                }
            }

            return array;
        }

        static int[] insertionSort(int[] input)
        {

            for (int i = 1; i < input.Length; i++)
            {
                int currentValue = input[i];
                int shiftPointer = i - 1;
                while (shiftPointer >= 0 && input[shiftPointer] > currentValue)
                {
                    input[shiftPointer + 1] = input[shiftPointer];
                    shiftPointer--;
                }
                input[shiftPointer + 1] = currentValue;
            }

            return input;
        }

        static int[] quickSort(int[] input, int first, int last)
        {
            if (first < last)
            {
                int pivotValue = input[first];
                int leftPointer = first;
                int rightPointer = last;

                while (leftPointer < rightPointer)
                {
                    while (input[leftPointer] <= pivotValue && leftPointer <= rightPointer && leftPointer < last)
                    {
                        leftPointer++;
                    }
                    while (input[rightPointer] >= pivotValue && rightPointer >= leftPointer && rightPointer > first)
                    {
                        rightPointer--;
                    }
                    if (leftPointer < rightPointer)
                    {
                        int temp = input[leftPointer];
                        input[leftPointer] = input[rightPointer];
                        input[rightPointer] = temp;
                    }
                }

                int pivot = rightPointer;
                int temp1 = input[first];
                input[first] = input[pivot];
                input[pivot] = temp1;

                input = quickSort(input, first, pivot - 1);
                input = quickSort(input, pivot + 1, last);
            }
            return input;
        }

        static bool binarySeach(int[] list, int value, int start, int end)
        {
            bool output = false;
            if (start == end)
            {
                if (list[start] == value)
                    output = true;
                else
                    output = false;
            }
            else
            {
                int middle = start + ((end - start) / 2);
                if (list[middle] == value)
                {
                    output = true;
                }
                else if (value < list[middle])
                {
                    output = binarySeach(list, value, start, middle - 1);
                }
                else if (value > list[middle])
                {
                    output = binarySeach(list, value, middle + 1, end);
                }
            }
            return output;
        }


        //reference https://stackoverflow.com/questions/48556743/how-to-get-number-of-hundreds-and-tens-from-a-total-value-in-c
        static int GetPlaces(int value, int place)
        {
            return ((value % (place * 10)) - (value % place)) / place;
        }
        //end reference
        static int[] radixSort(int[] input)
        {
            List<int>[] Buckets = new List<int>[10];
            int Coloum = 1;
            do
            {
                for (int i = 0; i < Buckets.Length; i++)
                {
                    Buckets[i] = new List<int>();
                }


                foreach (int element in input)
                {
                    int bucketIndex = GetPlaces(element, Coloum);
                    Buckets[bucketIndex].Add(element);
                }

                input = new int[input.Length];
                int index = 0;
                foreach (List<int> bucket in Buckets)
                {
                    foreach (int element in bucket)
                    {
                        input[index] = element;
                        index++;
                    }
                }

                Coloum *= 10;
            } while (Buckets[0].Count != input.Length);
            return input;
        }

        struct Edge 
        {
            public int NodeToConnectTo;
            public int Weight;

            public Edge(int _NodeToConnectTo, int _Weight)
            {
                NodeToConnectTo = _NodeToConnectTo;
                Weight = _Weight;
            }
        }

        List<List<Edge>>weightedGraph;
        public void Graph()
        {
            int NumberOfNodes = 5;
            weightedGraph = new List<List<Edge>>(NumberOfNodes);
            weightedGraph[0].Add(new Edge(4, 30));
            weightedGraph[0].Add(new Edge(1, 20));
            weightedGraph[0].Add(new Edge(2, 10));

            weightedGraph[1].Add(new Edge(0, 20));
            weightedGraph[1].Add(new Edge(3, 15));
            weightedGraph[1].Add(new Edge(4, 20));

            weightedGraph[2].Add(new Edge(0, 10));

            weightedGraph[3].Add(new Edge(1, 15));
            weightedGraph[3].Add(new Edge(4, 100));

            weightedGraph[4].Add(new Edge(3, 100));
            weightedGraph[4].Add(new Edge(1, 20));
            weightedGraph[4].Add(new Edge(0, 30));
        }

        static void testGenericClass()
        {
            Console.WriteLine("Generic testing\n");
            MyGenericClass<int> intGenericClass = new MyGenericClass<int>(10);
            intGenericClass.getType(200);


            MyGenericClass<string> strGenericClass = new MyGenericClass<string>("hello World");
            strGenericClass.getType("hello");

            MyGenericClass<double> doubleGenericClass = new MyGenericClass<double>(10.2);
            doubleGenericClass.getType(200.63);

            MyGenericClass<char> charGenericClass = new MyGenericClass<char>('i');
            charGenericClass.getType('k');

            MyGenericClass<float> floatGenericClass = new MyGenericClass<float>(5.3f);
            floatGenericClass.getType(156.9f);

            Console.WriteLine(intGenericClass.addOne());
            Console.WriteLine(strGenericClass.addOne());
            Console.WriteLine(doubleGenericClass.addOne());
            Console.WriteLine(charGenericClass.addOne());
            Console.WriteLine(floatGenericClass.addOne());
        }

        static void testGenericArray()
        {
            Console.WriteLine("Array testing\n");
            int[] inputArray = new int[6];
            inputArray[0] = 1;
            inputArray[1] = 2;
            inputArray[2] = 3;
            inputArray[3] = 4;
            inputArray[4] = 5;
            inputArray[5] = 6;

            GenericArray<int> numbers = new GenericArray<int>(inputArray);
            Console.WriteLine(numbers.getData(0));
            Console.WriteLine(numbers.getData(2));
            Console.WriteLine(numbers.getData(5));
            Console.WriteLine(numbers.getData(8));
        }

        static void testGenericPair()
        {
            Console.WriteLine("Pair testing\n");
            GenericPair<int, string> newPair = new GenericPair<int, string>(3, "hello");
            int one = newPair.getOne();
            string two = newPair.getTwo();
            Console.WriteLine(one);
            Console.WriteLine(two);
        }

        static void testLinkedList()
        {
            //linked list
            Console.WriteLine("Linked list testing\n");
            MyLinkedList<string> testList = new MyLinkedList<string>();
            testList.add("hello");
            testList.add("world");
            testList.add("wow");
            testList.add("test");
            testList.printList();
            Console.WriteLine("\nadd you to 3rd place\n");
            testList.insert("you", 2);
            testList.printList();
            Console.WriteLine("\nremove 4th item\n");
            testList.remove(3);
            testList.printList();
            Console.WriteLine("\nremoveLast\n");
            testList.removeLast();
            testList.printList();
            Console.WriteLine("\nmove 1st to 2nd\n");
            testList.moveDown(0);
            testList.printList();
            Console.WriteLine("\nadd 3 new values to end of list\n");
            testList.add("1");
            testList.add("2");
            testList.add("3");
            testList.printList();
            Console.WriteLine("\nmove 5th pos to 4th\n");
            testList.moveUp(4);
            testList.printList();
        }

        static void testDoubleLinkedList()
        {
            //double linked list
            Console.WriteLine("Double Linked list testing\n");
            MyDoubleLinkedList<string> testDoubleList = new MyDoubleLinkedList<string>();
            testDoubleList.add("hello");
            testDoubleList.add("world");
            testDoubleList.add("wow");
            testDoubleList.add("test");
            testDoubleList.printListDebug();
            Console.WriteLine("\nadd you to 3rd place\n");
            testDoubleList.insert("you", 2);
            testDoubleList.printListDebug();
            Console.WriteLine("\nremove 4th item\n");
            testDoubleList.remove(3);
            testDoubleList.printListDebug();
            Console.WriteLine("\nremoveLast\n");
            testDoubleList.removeLast();
            testDoubleList.printListDebug();
            Console.WriteLine("\nmove 1st to 2nd\n");
            testDoubleList.moveDown(0);
            testDoubleList.printListDebug();
            Console.WriteLine("\nadd 3 new values to end of list\n");
            testDoubleList.add("1");
            testDoubleList.add("2");
            testDoubleList.add("3");
            testDoubleList.printListDebug();
            Console.WriteLine("\nmove 5th pos to 4th\n");
            testDoubleList.moveUp(4);
            testDoubleList.printListDebug();
        }

        static void testStack()
        {
            Console.WriteLine("Stack testing\n");
            MyStack<string> bookStack = new MyStack<string>();
            bookStack.Enqueue("hello");
            bookStack.Enqueue("world");
            bookStack.Enqueue("wow");
            bookStack.Enqueue("test");

            bookStack.PrintStack();

            Console.WriteLine("\nDequeue");
            Console.WriteLine(bookStack.Dequeue() + " was removed from the stack\n");
            bookStack.PrintStack();

        }

        static void testQueue()
        {
            Console.WriteLine("Queue testing\n");
            MyQueue<string> shopLine = new MyQueue<string>();
            shopLine.Enqueue("Person 1");
            shopLine.Enqueue("Person 2");
            shopLine.Enqueue("Person 3");
            shopLine.Enqueue("Person 4");

            shopLine.PrintStack();

            Console.WriteLine("\nDequeue");
            Console.WriteLine(shopLine.Dequeue() + " was removed from the queue\n");
            shopLine.PrintStack();

        }

        static void testBubbleSort()
        {
            Console.WriteLine("Bubble Sort");
            int[] testBubbleArray = new int[10] { 5, 3, 7, 8, 98, 9, 0, 4, 65, 2 };
            for (int i = 0; i < testBubbleArray.Length; i++)
            {
                Console.Write(testBubbleArray[i] + ", ");
            }
            Console.WriteLine();
            testBubbleArray = bubbleSort(testBubbleArray);
            for (int i = 0; i < testBubbleArray.Length; i++)
            {
                Console.Write(testBubbleArray[i] + ", ");
            }
            Console.WriteLine();
        }

        static void testInsertionSort()
        {
            Console.WriteLine("Insertion Sort");
            int[] testInsertArray = new int[10] { 5, 3, 7, 8, 98, 9, 0, 4, 65, 2 };
            for (int i = 0; i < testInsertArray.Length; i++)
            {
                Console.Write(testInsertArray[i] + ", ");
            }
            Console.WriteLine();
            testInsertArray = insertionSort(testInsertArray);
            for (int i = 0; i < testInsertArray.Length; i++)
            {
                Console.Write(testInsertArray[i] + ", ");
            }
            Console.WriteLine();
        }

        static void testQuickSort()
        {
            Console.WriteLine("Quick Sort");
            int[] testQuickArray = new int[10] { 5, 3, 7, 8, 98, 9, 0, 4, 65, 2 };
            for (int i = 0; i < testQuickArray.Length; i++)
            {
                Console.Write(testQuickArray[i] + ", ");
            }
            Console.WriteLine();
            testQuickArray = quickSort(testQuickArray, 0, testQuickArray.Length - 1);
            for (int i = 0; i < testQuickArray.Length; i++)
            {
                Console.Write(testQuickArray[i] + ", ");
            }
            Console.WriteLine();
        }

        static void testRadixSort()
        {
            Console.WriteLine("Radix Sort");
            int[] testRadixArray = new int[10] { 5, 345, 7, 854, 98, 9, 0, 4, 65, 2 };
            for (int i = 0; i < testRadixArray.Length; i++)
            {
                Console.Write(testRadixArray[i] + ", ");
            }
            Console.WriteLine();
            testRadixArray = radixSort(testRadixArray);
            for (int i = 0; i < testRadixArray.Length; i++)
            {
                Console.Write(testRadixArray[i] + ", ");
            }
            Console.WriteLine();
        }

        static void testBinarySearch()
        {
            Console.WriteLine("biary search");
            int[] testBinarySearchArray = new int[10] { 0, 2, 4, 5, 7, 9, 65, 98, 345, 854 };
            for (int i = 0; i < testBinarySearchArray.Length; i++)
            {
                Console.Write(testBinarySearchArray[i] + ", ");
            }
            Console.WriteLine();

            int testValue = 98;
            Console.WriteLine("trying to see if " + testValue + " is in the list\n");
            bool output = binarySeach(testBinarySearchArray, testValue, 0, (testBinarySearchArray.Length - 1));
            if (output)
                Console.WriteLine(testValue + " is in the list");
            else
                Console.WriteLine(testValue + " is not in the list");
            Console.WriteLine();

            int testValue2 = 73;
            Console.WriteLine("trying to see if " + testValue2 + " is in the list\n");
            bool output2 = binarySeach(testBinarySearchArray, testValue2, 0, (testBinarySearchArray.Length - 1));
            if (output2)
                Console.WriteLine(testValue2 + " is in the list");
            else
                Console.WriteLine(testValue2 + " is not in the list");
        }

        static void testBinarySearchTree()
        {
            Console.WriteLine("Binary Search Tree");
            int[] testBinarySearchTreeArray = new int[10] { 5, 345, 7, 854, 98, 9, 0, 4, 65, 2 };
            for (int i = 0; i < testBinarySearchTreeArray.Length; i++)
            {
                Console.Write(testBinarySearchTreeArray[i] + ", ");
            }
            Console.WriteLine();
            BinarySearchTree binarySearch = new BinarySearchTree();
            binarySearch.add(testBinarySearchTreeArray);
            int testValue = 65;
            Console.WriteLine("trying to see if " + testValue + " is in the list\n");
            bool output = binarySearch.find(testValue);
            if (output)
                Console.WriteLine(testValue + " is in the list");
            else
                Console.WriteLine(testValue + " is not in the list");
            Console.WriteLine();

            int testValue2 = 73;
            Console.WriteLine("trying to see if " + testValue2 + " is in the list\n");
            bool output2 = binarySearch.find(testValue2);
            if (output2)
                Console.WriteLine(testValue2 + " is in the list");
            else
                Console.WriteLine(testValue2 + " is not in the list");
        }

        static void Main(string[] args)
        {
            testGenericClass();
            Console.WriteLine();

            testGenericArray();
            Console.WriteLine();

            testGenericPair();
            Console.WriteLine();

            testLinkedList();
            Console.WriteLine();

            testDoubleLinkedList();
            Console.WriteLine();

            testStack();
            Console.WriteLine();

            testQueue();
            Console.WriteLine();

            testBubbleSort();
            Console.WriteLine();

            testInsertionSort();
            Console.WriteLine();

            testQuickSort();
            Console.WriteLine();

            testRadixSort();
            Console.WriteLine();

            testBinarySearch();
            Console.WriteLine();

            BinaryHeapMin binaryHeap = new BinaryHeapMin();
            binaryHeap.insert(23);
            binaryHeap.insert(3);
            binaryHeap.insert(2);
            binaryHeap.insert(56);
            binaryHeap.insert(97);

            testBinarySearchTree();
            Console.WriteLine();

            Console.ReadLine();
        }
    }
}
class MyGenericClass<T>
{
    private T genericMemberVariable;

    public MyGenericClass(T value)
    {
        genericMemberVariable = value;
    }

    public T getType(T genericParameter)
    {
        Console.WriteLine("Parameter type: {0}, value {1}", typeof(T).ToString(), genericParameter);
        Console.WriteLine("Return type: {0}, value: {1}", typeof(T).ToString(), genericMemberVariable);
        Console.WriteLine();
        return genericMemberVariable;
    }

    public T addOne()
    {
        //inspired by: https://stackoverflow.com/questions/8122611/c-sharp-adding-two-generic-values (dynamics)
        if (typeof(T) == typeof(char))
        {
            //done separately so it needs to be converted to unicode to add the one
            dynamic temp1 = Convert.ToInt32(genericMemberVariable);
            genericMemberVariable = Convert.ToChar(temp1 + 1);
        }
        else
        {
            //for strings it concantinates it to the end
            //others it adds 1 to the current value
            dynamic temp1 = genericMemberVariable;
            dynamic temp2 = 1;

            genericMemberVariable = temp1 + temp2;
        }

        return genericMemberVariable;
    }
    public T genericProperty { get; set; }
}

class GenericArray<T>
{
    private T[] array;
    //inpus the data into the array

    public GenericArray(T[] initalArray)
    {
        array = initalArray;
    }

    public T getData(int columnOne)
    {
        if (columnOne < array.GetLength(0) && columnOne >= -1)
        {
            return array[columnOne];
        }
        else
        {
            Console.WriteLine("Error - outside range of data");
            return default(T);
        }
    }
}

class GenericPair<T, Y>
{
    private T itemOne;
    private Y itemTwo;

    public GenericPair(T valueOne, Y valueTwo)
    {
        itemOne = valueOne;
        itemTwo = valueTwo;
    }

    public T getOne()
    {
        return itemOne;
    }
    public Y getTwo()
    {
        return itemTwo;
    }

}

class MyLinkedList<T>
{
    private int count;
    private MyListNode<T> Head;
    private MyListNode<T> End;
    public void add(T data)
    {
        MyListNode<T> NewNode = new MyListNode<T>();
        NewNode.Data = data;

        if (End != null)
        {
            End.NextNodeRef = NewNode;
        }

        if (Head == null)
        {
            Head = NewNode;
        }

        End = NewNode;

        count++;
    }

    public void insert(T data, int position)
    {
        if (position > -1 && position < count)
        {
            MyListNode<T> NewNode = new MyListNode<T>();
            NewNode.Data = data;

            MyListNode<T> currentPos = Head;

            if (position == 0)
            {
                NewNode.NextNodeRef = Head;
                Head = NewNode;
            }
            else
            {
                for (int i = 0; i < count; i++)
                {
                    if (i == position - 1)
                    {
                        NewNode.NextNodeRef = currentPos.NextNodeRef;
                        currentPos.NextNodeRef = NewNode;
                        break;
                    }
                    currentPos = currentPos.NextNodeRef;
                }
            }
            ++count;
        }
        else if (position == count - 1)
        {
            add(data);
        }
        else
        {
            Console.WriteLine("outside range of data");
        }
    }

    public void remove(int position)
    {
        if (position > -1 && position < count - 1)
        {

            MyListNode<T> currentPos = Head;
            MyListNode<T> nextPos = Head.NextNodeRef;


            if (position == 0)
            {
                currentPos.Data = default(T);
                Head = currentPos.NextNodeRef;
                currentPos.NextNodeRef = default;
            }
            else
            {
                for (int i = 0; i < count; i++)
                {
                    if (i == position - 1)
                    {
                        currentPos.NextNodeRef = nextPos.NextNodeRef;
                        nextPos.Data = default(T);
                        nextPos.NextNodeRef = default;
                        break;
                    }
                    currentPos = nextPos;
                    nextPos = nextPos.NextNodeRef;
                }
            }
            --count;
        }
        else if (position == count - 1)
        {
            removeLast();
        }
        else
        {
            Console.WriteLine("outside range of data");
        }
    }

    public void removeLast()
    {
        if (count == 1)
        {
            Head.Data = default;
            End.Data = default;
        }
        else
        {
            MyListNode<T> temp = Head;
            for (int i = 0; i < count; i++)
            {
                if (temp.NextNodeRef == End)
                {
                    break;
                }
                temp = temp.NextNodeRef;
            }
            End.Data = default;
            End = temp;
            End.NextNodeRef = default;
        }
        --count;
    }

    public void moveDown(int position)
    {
        if (position > -1 && position < count)
        {

            MyListNode<T> currentPos = Head;

            for (int i = 0; i < count; i++)
            {
                if (i == position)
                {
                    insert(currentPos.Data, position + 2);
                    remove(position);
                    break;
                }
                currentPos = currentPos.NextNodeRef;
            }
        }
        else if (position == count)
        {
            Console.WriteLine("cannot increase the index of the end of the list");
        }
        else
        {
            Console.WriteLine("outside range of data");
        }
    }

    public void moveUp(int position)
    {
        if (position > 0 && position < count)
            moveDown(position - 1);
        else if (position == 0)
            Console.WriteLine("cannot decrease the index of the start of the list");
        else
            Console.WriteLine("outside range of data");
    }

    public void printList()
    {
        MyListNode<T> temp = Head;
        for (int i = 0; i < count; i++)
        {
            Console.WriteLine(temp.Data);
            temp = temp.NextNodeRef;
        }
    }
}

class MyListNode<T>
{
    public T Data;
    public MyListNode<T> NextNodeRef;
    public MyListNode<T> PreviousNodeRef;
}

class MyDoubleLinkedList<T>
{
    private int count;
    private MyListNode<T> Head;
    private MyListNode<T> End;
    public void add(T data)
    {
        MyListNode<T> NewNode = new MyListNode<T>();
        NewNode.Data = data;

        if (End != null)
        {
            End.NextNodeRef = NewNode;
        }

        if (Head == null)
        {
            Head = NewNode;
        }
        NewNode.PreviousNodeRef = End;
        End = NewNode;

        count++;
    }

    public void insert(T data, int position)
    {
        if (position > -1 && position < count)
        {
            MyListNode<T> NewNode = new MyListNode<T>();
            NewNode.Data = data;

            MyListNode<T> currentPos = Head;

            if (position == 0)
            {
                NewNode.NextNodeRef = Head;
                Head = NewNode;
                Head.NextNodeRef.PreviousNodeRef = Head;
            }
            else
            {
                for (int i = 0; i < count; i++)
                {
                    if (i == position - 1)
                    {
                        NewNode.NextNodeRef = currentPos.NextNodeRef;
                        currentPos.NextNodeRef = NewNode;
                        NewNode.PreviousNodeRef = currentPos;
                        NewNode.NextNodeRef.PreviousNodeRef = NewNode;
                        break;
                    }
                    currentPos = currentPos.NextNodeRef;
                }
            }
            ++count;
        }
        else if (position == count)
        {
            add(data);
        }
        else
        {
            Console.WriteLine("outside range of data");
        }
    }

    public void remove(int position)
    {
        if (position > -1 && position < count - 1)
        {

            MyListNode<T> currentPos = Head;
            MyListNode<T> nextPos = Head.NextNodeRef;


            if (position == 0)
            {
                currentPos.Data = default(T);
                Head = currentPos.NextNodeRef;
                Head.PreviousNodeRef = default;
                currentPos.NextNodeRef = default;
            }
            else
            {
                for (int i = 0; i < count; i++)
                {
                    if (i == position - 1)
                    {
                        currentPos.NextNodeRef = nextPos.NextNodeRef;
                        currentPos.NextNodeRef.PreviousNodeRef = currentPos;
                        nextPos.Data = default(T);
                        nextPos.NextNodeRef = default;
                        nextPos.PreviousNodeRef = default;
                        break;
                    }
                    currentPos = nextPos;
                    nextPos = nextPos.NextNodeRef;
                }
            }
            --count;
        }
        else if (position == count - 1)
        {
            removeLast();
        }
        else
        {
            Console.WriteLine("outside range of data");
        }
    }

    public void removeLast()
    {
        if (count == 1)
        {
            Head.Data = default;
            End.Data = default;
        }
        else
        {
            MyListNode<T> temp = End.PreviousNodeRef;

            End.Data = default;
            End.PreviousNodeRef = default;
            End = temp;
            End.NextNodeRef = default;
        }
        --count;
    }

    public void moveDown(int position)
    {
        if (position > -1 && position < count)
        {

            MyListNode<T> currentPos = Head;

            for (int i = 0; i < count; i++)
            {
                if (i == position)
                {
                    insert(currentPos.Data, position + 2);
                    remove(position);
                    break;
                }
                currentPos = currentPos.NextNodeRef;
            }
        }
        else if (position == count)
        {
            Console.WriteLine("cannot increase the index of the end of the list");
        }
        else
        {
            Console.WriteLine("outside range of data");
        }
    }

    public void moveUp(int position)
    {
        if (position > 0 && position < count)
            moveDown(position - 1);
        else if (position == 0)
            Console.WriteLine("cannot decrease the index of the start of the list");
        else
            Console.WriteLine("outside range of data");
    }

    public void printList()
    {
        MyListNode<T> temp = Head;
        for (int i = 0; i < count; i++)
        {
            Console.WriteLine(temp.Data);
            temp = temp.NextNodeRef;
        }
    }
    public void printListDebug()
    {
        MyListNode<T> temp = Head;
        for (int i = 0; i < count; i++)
        {
            Console.WriteLine("current data: " + temp.Data);
            if (temp != Head)
                Console.WriteLine("pev: " + temp.PreviousNodeRef.Data);
            if (temp != End)
                Console.WriteLine("next: " + temp.NextNodeRef.Data);
            Console.WriteLine();
            temp = temp.NextNodeRef;
        }
    }

    public T returnData(int position)
    {
        if (-1 < position && position < count)
        {
            MyListNode<T> currentPos = Head;
            for (int i = 0; i < count; i++)
            {
                if (i == position)
                {
                    return currentPos.Data;
                }
                currentPos = currentPos.NextNodeRef;
            }
        }
        return default;
        
    }
}

class MyStack<T>
{
    private MyDoubleLinkedList<T> stackList = new MyDoubleLinkedList<T>();
    private int count;
    public void Enqueue(T data)
    {
        stackList.add(data);
        count++;
    }

    public T Dequeue()
    {
        if (count > 0)
        {
            T data = stackList.returnData(count - 1);
            stackList.removeLast();
            count--;
            return data;
        }
        else
        {
            Console.WriteLine("the stack is empty");
            return default;
        }
    }

    public void PrintStack()
    {
        if (count > 0)
        {
            for (int i = count - 1; i > -1; i--)
            {
                Console.WriteLine((i + 1) + ". " + stackList.returnData(i));
            }
        }
        else
        {
            Console.WriteLine("the stack is empty");
        }
    }
}

class MyQueue<T>
{
    private MyDoubleLinkedList<T> queueList = new MyDoubleLinkedList<T>();
    private int count;
    public void Enqueue(T data)
    {
        queueList.add(data);
        count++;
    }

    public T Dequeue()
    {
        if (count > 0)
        {
            T data = queueList.returnData(0);
            queueList.remove(0);
            count--;
            return data;
        }
        else
        {
            Console.WriteLine("the queue is empty");
            return default;
        }
    }

    public void PrintStack()
    {
        if (count > 0)
        {
            for (int i = 0; i < count; i++) 
            {
                Console.WriteLine((i + 1) + ". " + queueList.returnData(i));
            }
        }
        else
        {
            Console.WriteLine("the queue is empty");
        }
    }

    public T peek()
    {
        return queueList.returnData(0);
    }

}

//binary (minimum) heap
class BinaryHeapMin
{
    private BinaryNode Root;
    private int NodeCount = 0;
    private MyQueue<BinaryNode> freeNodeQueue = new MyQueue<BinaryNode>();
    private BinaryNode lastAddedNode;

    public void insert (int data)
    {
        BinaryNode newNode = new BinaryNode();
        newNode.Data = data;

        if (Root == default)
        {
            Root = newNode;
            freeNodeQueue.Enqueue(Root);
        }
        else
        {
            BinaryNode tempNodeRef = freeNodeQueue.peek();
            if (tempNodeRef.leftNode == null)
            {
                tempNodeRef.leftNode = newNode;
                newNode.parentNode = tempNodeRef;
            }
            else if (tempNodeRef.rightNode == null)
            {
                tempNodeRef.rightNode = newNode;
                newNode.parentNode = tempNodeRef;
                _ = freeNodeQueue.Dequeue();
            }
            freeNodeQueue.Enqueue(newNode);
            newNode.bubble();
            lastAddedNode = newNode;
        }
        NodeCount++;
    }
}

class BinaryNode
{
    public int Data;
    public BinaryNode leftNode;
    public BinaryNode rightNode;
    public BinaryNode parentNode;
    
    public void bubble()
    {
        if (parentNode != null)
        {
            if (this.Data < parentNode.Data)
            {
                int tempData = this.Data;
                this.Data = parentNode.Data;
                parentNode.Data = tempData;
                parentNode.bubble();
            }
            else
            {
                return;
            }
        }
    }
}

class BinarySearchTree
{
    private BinaryNode root;

    public void add(int[] list)
    {
        foreach (int number in list) 
        {
            BinaryNode newNode = new BinaryNode();
            newNode.Data = number;
            if (root == null)
            {
                root = newNode;
            }
            else
            {
                compare(newNode, root);
            }
        }
    }

    private void compare(BinaryNode newNode, BinaryNode comparedNode)
    {
        if (newNode.Data <= comparedNode.Data)
        {
            if (comparedNode.leftNode == null)
            {
                comparedNode.leftNode = newNode;
            }
            else
            {
                compare(newNode, comparedNode.leftNode);
            }
        }
        else
        {
            if (comparedNode.rightNode == null)
            {
                comparedNode.rightNode = newNode;
            }
            else
            {
                compare(newNode, comparedNode.rightNode);
            }
        }
    }

    public bool find(int number)
    {
        return compareNode(number, root);
    }
    private bool compareNode (int number, BinaryNode comparedNode)
    {
        bool output = false;
        if (comparedNode.Data == number)
        {
            output = true;
        }
        else if (number < comparedNode.Data)
        {
            if(comparedNode.leftNode == null)
            {
                output = false;
            }
            else
            {
                output = compareNode(number, comparedNode.leftNode);
            }

        }
        else if (number > comparedNode.Data)
        {
            if (comparedNode.rightNode == null)
            {
                output = false;
            }
            else
            {
                output = compareNode(number, comparedNode.rightNode);
            }
        }
        return output;
    }
}

