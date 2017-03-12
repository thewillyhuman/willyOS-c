using System;
using System.Collections.Generic;

namespace TPP.Functional.Continuations {

    class Program {

        static void Main() {
            const int numberOfTerms = 10;
            // * The 10 first tems in the Fibonacci sequence
            int i = 1;
            foreach (int value in Fibonacci.InfiniteFibonacci()) {
                Console.WriteLine("Term {0}: {1}.", i, value);
                if (i++ == numberOfTerms)
                    break;
            }
            Console.WriteLine();
            
            // * A new invocation is a new instance of the function
            //   and returns a new generator 
            var enumerator = Fibonacci.InfiniteFibonacci().GetEnumerator();
            enumerator.MoveNext();
            Console.WriteLine("Term 1: {0}.", enumerator.Current);
            Console.WriteLine();

            // * Finite terms, stating how many terms we want
            i = 1;
            foreach (int value in Fibonacci.FiniteFibonacci(numberOfTerms)) 
                Console.WriteLine("Term {0}: {1}.", i++, value);
        }


    }

}
