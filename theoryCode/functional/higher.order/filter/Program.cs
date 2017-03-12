using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TPP.Functional.HigherOrder {

    /// <summary>
    /// Example use of the Filter higher-order funcion (Where in System.Linq)
    /// </summary>
    internal class Program {

        static void Main() {
            const int numberOfIntegers = 100, numberOfPeople = 30;
            int[] integers = IntegerList.CreateRandomIntegers(numberOfIntegers);
            Person[] people = PersonList.CreateRandomPeople(numberOfPeople);

            Console.Write("Integers: [");
            integers.ForEach(Console.Write, integer => Console.Write(", "));
            Console.WriteLine("]");

            Console.WriteLine("\nPeople:");
            people.ForEach(Console.WriteLine);

            // * Example use of Filter (Where in Linq)
            // * Even numbers
            var evenNumbers = integers.Where(integer => integer % 2 == 0);
            Console.Write("\nEven numbers: [");
            evenNumbers.ForEach(Console.Write, integer => Console.Write(", "));
            Console.WriteLine("]");

            // * Positive odd numbers
            var positiveOddNumbers = integers.Where(integer => integer % 2 != 0 && integer > 0);
            Console.Write("\nPositive odd numbers: [");
            positiveOddNumbers.ForEach(Console.Write, integer => Console.Write(", "));
            Console.WriteLine("]");

            // * People 18 and beyond
            var beyond18 = people.Where(person => person.Age>=18 );
            Console.WriteLine("\nPeople 18 and beyond:");
            beyond18.ForEach(Console.WriteLine);

            // * People with a specific name
            Random random = new Random();
            string name = PersonList.FirstNames[random.Next(PersonList.FirstNames.Length)];
            var peopleSpecificName = people.Where(person => person.FirstName.Equals(name));
            Console.WriteLine("\nPeople named \"{0}\":", name);
            peopleSpecificName.ForEach(Console.WriteLine);

            // * A new list of integers
            integers = IntegerList.CreateRandomIntegers(numberOfIntegers, -50, 50);
            Console.Write("Integers: [");
            integers.ForEach(Console.Write, integer => Console.Write(", "));
            Console.WriteLine("]");

            // * Computes the set of duplicated numbers (only one ocurrence per duplicated number)
            // * processed stores the integers that were processed
            // * duplicated stores the integers that were already detected as duplicated
            // * setOfDuplicated is like duplictated, but a set (a single occurrence per number)
            IList<int> processed = new List<int>(), duplicated = new List<int>();
            var setOfDuplicated = integers.Where(
                integer => {
                    if (processed.Contains(integer)) {
                        if (duplicated.Contains(integer))
                            return false; // Already included in duplicated
                        duplicated.Add(integer);
                        return true; // It is a duplicated number
                    }
                    processed.Add(integer);
                    return false; // It is not duplicated (by now)
                }
            );
            Console.Write("\nDuplicated values: [");
            setOfDuplicated.ForEach(Console.Write, integer => Console.Write(", "));
            Console.WriteLine("]");
                                       


        }

    }


}
