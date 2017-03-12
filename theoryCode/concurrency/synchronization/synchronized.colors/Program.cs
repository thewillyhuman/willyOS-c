using System;
using System.Threading;

namespace TPP.Concurrency.Synchronization {

    /// <summary>
    /// New synchronized version of the colors.
    /// The concurrent access to the Console is now synchronized.
    /// </summary>
    class Program {
        static void Main(string[] args) {
            Thread[] threads = new Thread[ColorsProgram.colors.Length];
            for (int i = 0; i < threads.Length; i++) {
                SynchronizedColor color = new SynchronizedColor(ColorsProgram.colors[i]);
                threads[i] = new Thread(color.Show);
            }
            foreach (Thread thread in threads)
                thread.Start();
        }
    }

}
