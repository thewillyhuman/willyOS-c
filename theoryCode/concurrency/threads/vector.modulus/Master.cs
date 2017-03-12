using System;
using System.Threading;

namespace TPP.Concurrency.Threads {

    /// <summary>
    /// Computes the modulus (magnitude) of a vector concurrently.
    /// Creates and coordinates a set of worker threads to perform the computation.
    /// </summary>
    public class Master {

        /// <summary>
        /// The vector whose modulus is going to be computed.
        /// </summary>
        private short[] vector;

        /// <summary>
        /// Number of worker threads used in the computation.
        /// </summary>
        private int numberOfThreads;

        public Master(short[] vector, int numberOfThreads) {
            if (numberOfThreads < 1 || numberOfThreads > vector.Length)
                throw new ArgumentException("The number of threads must be lower or equal to the elements of the vector");
            this.vector = vector;
            this.numberOfThreads = numberOfThreads;
        }

        /// <summary>
        /// The method that computes the modulus.
        /// </summary>
        public double ComputeModulus() {
            // * Workers are created
            Worker[] workers = new Worker[this.numberOfThreads];
            int elementsPerThread = this.vector.Length/numberOfThreads;
            for(int i=0; i < this.numberOfThreads; i++)
                workers[i] = new Worker(this.vector, 
                    i*elementsPerThread, 
                    (i<this.numberOfThreads-1) ? (i+1)*elementsPerThread-1: this.vector.Length-1 // last one
                    );
            // * Threads are concurrently started
            Thread[] threads = new Thread[workers.Length];
            for(int i=0;i<workers.Length;i++) {
                threads[i] = new Thread(workers[i].Compute); // we create the threads
                threads[i].Name = "Vector modulus worker " + (i+1); // we name then (optional)
                threads[i].Priority = ThreadPriority.Normal; // we assign them a priority (optional)
                threads[i].Start();   // we start their execution
            }
            // * We wait for them to conclude their computation
            foreach (Thread thread in threads)
                thread.Join();
            // * Finally, we add their values and compute the square root
            long result = 0;
            foreach (Worker worker in workers)
                result += worker.Result;
            return Math.Sqrt(result);
        }

    }

}
