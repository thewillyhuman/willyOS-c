using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TPP.Functional.Continuations {

    static class Functions {
        
        /// <summary>
        /// Recursive Fibonacci function
        /// </summary>
        internal static int Fibonacci(int n) {
            return n <= 2 ? 1 : Fibonacci(n - 2) + Fibonacci(n - 1);
        }

        /// <summary>
        /// Recursive factorial function
        /// </summary>
        internal static int Factorial(int n) {
            return n <= 1 ? 1 : Factorial(n - 1) * n;
        }

        /// <summary>
        /// Function that simulates the square of one of the two parameters (at random)
        /// </summary>
        internal static int EagerSquare(int param1, int param2) {
            if (new Random().Next() % 2 == 0)
                return param1 * param1;
            else
                return param2 * param2;
        }

    }
}
