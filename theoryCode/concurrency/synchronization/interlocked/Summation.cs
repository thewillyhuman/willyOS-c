using System;
using System.Threading;

namespace TPP.Concurrency.Synchronization {

    internal class Summation {
        protected long value;
        private int numberOfThreads;

        internal Summation(long value, int numberOfThreads) {
            this.value = value;
            this.numberOfThreads = numberOfThreads;
        }

        internal long Value {
            get { return this.value; }
        }

        protected virtual void DecrementValue() {
            value = value - 1;
        }

        internal void Compute() {
            int iterations = (int)value / numberOfThreads;
            Thread[] threads = new Thread[numberOfThreads];
            for (int i = 0; i < numberOfThreads; i++)
                threads[i] = new Thread(() => {
                    for (int j = 0; j < iterations; j++)
                        this.DecrementValue();
                });
            foreach (Thread thread in threads)
                thread.Start();
            foreach (Thread thread in threads)
                thread.Join();
        }
    }
}
