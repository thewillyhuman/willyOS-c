using System;
using System.IO;

namespace TPP.Concurrency.Threads {
    
    /// <summary>
    /// Shows the performance cost of context switching
    /// </summary>
    class Program {

        static void Main(string[] args) {
            const int maxNumberOfThreads = 50;
            short[] vector = VectorModulusProgram.CreateRandomVector(100000, -10, 10);
            ShowLine(Console.Out, "Numer of Threads", "Ticks", "Result");
            for (int numberOfThreads = 1; numberOfThreads <= maxNumberOfThreads; numberOfThreads++) {
                Master master = new Master(vector, numberOfThreads);
                DateTime before = DateTime.Now;
                double result = master.ComputeModulus();
                DateTime after = DateTime.Now;
                ShowLine(Console.Out, numberOfThreads, (after - before).Ticks, result);
                GC.Collect(); // The garbage collector is run
                GC.WaitForFullGCComplete();
            }
        }

        private const string CSV_SEPARATOR = ";";

        static void ShowLine(TextWriter stream, string numberOfThreadsTitle, string ticksTitle, string resultTitle) {
            stream.WriteLine("{0}{3} {1}{3} {2}{3}", numberOfThreadsTitle, ticksTitle, resultTitle, CSV_SEPARATOR);
        }

        static void ShowLine(TextWriter stream, int numberOfThreads, long ticks, double result) {
            stream.WriteLine("{0}{3} {1:N0}{3} {2:N2}{3}", numberOfThreads, ticks, result, CSV_SEPARATOR);
        }
    }

}
