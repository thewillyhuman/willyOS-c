using System;
using System.Linq;
using System.Collections.Generic;

namespace TPP.Functional.Delegates {

    static public class PersonPrintout {

        private static string[] firstNames = { "María", "Juan", "Pepe", "Luis", "Carlos", "Miguel", "Cristina" };
        private static string[] surnames = { "Díaz", "Pérez", "Hevia", "García", "Rodríguez", "Pérez", "Sánchez" };
        private static int numberOfPeople = 10;

        public static Person[] CreatePeopleRandomly() {
            Person[] printout = new Person[numberOfPeople];
            Random random = new Random();
            for (int i = 0; i < numberOfPeople; i++)
                printout[i] = new Person(firstNames[random.Next(0, firstNames.Length)],
                                         surnames[random.Next(0, surnames.Length)], 
                                         (byte)random.Next(2, 30) );
            return printout;
        }

        public static void ShowPeople(Person[] people) {
            foreach(Person person in people) 
                Console.WriteLine(person);
        }

    }

}
