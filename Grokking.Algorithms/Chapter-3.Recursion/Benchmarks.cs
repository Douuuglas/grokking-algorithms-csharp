using BenchmarkDotNet;
using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;

namespace Chapter_3.Recursion
{
    public class Benchmarks
    {
        /*
         * Recursion is a programming technique where a method calls itself to solve smaller
         * instances of a problem until a base condition is met.Recursion in C# has several implications:
         * - Memory Usage: Each recursive call adds a new stack frame, which can lead to stack
         * overflow if not properly managed.
         * 
         * - Performance: Excessive recursion can be slower due to function call overhead, but it
         * can simplify code in cases like tree traversal.
         * 
         * - Readability & Maintainability: Well-structured recursion can make code elegant and easier to understand,
         * but deep recursion might be harder to debug.
         */

        /*
         * Fibonnaci using simple recursion
         * Time complexity of O(2^n) because each call to Fibonacci results in two more calls, leading to an exponential growth in the number of calls.
         * Space complexity of O(n) because the maximum depth of the recursion stack is n, where n is the input number.
         */
        public static int Fibonacci(int n)
        {
            if (n <= 1)
                return n;

            return Fibonacci(n - 1) + Fibonacci(n - 2);
        }

        /*
         * Fibonnaci with iteration
         * Time complexity of O(n) because we iterate through the loop n times.
         * Space complexity of O(1) because we only use a constant amount of space for the variables `a`, `b`, and `temp`.
         */
        public static int FibonacciIterative(int n)
        {
            int a = 0;
            int b = 1;
            int temp = 0;

            for (int i = 0; i < n; i++)
            {
                temp = a;
                a = b;
                b = temp + b;
            }

            return a;
        }

        /*
         * Fibonnaci with caching
         * Time complexity of O(n) because we compute each Fibonacci number only once and store it in a dictionary.
         * Space complexity of O(n) because we store the computed Fibonacci numbers in a dictionary, which grows with the input size.
         */
        private static Dictionary<int, int> fibValues = new() { { 0, 0 }, { 1, 1 } }; // We start with the results we already know

        public static int FibonacciCaching(int n)
        {
            if (!fibValues.ContainsKey(n))
            {
                fibValues[n] = FibonacciCaching(n - 1) + FibonacciCaching(n - 2);
            }

            return fibValues[n];
        }

        [Benchmark(Baseline = true)]
        public void Fibonacci()
        {
            var result = Fibonacci(10);
            //Console.WriteLine($"Fibonacci: {result}");
        }

        [Benchmark]
        public void FibonacciIterative()
        {
            var result = FibonacciIterative(10);
            //Console.WriteLine($"FibonacciIterative: {result}");
        }

        [Benchmark]
        public void FibonacciCaching()
        {
            var result = FibonacciCaching(10);
            //Console.WriteLine($"FibonacciIterative: {result}");
        }
    }
}
