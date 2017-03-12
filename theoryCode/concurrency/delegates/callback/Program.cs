using System;
using System.Threading;
using System.Runtime.Remoting.Messaging;

namespace TPP.Concurrency.Delegates {

    /// <summary>
    /// Thread creation by means of delegats.
    /// A callback is used to know when the thread has finished its execution.
    /// </summary>
    class Program {

        static void Main(string[] args) {
            string url;
            Menu menu = new Menu();
            while (menu.Show(out url) != Option.Exit) {
                WebPage web = new WebPage(url);
                // * A thread is created with an asynchronous invocaton.
                // * A delegate to pass the BeginInvoke message.
                // * Another delegate is passed as a parameter, acting like a
                //   callback to be called when the thread ends
                ((Func<int>)web.GetNumberOfImages).BeginInvoke(ThreadEnds, url);
            }
        }

        /// <summary>
        /// The method that will be called when the thread ends
        /// </summary>
        /// <param name="asynchronousResult">Information abount the thread executed</param>
        static void ThreadEnds(IAsyncResult asynchronousResult) {
            // * We first obtain the method that created the thread (GetNumberOfImages)
            Func<int> getNumberOfImages = (Func<int>)((AsyncResult)asynchronousResult).AsyncDelegate;
            Console.WriteLine("\n(Thread {0}) The {1} Web page has {2} images.",
                Thread.CurrentThread.ManagedThreadId,
                (string)asynchronousResult.AsyncState,
                getNumberOfImages.EndInvoke(asynchronousResult)
                );
        }

    }
}
