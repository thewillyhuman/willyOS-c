using System;

namespace TPP.ObjectOrientation.Overload {

    /// <summary>
    /// Services of lists of people
    /// </summary>
    public class PersonPrintout {

        // * To generate random people
        private static string[] firstNames = { "María", "Juan", "Pepe", "Luis", "Carlos", "Miguel", "Cristina" };
        private static string[] surnames = { "Díaz", "Pérez", "Hevia", "García", "Rodríguez", "Pérez", "Sánchez" };
        private static int numberOfPeople = 100;

        /// <summary>
        /// People printout
        /// </summary>
        private Person[] printout;

        public PersonPrintout() {
            printout = new Person[numberOfPeople];
            Random random = new Random();
            for (int i = 0; i < numberOfPeople; i++)
                printout[i] = new Person {
                    FirstName = firstNames[random.Next(0, firstNames.Length)],
                    Surname = surnames[random.Next(0, surnames.Length)],
                    Age = random.Next(2, 30),
                    IDNumber = "" + random.Next(9000000, 90000000) + "-" + (char)random.Next('A', 'Z'),
                };
        }

        private int FirstIndex(int page = 1, int itemsPerPage = 10, bool only18AndBeyond = false) {
            int numberOfItemsToReject = (page - 1) * itemsPerPage;
            if (!only18AndBeyond)
                return numberOfItemsToReject;
            int numberPeople18AndBeyond = 0;
            int i;
            for (i = 0; i < printout.Length && numberPeople18AndBeyond < numberOfItemsToReject; i++)
                if (printout[i].Age >= 18)
                    numberPeople18AndBeyond++;
            return i;
        }

        /// <summary>
        /// Returns a list of people (printout)
        /// </summary>
        /// <param name="page">The page in the printout</param>
        /// <param name="itemsPerPage">The number of people per page</param>
        /// <param name="only18AndBeyond">To get only people 18 and beyond</param>
        /// <returns>People printout</returns>
        public Person[] GetPage(int page = 1, int itemsPerPage = 10, bool only18AndBeyond = true) {
            Person[] toReturn = new Person[itemsPerPage];
            int firstIndex = FirstIndex(page, itemsPerPage, only18AndBeyond);
            if (!only18AndBeyond) {
                Array.Copy(this.printout, firstIndex, toReturn, 0, itemsPerPage);
                return toReturn;
            }
            // * We copy the elements
            int storedItems = 0;
            int returnIndex = 0;
            for (int i = firstIndex; i < printout.Length && storedItems < itemsPerPage; i++)
                if (printout[i].Age >= 18) {
                    toReturn[returnIndex++] = printout[i];
                    storedItems++;
                }
            return toReturn;
        }


    }
}


