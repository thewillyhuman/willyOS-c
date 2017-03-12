using System;
using System.Diagnostics;
using System.Threading;

namespace TPP.Concurrency.ProcessesThreads {

    class Program {

        /// <summary>
        /// Shows the threads in a process
        /// </summary>
        /// <param name="threadCollection">The process thread collection</param>
        static void ShowThreads(ProcessThreadCollection threadCollection) {
            foreach (ProcessThread thread in threadCollection) {
                Console.WriteLine("Id: {0}\tStart time: {1}\tPriority: {2}",
                    thread.Id, thread.StartTime.ToShortTimeString(), thread.PriorityLevel);
            }
        }

        static void Main() {
            Thread.CurrentThread.Name = "Main";
            Console.WriteLine("Current thread. Name: {0}, id: {1}, priority: {2}, state: {3}.",
                Thread.CurrentThread.Name,
                Thread.CurrentThread.ManagedThreadId,
                Thread.CurrentThread.Priority,
                Thread.CurrentThread.ThreadState);
            ProcessWrapper process = new ProcessWrapper();
            string nameOfExecutable = "iexplore.exe";
            if (process.Start(nameOfExecutable, "http://www.uniovi.es")) {
                Console.Write("Press enter to show its threads \"{0}\"...", process.Name);
                Console.ReadLine();
                Console.WriteLine("Threads:");
                ShowThreads(process.Threads);
                Console.Write("Press enter to kill the process \"{0}\"...", process.Name);
                Console.ReadLine();
                process.Kill();
            }
            else {
                Console.WriteLine("The process \"{0}\" has not be successfully started.", nameOfExecutable);
            }
        }

    }
}
