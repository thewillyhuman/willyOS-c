using System;
using System.Threading;

namespace TPP.Concurrency.Synchronization {

    internal class InterlockedSummation: Summation {

        internal InterlockedSummation(long value, int numberOfThreads) :
            base(value, numberOfThreads) {
        }

        override protected void DecrementValue() {
            Interlocked.Decrement(ref this.value);
        }

    }
}
