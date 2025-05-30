using BenchmarkDotNet;
using BenchmarkDotNet.Attributes;
using System;
using System.Linq;

namespace Chapter_2.SelectionSort
{
    public class Benchmarks
    {
        int[] data = Enumerable.Range(0, 1_000).Reverse().ToArray();

        /*
         * Selection Sort is a simple sorting algorithm that repeatedly finds the smallest element
         * from the unsorted portion of an array and swaps it with the first unsorted element.
         * This process continues until the entire array is sorted.
         * This algorithm has a time complexity of O(n²), making it inefficient for large datasets. 
         */

        public void SelectionSort(int[] array)
        {
            int n = array.Length;
            for (int i = 0; i < n; i++) // interate over the array item by item
            {
                int minIndex = i;
                for (int j = i + 1; j < n; j++) // get the i item and compare with all others
                {
                    if (array[j] < array[minIndex]) // if the next item j is smaller, get the next item index
                    {
                        minIndex = j;
                    }
                }

                int temp = array[minIndex]; // create a copy of the smallest item
                array[minIndex] = array[i]; // invert the positions
                array[i] = temp; // move the smaller item to the begining
            }
        }

        [Benchmark(Baseline = true)]
        public void SelectionSort()
        {
            SelectionSort(data);
        }

        [Benchmark]
        public void SelectionSortUsingLinq()
        {
            var newArray = data.Order().ToArray();
        }
    }
}
