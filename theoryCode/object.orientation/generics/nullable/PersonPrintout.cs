using System;

namespace TPP.ObjectOrientation.Generics {

    /// <summary>
    /// Printout of person, using nullable types
    /// </summary>
    public class PersonPrintout {

        // * To generate random people
        private static string[] names = { "María", "Juan", "Pepe", "Luis", "Carlos", "Miguel", "Cristina" };
        private static string[] surnames = { "Díaz", "Pérez", "Hevia", "García", "Rodríguez", "Pérez", "Sánchez" };
        private static int numberPeople = 100;

        /// <summary>
        /// Person printout
        /// </summary>
        private Person[] printout;

        public PersonPrintout() {
            printout = new Person[numberPeople];
            Random random = new Random();
            for (int i = 0; i < numberPeople; i++)
                printout[i] = new Person {
                    FirstName = names[random.Next(0, names.Length)],
                    Surname = surnames[random.Next(0, surnames.Length)],
                    // * The random age can also be null
                    Age = random.Next() % 2 == 0 ? null : (int?)random.Next(2, 30),
                    IDNumber = "" + random.Next(9000000, 90000000) + "-" + (char)random.Next('A', 'Z'),
                };
        }

        /// <summary>
        /// A filter of people by age
        /// <param name="ageGreaterOrEqualThan">The minimum age required to a person to not be filtered.
        /// null means no filter.</param>
        /// </summary>
        public Person[] Filter(int? ageGreaterOrEqualThan) {
            // * Is there any filter?
            if (!ageGreaterOrEqualThan.HasValue)
                return printout;
            Person[] toReturn = new Person[printout.Length];
            int numberOfFilteredPeople = 0;
            foreach (Person person in printout)
                // * Value obtains the age (if any)
                if (person.Age.HasValue && person.Age.Value >= ageGreaterOrEqualThan.Value)
                    toReturn[numberOfFilteredPeople++] = person;
            Array.Resize(ref toReturn, numberOfFilteredPeople);
            return toReturn;
        }


        /// <summary>
        /// Returns the summation of the ages
        /// </summary>
        public int AgeSummation() {
            int summation = 0;
            foreach (Person person in this.printout)
                // * The ?? operator evaluates the first expression (left hand side); it it is not null,
                //   its value is returned; otherwise, the second expression (right hand side) is evaluated 
                //   and returned
                summation += person.Age ?? 0;
            return summation;
        }


    }
}


