using System;
using System.Threading;

namespace TPP.Laboratory.Concurrency.Lab09 {

    public class Master {

        private short[] vector;

        private int numberOfThreads;

        public Master(short[] vector, int numberOfThreads) {
            if (numberOfThreads < 1 || numberOfThreads > vector.Length)
                throw new ArgumentException("The number of threads must be lower or equal to the number of elements in the vector.");
            this.vector = vector;
            this.numberOfThreads = numberOfThreads;
        }

        public double ComputeModulus() {
            Worker[] workers = new Worker[numberOfThreads];
            int itemsPerThread = vector.Length/numberOfThreads;
            for(int i=0; i < numberOfThreads; i++)
                workers[i] = new Worker(vector, 
                    i*itemsPerThread, 
                    (i<numberOfThreads-1) ? (i+1)*itemsPerThread-1: vector.Length-1 // last one
                    );

            Thread[] threads = new Thread[workers.Length];
            for(int i=0;i<workers.Length;i++) {
                threads[i] = new Thread(workers[i].Compute); 
                threads[i].Name = "Worker Vector Modulus " + (i+1); 
                threads[i].Priority = ThreadPriority.BelowNormal; 
                threads[i].Start();  
            }

			// Important to wait for all the threads to finish.
			foreach (var t in threads) {
				t.Join();
			}

            long result = 0;
            foreach (Worker worker in workers) {
                result += worker.Result;
            }
            return Math.Sqrt(result);
        }

    }

}
