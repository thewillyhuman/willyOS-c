using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TPP.ObjectOrientation.Encapsulation {


    class Program {

        static void Main(string[] args) {
            // * Simulates the access to a DB
            Person person = Person.Create("John", "Doe", 57, "56739674-F");
            Console.WriteLine(person); 
            // * We use a business rule (in the other file)
            person.Birthday();
            Console.WriteLine(person);
            // * The new date is supposed to be updated
            person.Update();
        }


    }
}
