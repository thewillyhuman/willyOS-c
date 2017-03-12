using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TPP.Functional.Continuations {
    
    /// <summary>
    /// This program does NOT work, because C# does not implement continuations.
    /// It is an example of how continuations would behave if they were implemented in C#.
    /// Ruby and Scheme are two languages that do implement continuations this way.
    /// </summary>
    class Program {

        static Func<int> Continuation = null;

        static int Test() {
            int i = 0;
            // * Assigns to Continuation the dynamic state of the program (in this line of execution)
            // callcc(state => Continuation = state);
            i = i + 1;
            return 1;
        }

        static void Main() {
            Console.Write(Test());          // 1
            Console.Write(Continuation());  // 2
            Console.Write(Continuation());  // 3

            Func<int> anotherContinuation = Continuation;
            // Resets the continuation
            Console.Write(Test());          // 1
            Console.Write(Continuation());  // 2

            // Uses the first one, once again
            Console.Write(anotherContinuation());  // 4
        }


    }

}
