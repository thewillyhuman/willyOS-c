using System;
using System.Threading;

namespace TPP.Concurrency.Threads {

    /// <summary>
    /// Example use of a daemon thread to show the elapsed time
    /// </summary>
    public class DaemonProgram {

        static void Main() {
            Thread background = new Thread(() => {
                int seconds = 0;
                while (true) {
                    Thread.Sleep(1000);
                    Console.WriteLine("\t\t\t\t\t\t\t\t{0} seconds.", ++seconds);
                }
            });
            background.IsBackground = true; // it is a daemon thread
            background.Start();

            Thread foreground = new Thread(() => {
                for (int i = 0; i < 100; i++) {
                    Console.WriteLine("Iteration {0}.", i + 1);
                    Thread.Sleep(100);
                }
            });
            foreground.Start();
        }

    }

}
