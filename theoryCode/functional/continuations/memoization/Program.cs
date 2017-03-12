using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace TPP.Functional.Continuations {

    /// <summary>
    /// Memoization example
    /// </summary>
    class Program {

        static void Main() {
            const int fibonacciTerm = 40;
            int result;

            var crono = new Stopwatch();
            crono.Start();
            result = StandardFibonacci.Fibonacci(fibonacciTerm);
            crono.Stop();
            long ticksNoMemoizationFirstCall = crono.ElapsedTicks;
            Console.WriteLine("No memoization version, first call: {0:N} ticks. Result: {1}.", ticksNoMemoizationFirstCall, result);

            crono.Restart();
            result = StandardFibonacci.Fibonacci(fibonacciTerm);
            crono.Stop();
            long ticksNoMemoizationSeconCall = crono.ElapsedTicks;
            Console.WriteLine("No memoization version, second call: {0:N} ticks. Result: {1}.", ticksNoMemoizationSeconCall, result);

            crono.Restart();
            result = MemoizedFibonacci.Fibonacci(fibonacciTerm);
            crono.Stop();
            long ticksMemoizationFirstCall = crono.ElapsedTicks;
            Console.WriteLine("Memoized version, first call: {0:N} ticks. Result: {1}.", ticksMemoizationFirstCall, result);

            crono.Restart();
            result = MemoizedFibonacci.Fibonacci(fibonacciTerm);
            crono.Stop();
            long ticksMemoizationSecondCall = crono.ElapsedTicks;
            Console.WriteLine("Memoized version, first call: {0:N} ticks. Result: {1}.", ticksMemoizationSecondCall, result);
        }


    }
}
