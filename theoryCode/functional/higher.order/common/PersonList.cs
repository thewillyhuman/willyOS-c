using System;
using System.Linq;
using System.Collections.Generic;

namespace TPP.Functional.HigherOrder {

    /// <summary>
    /// Creates a collection of random people
    /// </summary>
    static public class PersonList {

        private static string[] firstNames = { "María", "Juan", "Pepe", "Luis", "Carlos", "Miguel", "Cristina" };
        private static string[] surnames = { "Díaz", "Pérez", "Hevia", "García", "Rodríguez", "Pérez", "Sánchez" };

        /// <summary>
        /// Returns a collection of random people
        /// </summary>
        public static Person[] CreateRandomPeople(int numberOfPeople) {
            Person[] collection = new Person[numberOfPeople];
            Random random = new Random();
            for (int i = 0; i < numberOfPeople; i++)
                collection[i] = new Person(firstNames[random.Next(0, firstNames.Length)],
                                         surnames[random.Next(0, surnames.Length)], 
                                         (byte)random.Next(2, 30),
                                         ""+random.Next(9000000,90000000)+(char)random.Next('A','Z')
                                         );
            return collection;
        }

        /// <summary>
        /// Returns the collection of possible names
        /// </summary>
        public static string[] FirstNames {
            get { return firstNames; }
        }

        /// <summary>
        /// Creates a list of random incomes (salaries) per person
        /// </summary>
        /// <param name="people">The people</param>
        /// <returns>A dictionary of income per person. 
        /// The person id number is the key in the dictionary.</returns>
        public static IDictionary<string,decimal> CreateRandomIncomePerPerson(IEnumerable<Person> people) {
            IDictionary<string, decimal> incomes = new Dictionary<string, decimal>();
            Random random = new Random();
            foreach (Person person in people) {
                decimal income = random.Next(15000, 80000);
                income += (decimal)random.Next(0,100)/100; // cents
                incomes[person.IDNumber] = income;
            }
            return incomes;
        }

    }

}
