using System;
using System.Collections.Generic;

namespace TPP.ObjectOrientation.Generics {

    /// <summary>
    /// Nullable types demo
    /// </summary>
    class Program {

        static void Show(IEnumerable<Person> people) {
            foreach (Person person in people) {
                Console.WriteLine(person);
            }
            Console.WriteLine();
        }

        static void Main() {
            PersonPrintout printout = new PersonPrintout();
            // * Shows all the people
            Console.WriteLine("All the people:");
            Show(printout.Filter(null));
            // * Only those 18 or beyond
            Console.WriteLine("\n18 or beyond:");
            Show(printout.Filter(18));
            // * Shows the summation of all the ages (including people without
            //   a value in their age)
            Console.WriteLine("\nSumatorio de las edades: {0}.", printout.AgeSummation());
        }


    }

}
