using System;

namespace examples.genetics {
    
    public class VectorModulusProgram {

        static void Main(string[] args) {
			char[] vector = { 'G', 'T', 'A', 'A', 'A', 'A' };

			Func<char[], double> _f = SearchFunction.Search;

			Master<char, int> master = new Master<char, int>(vector, 1, _f);
            DateTime before = DateTime.Now;
            double result = master.ComputeModulus();
			Console.WriteLine("Appearances :: " + result);
            DateTime after = DateTime.Now;
            Console.WriteLine("Result with one thread: {0:N2}.", result);
            Console.WriteLine("Elapsed time: {0:N0} ticks.",
                (after - before).Ticks );

            master = new Master<char, int>(vector, 2, _f);
            before = DateTime.Now;
            result = master.ComputeModulus();
            after = DateTime.Now;
            Console.WriteLine("Result with 4 threads: {0:N2}.", result);
            Console.WriteLine("Elapsed time: {0:N0} ticks.",
                (after - before).Ticks);

			Console.WriteLine("Appearances :: " + result);
        }

        public static short[] CreateRandomVector(int numberOfElements, short lowest, short greatest) {
            short[] vector = new short[numberOfElements];
            Random random = new Random();
            for (int i = 0; i < numberOfElements; i++)
                vector[i] = (short)random.Next(lowest, greatest + 1);
            return vector;
        }
    }

}
