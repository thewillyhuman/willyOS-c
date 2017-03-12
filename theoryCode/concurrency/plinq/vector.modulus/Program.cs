using System;
using System.Linq;
using System.Diagnostics;
using System.Collections.Generic;

namespace TPP.Concurrency.PLINQ {


    class PLinq {

        static short[] CreateRandomVector(int numberOfElements, short lowest, short greatest) {
            short[] vector = new short[numberOfElements];
            Random random = new Random();
            for (int i = 0; i < numberOfElements; i++)
                vector[i] = (short)random.Next(lowest, greatest + 1);
            return vector;
        }

        static double VectorModulusLinq(IEnumerable<short> vector) {
            return Math.Sqrt(
                vector.Select(vi => (long)vi * vi)
                    .Aggregate((vi, vj) => vi + vj)
                );
        }

        static double VectorModulusPLinq(IEnumerable<short> vector) {
            return Math.Sqrt(
                vector.AsParallel()
                    .Select(vi => (long)vi * vi)
                    .Aggregate((vi, vj) => vi + vj)

                // with just one aggregate
                // .Aggregate(0L, (acc, item) => acc + item * item)

                );
        }

        static void Main() {
            short[] vector = CreateRandomVector(100000000, -10, 10);

            var r = vector.Select(elemento => Math.Sqrt(elemento));
            var rr = vector.AsParallel().Select(elemento => Math.Sqrt(elemento));

            Stopwatch chrono = new Stopwatch();
            chrono.Start();
            double result = VectorModulusLinq(vector);
            chrono.Stop();
            long millisSequential = chrono.ElapsedMilliseconds;
            Console.WriteLine("Elapsed time in sequential Linq {0}, result {1}.", millisSequential, result);

            chrono.Restart();
            result = VectorModulusPLinq(vector);
            chrono.Stop();
            long millisParallel = chrono.ElapsedMilliseconds;
            Console.WriteLine("Elapsed time in parallel Linq {0}, result {1}.", millisParallel, result);
            Console.WriteLine("Benefit in computing the modulus {0:N}%.", (millisSequential / (double)millisParallel - 1) * 100);

            vector = CreateRandomVector(50000000, -10, 10);
            chrono.Restart();
            result = HighComputationLinq(vector);
            chrono.Stop();
            millisSequential = chrono.ElapsedMilliseconds;
            Console.WriteLine("Elapsed time of high computation with sequential Linq {0}, result {1}.",  millisSequential, result);

            chrono.Restart();
            result = HighComputationPLinq(vector);
            chrono.Stop();
            millisParallel = chrono.ElapsedMilliseconds;
            Console.WriteLine("Elapsed time of high computation with parallel Linq {0}, result {1}.", millisParallel, result);
            Console.WriteLine("Benefif in high computation {0:N}%.", ((double)millisSequential / millisParallel - 1) * 100);
        }

        static double HighComputationLinq(IEnumerable<short> vector) {
            return Math.Sqrt(
                vector
                .Select(vi => vi == 0 ? 1.0 : Math.PI / Math.Pow(Math.E, Math.Abs(vi)))
                    .Aggregate((vi, vj) => Math.Sqrt(Math.Abs(vi))/Math.Sqrt(Math.Abs(vi)))
                );
        }

        static double HighComputationPLinq(IEnumerable<short> vector) {
            return Math.Sqrt(
                vector.AsParallel()
                .Select(vi => vi == 0 ? 1.0 : Math.PI / Math.Pow(Math.E, Math.Abs(vi)))
                    .Aggregate((vi, vj) => Math.Sqrt(Math.Abs(vi)) / Math.Sqrt(Math.Abs(vi)))
                );
        }


    }

}