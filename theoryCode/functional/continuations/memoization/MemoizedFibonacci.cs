using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TPP.Functional.Continuations {

    /// <summary>
    /// Memoized implementation of Fibonacci
    /// </summary>
    static class MemoizedFibonacci {

        /// <summary>
        /// Memoized values
        /// </summary>
        private static IDictionary<int, int> values = new Dictionary<int, int>();

        /// <summary>
        /// Memoized recursive Fibonacci function
        /// </summary>
        internal static int Fibonacci(int n) {
            if (values.Keys.Contains(n))
                // * If it is the cache, we return its value
                return values[n];
            // * Otherwise, we save it before returning it
            int value =  n <= 2 ? 1 : Fibonacci(n - 2) + Fibonacci(n - 1);
            values.Add(n, value);
            return value;
        }


    }
}
