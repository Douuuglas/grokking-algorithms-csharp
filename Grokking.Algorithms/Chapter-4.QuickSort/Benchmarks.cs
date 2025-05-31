using BenchmarkDotNet.Attributes;
using System;

namespace Chapter_4.QuickSort
{
    public class Benchmarks
    {
        int[] array = { 4, 2, 8, 7, 1, 5, 3, 6 };

        /*
         * QuickSort is a divide-and-conquer sorting algorithm that works by selecting a pivot element, partitioning the array into two halves,
         * and recursively sorting each half. Here’s how it works step by step:
         * - Choose a Pivot: Typically, we pick the last element as the pivot.
         * 
         * - Partition the Array: Rearrange elements so that all values smaller than or equal to the pivot are on the left,
         * and all values greater than the pivot are on the right. This is done by setting left and right side pointers,
         * they walk to the middle of the array and swap positions when they find values on the incorrect side.
         * 
         * - Recursively Apply QuickSort: The algorithm is applied separately to the left and right partitions until the array is sorted.
         */
        public void QuickSort(int[] array)
            => QuickSort(array, 0, array.Length - 1);

        private void QuickSort(int[] array, int start, int end)
        {
            int pivot = array[start]; // Set the first item as the pivot
            int left = start; // Set the left "pointer"
            int right = end; // Set the right "pointer"

            while (left <= right) // Do the work until the pointers have crossed each other
            {
                /*
                 * If the left value is smaller than the pivot it means it's on the correct place,
                 * move the left pointer one position to the right to test the next value, otherwise
                 * we should stop as the value is in the incorret place and needs to swapped
                 */
                while (array[left] < pivot) left++;

                /*
                 * If the right value is bigger than the pivot it means it's on the correct place,
                 * move the right pointer one position to the left to test the next value, otherwise
                 * we should stop as the value is in the incorret place and needs to swapped
                 */
                while (array[right] > pivot) right--;

                if (left <= right) // Swap until the pointers have crossed each other
                {
                    (array[left], array[right]) = (array[right], array[left]);

                    /*
                     * As we swapped the values we know that now they are in a correct place,
                     * so we can move the pointers one more time
                     */
                    left++;
                    right--;
                }
            }

            /*
             * If the right pinter hasn't reached the start it means we still haven't finished ordering
             * the left side of the array, so we call the function again on the left side
             */
            if (start < right) QuickSort(array, start, right);

            /*
             * If the left pinter hasn't reached the end it means we still haven't finished ordering
             * the right side of the array, so we call the function again on the right side
             */
            if (left < end) QuickSort(array, left, end);
        }

        [Benchmark(Baseline = true)]
        public void QuickSort()
        {
            QuickSort(array);
        }

        [Benchmark]
        public void ArraySort()
        {
            Array.Sort(array);
        }
    }
}
