using System;
using System.Linq;
using System.Collections.Generic;

namespace TPP.Functional.Delegates {

    class Program {

        /// <summary>
        /// Defines a delegate type of a method that receives 
        /// an integer and returns another integer
        /// </summary>
        private delegate int Function(int integer);

        /// <summary>
        /// Function (static, class, method) that returns twice the value 
        /// of the parameter passed
        /// </summary>
        private static int Twice(int a) { return a + a; }

        /// <summary>
        /// Higher-order function that receives a function and an integer.
        /// It applies (invokes) twice the function to the integer,
        /// returning the result.
        /// </summary>
        private static int DoubleApplication(Function function, int integer) {
            return function(function(integer));
        }

        static void Main() {
            // * The DoubleApplication higher-order function is called, 
            //   passing the Twice function as a parameter
            Console.WriteLine(DoubleApplication(Twice, 3));

            Person[] people = PersonPrintout.CreatePeopleRandomly();
            // * A delegate is passed as a parameter
            Algorithms.SortPeople(people, Person.CompareByAge);
            Console.WriteLine("\nSorted by age:");
            PersonPrintout.ShowPeople(people);

            Algorithms.SortPeople(people, Person.CompareBySurnameAndName);
            Console.WriteLine("\nSorted by surname and name:");
            PersonPrintout.ShowPeople(people);

            // * Delegate variables can be created
            Algorithms.Comparison comparison;
            comparison = Person.CompareByAge;
            Console.WriteLine("\nThe two first people compared by age: {0}",
                comparison(people[0], people[1]));
            comparison = Person.CompareBySurnameAndName;
            Console.WriteLine("The two first people compared by surname and name: {0}",
                comparison(people[0], people[1]));
        }

    }

}
