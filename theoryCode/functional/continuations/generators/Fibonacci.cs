using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TPP.Functional.Continuations {

    class Fibonacci {

        /// <summary>
        /// Returns a generator of infinite terms of the Fibonacci sequence
        /// </summary>
        static internal IEnumerable<int> InfiniteFibonacci() {
            int first = 1, second = 1;
            while (true) {
                // * Returns the first one and stores the execution state.
                // * In the subsequent invocation, the state is retrieved
                //   and the invocation continues after the yield statement
                yield return first;
                int addition = first + second;
                first = second;
                second = addition;
            }
        }


        /// <summary>
        /// Returns a generator of finite terms of the Fibonacci sequence
        /// </summary>
        static internal IEnumerable<int> FiniteFibonacci(int maximumTerm) {
            int first = 1, second = 1, term = 1;
            while (true) {
                yield return first;
                int addition = first + second;
                first = second;
                second = addition;
                if (term++ == maximumTerm)
                    // * No more terms are returned (we are done)
                    yield break;
            }
        }
    }

}
