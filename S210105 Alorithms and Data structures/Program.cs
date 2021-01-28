using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

namespace S210105_Alorithms_and_Data_structures
{
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
            //This was usesd to help add 2 generic values together
            //https://stackoverflow.com/questions/8122611/c-sharp-adding-two-generic-values
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

    class GenericPair<T,Y>
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
    class Program
    {
        static void testGenericClass()
        {
            MyGenericClass<int> intGenericClass = new MyGenericClass<int>(10);
            intGenericClass.getType(200);


            MyGenericClass<string> strGenericClass = new MyGenericClass<string>("hello World");
            strGenericClass.getType("hello");

            MyGenericClass<double> doubleGenericClass = new MyGenericClass<double>(10.2);
            doubleGenericClass.getType(200.63);

            MyGenericClass<char> charGenericClass = new MyGenericClass<char>('i');
            charGenericClass.getType('j');

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
            GenericPair<int, string> newPair = new GenericPair<int, string>(3, "hello");
            int one = newPair.getOne();
            string two = newPair.getTwo();
            Console.WriteLine(one);
            Console.WriteLine(two);
        }

        static void testStack()
        {
            Stack<string> bookStack = new Stack<string>();
            bookStack.Push("hello");
            bookStack.Push("world");
            bookStack.Push("wow");
            bookStack.Push("test");

            bookStack.Print();

            Console.WriteLine();
            bookStack.Pop();
            bookStack.Print();

        }

        static void Main(string[] args)
        {
            testGenericClass();
            Console.WriteLine();

            testGenericArray();
            Console.WriteLine();

            testGenericPair();
            Console.WriteLine();

            testStack();
            Console.WriteLine();

            Console.ReadLine();
        }
    }

    class Stack<T>
    {
        private T[] stack = new T[10];
        private int currentStackPlace = -1;

        public void Push(T newItem)
        {
            if (currentStackPlace <= stack.GetLength(0)-1)
            {
                currentStackPlace++;
                stack[currentStackPlace] = newItem;
            }
            else
            {
                Console.WriteLine("stack is full");
            }
        }
        public T Pop()
        {
            if (currentStackPlace != -1)
            {
                T returnValue = stack[currentStackPlace];
                stack[currentStackPlace] = default(T);
                currentStackPlace--;
                return returnValue;
            }
            else
            {
                Console.WriteLine("stack is empty");
                return default(T);
            }
        }

        public void Print()
        {
            for (int i = 9; i > -1; i--)
            {
                Console.WriteLine((i+1) + ": " + stack[i]);
            }
        }

    }

}
