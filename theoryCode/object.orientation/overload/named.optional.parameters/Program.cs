using System;

namespace TPP.ObjectOrientation.Overload {

    /// <summary>
    /// Optional and named parameters demo
    /// </summary>
    class Program {

        static void Show(Person[] people) {
            foreach (Person person in people) {
                Console.WriteLine(person);
            }
            Console.WriteLine();
        }

        static void Main() {
            PersonPrintout printout = new PersonPrintout();

            // * The second page, 5 people per page, any age
            Show(printout.GetPage(2, 5, false));
            // * The third page (by default, 10 people per page), and any age
            Show(printout.GetPage(3));
            // * We jump the first two default parameters, and use named parameters.
            // * The first page, 10 people per page, only 18 and beyond
            Show(printout.GetPage(only18AndBeyond: true));
            // * The order of the parameters can be changed
            Show(printout.GetPage(only18AndBeyond: false, itemsPerPage: 10, page: 1));
            // * Naming the parameters can make the code more legible.
            // * For example, we can name the las parameter to clarify that
            //   false means any age
            Show(printout.GetPage(1, 10, only18AndBeyond: false));
        }


    }

}
