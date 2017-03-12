using System.Net;
using System;


namespace TPP.Concurrency.Delegates {

    class Program {

        static void Main() {
            WebPage uniovi = new WebPage("http://www.uniovi.es");
            WebPage school = new WebPage("http://www.ingenieriainformatica.uniovi.es");

            DateTime before = DateTime.Now;
            int numberOfImgsInUniovi = uniovi.GetNumberOfImages();
            int numberOfImgsInSchool = school.GetNumberOfImages();
            DateTime after = DateTime.Now;

            Console.WriteLine("The University Web has {0:N0} images, and {1:N0} the School Web.",
                numberOfImgsInUniovi, numberOfImgsInSchool);
            Console.WriteLine("Elapsed millisenconds to compute both results: {0:N0}.",
                (after - before).Ticks / TimeSpan.TicksPerMillisecond);
        }

    }
}
