using System;
using System.IO;
using System.Drawing;
using System.Threading;


namespace TPP.Concurrency.TPL {

    /// <summary>
    /// Sequential program that processes a set of images.
    /// It is merely used to be compared with the parallel version (the data.parallelism project).
    /// </summary>
    class Program {

        static void Main(string[] args) {
            DateTime before = DateTime.Now;
            string[] files = Directory.GetFiles(@"..\..\..\pics", "*.jpg");
            string newDirectory = @"..\..\..\pics\rotated";
            Directory.CreateDirectory(newDirectory);
            foreach (string file in files) {
                string fileName = Path.GetFileName(file);
                using (Bitmap bitmap = new Bitmap(file)) {
                    Console.WriteLine("Processing the file \"{0}\" with the thread {1}.", fileName, Thread.CurrentThread.ManagedThreadId);
                    bitmap.RotateFlip(RotateFlipType.Rotate180FlipNone);
                    bitmap.Save(Path.Combine(newDirectory, fileName));
                }
            }
            DateTime after = DateTime.Now;
            Console.WriteLine("Elapsed time: {0:N} milliseconds.", (after - before).Ticks / TimeSpan.TicksPerMillisecond);
        }
    }

}
