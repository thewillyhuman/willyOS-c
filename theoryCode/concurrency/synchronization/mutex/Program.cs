using System;
using System.Diagnostics;
using System.Threading;

namespace TPP.Concurrency.Synchronization {

    /// <summary>
    /// Example used of mutex to synchronize processes.
    /// This program simply avoids starting to instances of itself.
    /// In case the process has already been started, it finishes its own execution.
    /// </summary>
    class Program {

        static void Main() {
            using (var mutex = new Mutex(false, "www.ingenieriainformatica.uniovi.es/MutexDemo")) {
                // * Waits zero milliseconds, returning whether the mutex is free.
                // * Without parameters, waits until the mutex is free.
                if (!mutex.WaitOne(0)) {
                    Console.WriteLine("Another instance of the application is being executed.");
                    Console.WriteLine("The program won't be executed.");
                    return; // The program is not executed
                }
                ExecuteProgram();
            }
        }

        static void ExecuteProgram() {
            Console.WriteLine("This is supposed to be the program execution.");
            Console.WriteLine("Press Enter to exit.");
            Console.ReadLine();
        }

    }

}
