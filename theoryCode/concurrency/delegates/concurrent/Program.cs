using System;

namespace TPP.Concurrency.Delegates {

    /// <summary>
    /// Example use of delegates in to pass messages asynchronously 
    /// </summary>
    class Program {

        static void Main() {
            WebPage uniovi = new WebPage("http://www.uniovi.es");
            WebPage school = new WebPage("http://www.ingenieriainformatica.uniovi.es");

            Func<int> numberOfImages = uniovi.GetNumberOfImages;

            DateTime before = DateTime.Now;
            // * Asynchronous execution (a secondary thread is created)
            IAsyncResult asynchronousResult = numberOfImages.BeginInvoke(null, null);
            // * Synchronous execution in the main thread 
            int numberOfImgsInSchool = school.GetNumberOfImages();
            // * Wait untill the secondary thread ends
            int numberOfImgsInUniovi = numberOfImages.EndInvoke(asynchronousResult);
            DateTime after = DateTime.Now;

            Console.WriteLine("The University Web has {0:N0} images, and {1:N0} the School Web.",
                numberOfImgsInUniovi, numberOfImgsInSchool);
            Console.WriteLine("Elapsed millisenconds to compute both results: {0:N0}.",
                (after - before).Ticks / TimeSpan.TicksPerMillisecond);
        }

    }
}
