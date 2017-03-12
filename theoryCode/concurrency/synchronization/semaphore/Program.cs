using System;
using System.Diagnostics;
using System.Threading;

namespace TPP.Concurrency.Synchronization {

    /// <summary>
    /// Example use of semaphores to synchronize processes.
    /// The program has to be run multiple times to see how it works.
    /// The number of executions would be at least as many as numberOfProcesses + 1.
    /// </summary>
    class Program {

        static void Main() {
            string semaphoreName = "www.ingenieriainformatica.uniovi.es/SemaforoDemo";
            int numberOfProcesses = 3;
            Semaphore semaphore = new Semaphore(numberOfProcesses, numberOfProcesses, semaphoreName);
            // * Waits zero milliseconds and returns whether the semaphore is free
            if (!semaphore.WaitOne(0, true)) {
                Console.WriteLine("Too many process accessing the shared resource (the limit is {0}).", numberOfProcesses);
                Console.WriteLine("The process with id {0} will finish.", Process.GetCurrentProcess().Id);
                return; // El programa no se ejecuta
            }
            ExecuteProgram(semaphore);
        }

        static void ExecuteProgram(Semaphore semaphore) {
            Console.WriteLine("This is supposed to be the program exectution.");
            Console.WriteLine("The process with id {0} is accessing the shared resource.", Process.GetCurrentProcess().Id);
            Console.WriteLine("Press Enter to exit.");
            Console.ReadLine();
            // * The semaphore is released, so that a new process can access the shared resource
            semaphore.Release();
        }

    }

}
