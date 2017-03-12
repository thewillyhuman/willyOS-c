using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TPP.Functional.Continuations {

    static class StandardFibonacci {

        /// <summary>
        /// Typical recursive Fibonacci function
        /// </summary>
        internal static int Fibonacci(int n) {
            return n <= 2 ? 1 : Fibonacci(n - 2) + Fibonacci(n - 1);
        }


    }
}
