using System;

namespace TPP.Concurrency.Threads {
    
    public class VectorModulusProgram {

        static void Main(string[] args) {
            short[] vector = CreateRandomVector(100000, -100, 100);

            // * Computation with one single thread
            Master master = new Master(vector, 1);
            DateTime before = DateTime.Now;
            double result = master.ComputeModulus();
            DateTime after = DateTime.Now;
            Console.WriteLine("The result obtained with one single thread is: {0:N2}.", result);
            Console.WriteLine("Elapsed time: {0:N0} ticks.",
                (after - before).Ticks );

            // * Computation with four threads
            master = new Master(vector, 4);
            before = DateTime.Now;
            result = master.ComputeModulus();
            after = DateTime.Now;
            Console.WriteLine("The result obtained with four threads is: {0:N2}.", result);
            Console.WriteLine("Elapsed time: {0:N0} ticks.",
                (after - before).Ticks);
        }

        /// <summary>
        /// Creates a random vector of short numbers
        /// </summary>
        /// <param name="numberOfElements">The size of the vector</param>
        /// <param name="lowest">The lowest value to be used in the generation of vector elements</param>
        /// <param name="greatest">The greatest value to be used in the generation of vector elements</param>
        /// <returns>The random vector</returns>
        public static short[] CreateRandomVector(int numberOfElements, short lowest, short greatest) {
            short[] vector = new short[numberOfElements];
            Random random = new Random();
            for (int i = 0; i < numberOfElements; i++)
                vector[i] = (short)random.Next(lowest, greatest + 1);
            return vector;
        }

    }

}
