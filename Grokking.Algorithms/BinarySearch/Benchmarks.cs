using System;
using System.Linq;
using BenchmarkDotNet;
using BenchmarkDotNet.Attributes;

namespace BinarySearch
{
    public class Benchmarks
    {
        int[] data = Enumerable.Range(0, 1_000_000_000).ToArray();

        // Interate over all elements of the array to find the element.
        // Making the time complexity O(n) - Linear.
        public static int? SimpleSearch(int[] array, int guess)
        {
            for (int i = 0; i < array.Length; i++) // iterate over all items of the array to find the element
            {
                if (array[i] == guess) // compare the element and return it if found
                {
                    return i;
                }
            }

            return null; // if haven't found the item return null
        }

        // This is a binary search algorithm, which means that it will narrow the search space by half each iteration.
        // Making the time complexity O(log n) - Logarithmic.
        public static int? BinarySearch(int[] array, int guess)
        {
            int low = 0; // array starts here
            int high = array.Length - 1; // array ends here

            while (low <= high) // while haven't narrowed to a single element
            {
                int mid = (low + high) / 2; // get the middle element index
                if (array[mid] == guess) // compare the element
                    return array[mid];

                if (array[mid] <= guess) // if the mid is lower than the guess it means we should take the upper part
                    low = mid + 1;
                else
                    high = mid - 1; // otherwise we should take the lower part
            }

            return null; // if haven't found the item return null
        }

        [Benchmark(Baseline = true)]
        public void SimpleSearch_1_000_000_000()
        {
            // This is the worst case for simple search, as it will iterate over all elements
            int? guess = SimpleSearch(data, 1_000_000_000);
        }

        [Benchmark]
        public void BinarySearch_1_000_000_000()
        {
            // Here we'll see that binary search is way faster than the same guess for simple search
            // because it will narrow the search space by half each iteration
            int? guess = BinarySearch(data, 1_000_000_000);
        }

        [Benchmark]
        public void SimpleSearch_1()
        {
            // This is the best case for simple search, as it will find the element in the first iteration
            int? guess = SimpleSearch(data, 1);
        }

        [Benchmark]
        public void BinarySearch_1()
        {
            // Here we'll see that binary search is slower than the same guess for simple search
            // because it still have to narrow the search space by half each iteration.
            // We don't know the element is at the beginning of the array
            int? guess = BinarySearch(data, 1);
        }
    }
}
