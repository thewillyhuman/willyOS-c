using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace TPP.Concurrency.Delegates {

    /// <summary>
    /// A simple console menu
    /// </summary>
    internal class Menu {

        internal Option Show(out string url) {
            char key;
            do {
                Console.Write("(Thread {0}) Do you want to know the number of image tags in a Web page? (y/n) ", 
                    Thread.CurrentThread.ManagedThreadId);
                key = Console.ReadKey().KeyChar;
            } while (Uppercase(key) !='Y' && Uppercase(key) != 'N');
            if (Uppercase(key) == 'N') {
                url = null;
                return Option.Exit;
            }
            Console.Write("\n(Thread {0}) Write the URL including the protocol (e.g., http://www.uniovi.es): ",
                    Thread.CurrentThread.ManagedThreadId);
            url = Console.ReadLine();
            return Option.AccessWebPage;
        }

        private static char Uppercase(char caracter) {
            return caracter.ToString().ToUpper().ElementAt(0);
        }

    }

    /// <summary>
    /// Different options to be selected by the user in the menu
    /// </summary>
    internal enum Option {
        Exit, AccessWebPage
    }

}
