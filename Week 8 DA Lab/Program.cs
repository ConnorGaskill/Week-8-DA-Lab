using System;
using System.Collections.Generic;

/* 
Reflection:
In my custom hash table, whenever two or more keys map to the same bucket, they are stored together in that bucket’s list. 
This approach (separate chaining) prevents collisions from overwriting data, but it also means searches in that bucket 
take longer as the list grows. The structure works fine for small sets of keys, but performance can drop if many values pile 
into the same bucket or if the table size isn’t chosen well.

The Dictionary in C# simplifies all of this by managing hashing, resizing, and collision handling behind the scenes. It automatically 
balances performance by expanding when needed and uses optimized algorithms to keep lookups fast, even when many items are stored. 
As a developer, you simply work with keys and values without worrying about bucket management or collision resolution.

You might implement your own hash table when you need full control over how hashing works—for example, in academic settings, 
performance-critical systems, memory-constrained environments, or when experimenting with custom data structures. In most 
real-world applications, though, Dictionary is the more reliable and efficient choice. 
*/

namespace Lab8_HashTables
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Part A: Custom Hash Table");

            SimpleHashTable table = new SimpleHashTable(5);
            int[] keysToInsert = { 12, 22, 37 };
            foreach (int key in keysToInsert)
            {
                table.Insert(key);
            }

            table.PrintTable();

            Console.WriteLine($"Contains 22? {table.Contains(22)}");
            Console.WriteLine($"Contains 99? {table.Contains(99)}");

            Console.WriteLine("\nPart B: Dictionary Comparison");

            Dictionary<string, string> phoneBook = new Dictionary<string, string>();
            phoneBook["Alice"] = "555-1234";
            phoneBook["Bob"] = "555-5678";
            phoneBook["Charlie"] = "555-9012";

            Console.WriteLine($"Alice's number: {phoneBook["Alice"]}");
            Console.WriteLine($"Contains David? {phoneBook.ContainsKey("David")}");
        }
    }

    class SimpleHashTable
    {
        private List<int>[] buckets;

        public SimpleHashTable(int size)
        {
            buckets = new List<int>[size];
            for (int i = 0; i < size; i++)
            {
                buckets[i] = new List<int>();
            }
        }

        private int GetBucketIndex(int key)
        {
            return key % buckets.Length;
        }

        public void Insert(int key)
        {
            int index = GetBucketIndex(key);
            buckets[index].Add(key);
        }

        public bool Contains(int key)
        {
            int index = GetBucketIndex(key);
            return buckets[index].Contains(key);
        }

        public void PrintTable()
        {
            for (int i = 0; i < buckets.Length; i++)
            {
                Console.Write($"Bucket {i}: ");
                foreach (var key in buckets[i])
                {
                    Console.Write(key + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
