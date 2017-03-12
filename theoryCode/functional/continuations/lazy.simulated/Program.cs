using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace TPP.Functional.Continuations {

    class Program {

        static void Main() {
            const int fibonacciTerm = 40;

            var crono = new Stopwatch();
            crono.Start();
            // Both terms are computed although only one is used (eager)
            Functions.EagerSquare(Functions.Fibonacci(fibonacciTerm), Functions.Fibonacci(fibonacciTerm + 1));
            crono.Stop();
            long ticksEager = crono.ElapsedTicks;
            Console.WriteLine("Eager version: {0:N} ticks.", ticksEager);

            crono = new Stopwatch();
            crono.Restart();
            // The only term used in LazySquare is computed (lazy)
            Lazy.LazySquare(() => Functions.Fibonacci(fibonacciTerm), () => Functions.Factorial(fibonacciTerm + 1));
            crono.Stop();
            long ticksLazy = crono.ElapsedTicks;
            Console.WriteLine("Lazy version: {0:N} ticks.", ticksLazy);

            Console.WriteLine("Lazy is {0:N} times faster.", (double)ticksEager / ticksLazy - 1);
        }


    }

}
