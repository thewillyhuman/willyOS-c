using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TPP.Functional.HigherOrder {

    /// <summary>
    /// Example use of the Map higher-order funcion (Select in System.Linq)
    /// </summary>
    internal class Program {

        static void Main() {
            const int numberOfIntegers = 10, numberOfPeople = 10;
            int[] integers = IntegerList.CreateRandomIntegers(numberOfIntegers, -50, 50);

            Console.Write("Integers: [");
            integers.ForEach(Console.Write, integer => Console.Write(", "));
            Console.WriteLine("]");

            // * Square values
            var squareValues = integers.Select(integer => integer * integer);
            Console.Write("\nSquare values: [");
            squareValues.ForEach(Console.Write, integer => Console.Write(", "));
            Console.WriteLine("]");

            // * Summation
            int summation = 0;
            var summations = integers.Select(integer => {
                summation += integer;
                return summation;
            });
            Console.Write("\nSummations: [");
            summations.ForEach(Console.Write, integer => Console.Write(", "));
            Console.WriteLine("]");

            Person[] people = PersonList.CreateRandomPeople(numberOfPeople);
            Console.WriteLine("\nPeople:");
            people.ForEach(Console.WriteLine);

            // * All of them are one year older
            var grownUp = people.Select(person => person.Birthday() );
            Console.WriteLine("\nPeople a year older:");
            grownUp.ForEach(Console.WriteLine);

            // * We take the people's ages
            var ages = people.Select(person => person.Age);
            Console.Write("\nAges: [");
            ages.ForEach(Console.Write, integer => Console.Write(", "));
            Console.WriteLine("]");

            // * People's incomes
            IDictionary<string, decimal> incomePerIdNumber = PersonList.CreateRandomIncomePerPerson(people);
            var incomes = people.Select(person => incomePerIdNumber[person.IDNumber]);
            Console.Write("\nIncomes: [");
            incomes.ForEach(Console.Write, income => Console.Write(", "));
            Console.WriteLine("]");

        }

    }


}
