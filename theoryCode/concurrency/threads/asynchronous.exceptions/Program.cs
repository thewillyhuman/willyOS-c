using System;
using System.Threading;

namespace TPP.Concurrency.Threads {

    class Program {

        static void Main() {
            try {
                new Thread(() => {
                    Thread.Sleep(500);
                    throw new ApplicationException("Asynchronous exception.");
                }).Start();
            }
            catch (Exception) {
                // * This catch is not executed
                Console.WriteLine("The exception is handled.");
            }
            // * After 0.5 seconds, the unhandled exception makes the
            //   application terminate abnormally (the exception is thrown and 
            //   it is not handled)
            Thread.Sleep(10000);
            Console.WriteLine("End of execution."); // Is not shown in the console
        }

    }

}
