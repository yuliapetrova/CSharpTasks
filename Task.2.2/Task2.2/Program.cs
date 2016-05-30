using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Task2._2
{
    class Program
    {
        static void Main(string[] args)
        {
            // ArrayList vs LinkedList
            Console.WriteLine("ArrayList vs LinkedList ");
            ArrayList testArrayList = new ArrayList();
            CalculateTime(testArrayList, 1000000);
            LinkedList<string> testLinkedList = new LinkedList<string>();
            CalculateTime(testLinkedList, 1000000);

            // Stack vs Queue
            Console.WriteLine("Stack vs Queue ");
            Stack testStack = new Stack();
            CalculateTime(testStack, 1000000);
            Queue testQueue = new Queue();
            CalculateTime(testQueue, 1000000);

            // HashTable vs Dictionary
            Console.WriteLine("HashTable vs Dictionary");
            Hashtable testHashtable = new Hashtable();
            CalculateTime(testHashtable, 1000000);
            Dictionary<int, string> testDictionary = new Dictionary<int, string>();
            CalculateTime(testDictionary, 1000000);
            Console.ReadLine();
        }
        public static void CalculateTime(IList list, int k)
        {
            // Add
            var startAdding = DateTime.Now;
            string test = "Test string";
            for (int i = 0; i < k; i++)
            {
                list.Add(test);
            }
            var finishAdding = DateTime.Now;
            Console.WriteLine("Addition time (" + k + " elements) : " + list.GetType() + "  " + (finishAdding - startAdding));
            // Search
            var startSearch = DateTime.Now;
            for (int i = 0; i < k; i++)
            {
                bool a = list.Contains(test);
            }
            var finishSearch = DateTime.Now;
            Console.WriteLine("Search time (" + k + " elements) : " + list.GetType() + "  " + (finishSearch - startSearch));

            // Remove
            k = 1000;
            var startRemoving = DateTime.Now;
            for (int i = 0; i < k; i++)
            {
                list.Remove(test);
            }
            var finishRemoving = DateTime.Now;
            Console.WriteLine("Removal time (" + k + " elements) : " + list.GetType() + "  " + (finishRemoving - startRemoving) + "\n");
        }

        public static void CalculateTime(LinkedList<string> list, int k)
        {
            // Add
            var startAdding = DateTime.Now;
            string test = "Test string";
            for (int i = 0; i < k; i++)
            {
                list.AddFirst(test);
            }
            var finishAdding = DateTime.Now;
            Console.WriteLine("Addition time (" + k + " elements) : " + list.GetType() + "  " + (finishAdding - startAdding));

            // Search
            var startSearch = DateTime.Now;
            for (int i = 0; i < k; i++)
            {
                bool a = list.Equals(test);
            }
            var finishSearch = DateTime.Now;
            Console.WriteLine("Search time (" + k + " elements) : " + list.GetType() + "  " + (finishSearch - startSearch));

            // Remove
            k = 1000000;
            var startRemoving = DateTime.Now;
            for (int i = 0; i < k; i++)
            {
                list.Remove(test);
            }
            var finishRemoving = DateTime.Now;
            Console.WriteLine("Removal time (" + k + " elements) : " + list.GetType() + "  " + (finishRemoving - startRemoving) + "\n");
        }

        public static void CalculateTime(Stack stack, int k)
        {
            // Add
            var startAdding = DateTime.Now;
            string test = "Test string";
            for (int i = 0; i < k; i++)
            {
                stack.Push(test);
            }
            var finishAdding = DateTime.Now;
            Console.WriteLine("Addition time (" + k + " elements) : " + stack.GetType() + "  " + (finishAdding - startAdding));

            // Search
            var startSearch = DateTime.Now;
            for (int i = 0; i < k; i++)
            {
                bool a = stack.Contains(test);
            }
            var finishSearch = DateTime.Now;
            Console.WriteLine("Search time (" + k + " elements) : " + stack.GetType() + "  " + (finishSearch - startSearch));

            // Remove
            k = 1000000;
            var startRemoving = DateTime.Now;
            for (int i = 0; i < k; i++)
            {
                stack.Pop();
            }
            var finishRemoving = DateTime.Now;
            Console.WriteLine("Removal time (" + k + " elements) : " + stack.GetType() + "  " + (finishRemoving - startRemoving) + "\n");
        }

        public static void CalculateTime(Queue stack, int k)
        {
            // Add
            var startAdding = DateTime.Now;
            string test = "Test string";
            for (int i = 0; i < k; i++)
            {
                stack.Enqueue(test);
            }
            var finishAdding = DateTime.Now;
            Console.WriteLine("Addition time (" + k + " elements) : " + stack.GetType() + "  " + (finishAdding - startAdding));

            // Search
            var startSearch = DateTime.Now;
            for (int i = 0; i < k; i++)
            {
                bool a = stack.Equals(test);
            }
            var finishSearch = DateTime.Now;
            Console.WriteLine("Search time (" + k + " elements) : " + stack.GetType() + "  " + (finishSearch - startSearch));

            // Remove
            k = 1000000;
            var startRemoving = DateTime.Now;
            for (int i = 0; i < k; i++)
            {
                stack.Dequeue();
            }
            var finishRemoving = DateTime.Now;
            Console.WriteLine("Removal time (" + k + " elements) : " + stack.GetType() + "  " + (finishRemoving - startRemoving) + "\n");
        }

        public static void CalculateTime(IDictionary table, int k)
        {
            // Add 
            var startAdding = DateTime.Now;
            string[] test = { "Key string", "Test string" };
            for (int i = 0; i < k; i++)
            {
                table.Add(i, test[1]);
            }
            var finishAdding = DateTime.Now;
            Console.WriteLine("Addition time (" + k + " elements) : " + table.GetType() + "  " + (finishAdding - startAdding));

            // Search
            var startSearch = DateTime.Now;
            for (int i = 0; i < k; i++)
            {
                bool a = table.Contains("Key");
            }
            var finishSearch = DateTime.Now;
            Console.WriteLine("Search time (" + k + " elements) : " + table.GetType() + "  " + (finishSearch - startSearch));

            // Remove 
            k = 1000000;
            var startRemoving = DateTime.Now;
            for (int i = 0; i < k; i++)
            {
                table.Remove(i);
            }
            var finishRemoving = DateTime.Now;
            Console.WriteLine("Removal time (" + k + " elements) : " + table.GetType() + "  " + (finishRemoving - startRemoving) + "\n");
        }
    }
}
