using BenchmarkDotNet;
using BenchmarkDotNet.Attributes;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Chapter_5.HashTable
{
    public class Benchmarks
    {
        /*
         * Hash tables are implemented using the Hashtable class from the System.Collections namespace.
         * Hash tables provide an efficient way to store key-value pairs, allowing fast retrieval of data based on a key.
         * Time Complexity (Big-O Notation):
         * - Insertion: O(1) on average, but worst-case O(n) if collisions occur frequently.
         * 
         * - Lookup: O(1) on average, but worst-case O(n) in case of high collision rates.
         * 
         * - Deletion: O(1) on average, worst-case O(n).
         * 
         * - Iteration: O(n) since every element is visited.
         * 
         * Memory Complexity:
         * - Hash tables require additional memory for maintaining hash indices, leading to O(n) space complexity.
         * 
         * For better type safety, Dictionary<TKey, TValue> (from System.Collections.Generic) is preferred.
         */

        [Benchmark(Baseline = true)]
        public void Hashtable()
        {
            // Creating a Hashtable
            Hashtable hashTable = new Hashtable();

            // Adding key-value pairs
            hashTable.Add("Name", "Douglas");
            hashTable.Add("Age", 35);
            hashTable.Add("Country", "Brazil");

            // Retrieving values
            var name = hashTable["Name"];
            var age = hashTable["Age"];
            var country = hashTable["Country"];
        }

        [Benchmark]
        public void Dictionary()
        {
            // Creating a Hashtable
            Dictionary<string, string> dictionary = new();

            // Adding key-value pairs
            dictionary.Add("Name", "Douglas");
            dictionary.Add("Age", "35");
            dictionary.Add("Country", "Brazil");

            // Retrieving values
            var name = dictionary["Name"];
            var age = dictionary["Age"];
            var country = dictionary["Country"];
        }
    }
}
