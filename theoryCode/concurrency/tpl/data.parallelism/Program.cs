using System;
using System.IO;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;


namespace TPP.Concurrency.TPL {

    /// <summary>
    /// Using TPL, the following class parallelizes the "sequential.data.processing" project
    /// </summary>
    class Program {

        static void Main(string[] args) {
            DateTime before = DateTime.Now;
            string[] fileNames = Directory.GetFiles(@"..\..\..\pics", "*.jpg");
            string newDirectory = @"..\..\..\pics\rotated";
            Directory.CreateDirectory(newDirectory);

            // The following tasks are executed in parallel.
            // The program creates POTENTIALLY as many tasks as elements in the enumeration.
            Parallel.ForEach(fileNames, file => {
                string fileName = Path.GetFileName(file);
                using (Bitmap bitmap = new Bitmap(file)) {
                    Console.WriteLine("Processing the \"{0}\" file with thread {1}.", fileName, Thread.CurrentThread.ManagedThreadId);
                    bitmap.RotateFlip(RotateFlipType.Rotate180FlipNone);
                    bitmap.Save(Path.Combine(newDirectory, fileName));
                }
            });
            // Notice, TPL waits for task termination
            DateTime after = DateTime.Now;
            Console.WriteLine("Elapsed time: {0:N} milliseconds.", (after - before).Ticks / TimeSpan.TicksPerMillisecond);
        }
    }

}
