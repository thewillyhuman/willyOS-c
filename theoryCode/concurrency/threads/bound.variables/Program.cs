using System;
using System.Threading;

namespace TPP.Concurrency.Threads {

    /// <summary>
    /// Concurrent program that shows the execution of lambda expressions with shared bound variables
    /// </summary>
    class Program {

        static int global = 1;

        static void SharedBoundVariables() {
            int local = global = 1;
            Thread thread1 = new Thread( () => {
                    Console.WriteLine("Thread 1. Global {0}, Local {1}.",
                            global, local);
                });
            global = local = 2;
            Thread thread2 = new Thread( () => {
                    Console.WriteLine("Thread 2. Global {0}, Local {1}.",
                            global, local);
                });
            thread1.Start();
            thread2.Start();
        }

        static void MaingACopy() {            
            int local = 1;
            int copy = local;
            Thread thread = new Thread( () => {
                    Console.WriteLine("Making a copy {0}.", copy);
                });
            local = 2;
            thread.Start();
        }

        static void WithParameters() {
            int local = 1;
            Thread thread = new Thread( (parameter) => {
                    Console.WriteLine("With parameter {0}.", parameter);
                });
            local = 2;
            thread.Start(local-1);
        }

        static void Main() {
            SharedBoundVariables();
            MaingACopy();
            WithParameters();
        }

    }

}
