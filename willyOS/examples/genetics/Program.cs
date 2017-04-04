using System;

namespace examples.genetics {
    
    public class VectorModulusProgram {

		static void MainV3(string[] args) {
			//char[] vector = { 'A', 'B', 'G', 'A', 'B' };
			//char[] vector = { 'G', 'T', 'A', 'A', 'A', 'A' };
			Console.WriteLine("Genes {0} found: {1}", Gene.AAA_GENE.name, new Processor(Chromosome.ONE, Gene.AAA_GENE).Run());

			//foreach(var el in Chromosome.ONE)
			//	Console.Write(el);
		}

		static void MainV2(string[] args) {
			char[] vector = { 'A', 'B'};
			foreach(var el in SearchFunction.ToChunks(vector)) {
				Console.WriteLine(el);
			}
		}

        static void MainV1(string[] args) {
			//char[] vector = { 'G', 'T', 'A', 'A', 'A', 'A' };
			//char[] vector = { 'A', 'B', 'G', 'T', 'A'};
			char[] vector = { 'A', 'B', 'G', 'A', 'B'};
			//char[] vector = { 'A', 'B' };

			Func<char[], Gene, double> _f = SearchFunction.Search;

			Master<char, int> master = new Master<char, int>(vector, 1, _f, Gene.AB_GENE);
            DateTime before = DateTime.Now;
            double result = master.ComputeModulus();
			Console.WriteLine("Appearances :: " + result);
            DateTime after = DateTime.Now;
            Console.WriteLine("Result with one thread: {0:N2}.", result);
            Console.WriteLine("Elapsed time: {0:N0} ticks.",
                (after - before).Ticks );

			master = new Master<char, int>(vector, 1, _f, Gene.AB_GENE);
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
