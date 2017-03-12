using System;

namespace TPP.Concurrency.Synchronization {

    /// <summary>
    /// Shows how to use Interlocked to assign values to shared variables in concurrent programming
    /// </summary>
    class Program {

        static void Main() {
            const long value = 100000000;
            const int numberOfThreads = 10000;
            Summation summation = new Summation(value, numberOfThreads);
            summation.Compute();
            Console.WriteLine("Value after performing decrementing directly: {0}.", summation.Value);

            summation = new InterlockedSummation(value, numberOfThreads);
            summation.Compute();
            Console.WriteLine("Value after performing decrementing using Interlocked: {0}.", summation.Value);
        }

    }
}
