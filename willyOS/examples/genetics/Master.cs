﻿using System;
using System.Threading;

namespace examples.genetics {

    public class Master<T, K> {

        private T[] vector;

        private int numberOfThreads;

		private Func<T[], double> _f;

        public Master(T[] vector, int numberOfThreads, Func<T[], double> f) {
            if (numberOfThreads < 1 || numberOfThreads > vector.Length)
                throw new ArgumentException("The number of threads must be lower or equal to the number of elements in the vector.");
            this.vector = vector;
            this.numberOfThreads = numberOfThreads;
			_f = f;
        }

        public double ComputeModulus() {
            Worker<T, double>[] workers = new Worker<T, double>[numberOfThreads];
            int itemsPerThread = vector.Length/numberOfThreads;
            for(int i=0; i < numberOfThreads; i++)
                workers[i] = new Worker<T, double>(vector,
					i * itemsPerThread,
					(i < numberOfThreads - 1) ? (i + 1) * itemsPerThread - 1 : vector.Length - 1 // last one

					,_f);

            Thread[] threads = new Thread[workers.Length];
            for(int i=0;i<workers.Length;i++) {
                threads[i] = new Thread(workers[i].Compute); 
                threads[i].Name = "Worker Vector Modulus " + (i+1); 
                threads[i].Priority = ThreadPriority.BelowNormal; 
                threads[i].Start();  
            }

			// Important to wait for all the threads to finish. !!!!
			foreach (var t in threads) {
				t.Join();
			}

            double result = 0.0;
            foreach (Worker<T, double> worker in workers) {
				Console.WriteLine("Worker exited -> " + worker.Result);
				result = result + worker.Result;
            }
            return result;
        }

    }

}
