using System;
using System.Diagnostics;

namespace TPP.Concurrency.ProcessesThreads {

    /// <summary>
    /// Example program that shows the processes being executed in the computer
    /// </summary>
    class Program {

        static void Main(string[] args) {
            var processes = Process.GetProcesses();
            double totalVirtualMemory = 0;
            int numberOfProcesses = 0;
            foreach (Process process in processes) {
                double virtualMemoryMB = process.VirtualMemorySize64 / 1024.0 / 1024;
                Console.WriteLine("-> PID: {0}\tName: {1}\tVirtual memory: {2:N} MB",
                        process.Id, process.ProcessName, virtualMemoryMB );
                totalVirtualMemory += virtualMemoryMB;
                numberOfProcesses++;
            }
            Console.WriteLine("Total number of processes: {0}.", numberOfProcesses);
            Console.WriteLine("Total virtual memory: {0:N} MBs.", totalVirtualMemory);
        }

    }
}


