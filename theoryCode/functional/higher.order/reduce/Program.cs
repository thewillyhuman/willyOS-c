using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TPP.Functional.HigherOrder {

    /// <summary>
    /// Example use of the Reduce (Fold, Accumulate, Compress o Inject) higher-order funcion (Aggregate in System.Linq)
    /// </summary>
    class Program {

        static void Main() {
            const int numberOfIntegers = 10, numberOfPeople = 10;
            int[] integers = IntegerList.CreateRandomIntegers(numberOfIntegers, -50, 50);

            Console.Write("Integers: [");
            integers.ForEach(Console.Write, integer => Console.Write(", "));
            Console.WriteLine("]");

            // * Summation and arithmetic mean
            int summation = integers.Aggregate((e1, e2) => e1 + e2);
            Console.WriteLine("Summation: {0}\nAritmetic mean: {1}",
                summation, summation / (double)numberOfIntegers);

            // * An initial value (seed) can be passed
            int zero = integers.Aggregate(-summation, (e1, e2) => e1 + e2);
            Console.WriteLine("-Summation + Summation: {0}", zero);

            // * When performing subtraction, we have to be careful, because
            //   the - operator is not associative => (1 - 2) - 1 = -2 <> 1 - (2 - 1) = 0
            // * Therefore, the iteration order matters (left to right <> right to left)
            // * From left to right
            int leftToRight = integers.Aggregate((e1, e2) => e1 - e2);
            Console.WriteLine("Left to right subtraction: {0}", leftToRight);
            // * Right to left:
            int rightToLeft = integers.Reverse().Aggregate((e1, e2) => e1 - e2);
            Console.WriteLine("Right to left subtraction: {0}", rightToLeft);

            // * We compute the average income
            Person[] people = PersonList.CreateRandomPeople(numberOfPeople);
            IDictionary<string, decimal> incomePerIdNumber = PersonList.CreateRandomIncomePerPerson(people);
            var incomeSummation = people
                                .Select(person => incomePerIdNumber[person.IDNumber])
                                .Aggregate((income1, income2) => income1 + income2);
            Console.WriteLine("Average income: {0:N} euros.", incomeSummation / people.Length);
        }

    }

}
