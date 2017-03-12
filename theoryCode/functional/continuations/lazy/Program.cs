using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace TPP.Functional.Continuations {

    class Program {

        static void Main() {
            const int from = 100, numberOfNumbers = 100000, elementsToBeShown = 10;
            var chrono = new Stopwatch();
            chrono.Start();
            var eagerPrimes = PrimeNumbers.EagerPrimeNumbers(from, numberOfNumbers);
            Console.Write("{0} elements after the {1}-th element (eager):\n\t", elementsToBeShown, from);
            PrimeNumbers.ForEach(eagerPrimes, item => Console.Write("{0} ", item), elementsToBeShown);
            Console.WriteLine();
            chrono.Stop();
            long ticksEager = chrono.ElapsedTicks;

            chrono.Reset();
            chrono.Start();
            var lazyPrimes = PrimeNumbers.LazyPrimeNumbers(from, numberOfNumbers);
            Console.Write("{0} elements after the {1}-th element (lazy):\n\t", elementsToBeShown, from);
            PrimeNumbers.ForEach(lazyPrimes, item => Console.Write("{0} ", item), elementsToBeShown);
            Console.WriteLine();

            chrono.Stop();
            long ticksLazy = chrono.ElapsedTicks;


            Console.WriteLine("Elapsed time for the eager version: {0:N} ticks.", ticksEager);
            Console.WriteLine("Elapsed time for the lazy version: {0:N} ticks.", ticksLazy);
            Console.WriteLine("Lazy is {0:N} times faster.", (double)ticksEager / ticksLazy - 1);

        }

    }
}
