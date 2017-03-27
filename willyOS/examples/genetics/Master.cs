using System;
using System.Threading;

namespace examples.genetics {

    public class Master<T, K> {

        private T[] vector;

        private int numberOfThreads;

		private Func<T[], Gene, double> _f;

		private Gene _Gene;

        public Master(T[] vector, int numberOfThreads, Func<T[], Gene, double> f, Gene Gene) {
            if (numberOfThreads < 1 || numberOfThreads > vector.Length)
                throw new ArgumentException("The number of threads must be lower or equal to the number of elements in the vector.");
            this.vector = vector;
            this.numberOfThreads = numberOfThreads;
			_f = f;
			_Gene = Gene;
        }

        public double ComputeModulus() {
			//Console.WriteLine(1);
            Worker<T, double>[] workers = new Worker<T, double>[numberOfThreads];
            int itemsPerThread = vector.Length/numberOfThreads;
            for(int i=0; i < numberOfThreads; i++)
                workers[i] = new Worker<T, double>(vector,
					i * itemsPerThread,
					(i < numberOfThreads - 1) ? (i + 1) * itemsPerThread - 1 : vector.Length - 1 // last one

				                                   ,_f, _Gene);
			//Console.WriteLine(2);
            Thread[] threads = new Thread[workers.Length];
            for(int i=0;i<workers.Length;i++) {
                threads[i] = new Thread(workers[i].Compute); 
                threads[i].Name = "Worker Vector Modulus " + (i+1); 
                threads[i].Priority = ThreadPriority.BelowNormal; 
                threads[i].Start();  
            }
			//Console.WriteLine(3);
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
