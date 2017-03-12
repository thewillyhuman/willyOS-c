using System;
using System.Threading;

namespace TPP.Concurrency.Threads {

    /// <summary>
    /// Example use of passing parameters to a thread when it is being started
    /// </summary>
    class Program {

        /// <summary>
        /// Function that receives the number to start counting.
        /// Counts 10 numbers from "from", waiting 1 second after showing the number.
        /// </summary>
        static void Show10Numbers(object from) {
            int? fromInt = from as int?;
            if (!fromInt.HasValue)
                throw new ArgumentException("The parameter \"from\" must be an integer");
            for (int i = fromInt.Value; i < 10 + fromInt; i++) {
                Console.WriteLine(i);
                Thread.Sleep(1000); // Sleeps one second
            }
        }

        static void Main() {
            Thread thread = new Thread(Show10Numbers);
            thread.Start(7);
        }
    }

}
