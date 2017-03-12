using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace TPP.ObjectOrientation.InheritancePolymorphism {

    /// <summary>
    /// Example use of is and as operators
    /// </summary>
    class Program {

        static void Main() {
            // * Creates a polymorphic method
            ArrayList vector = new ArrayList();
            // * Adds a person
            vector.Add(new Person("John", "Doe", 57));
            // * We try to get John, but an object is returned
            // * The next cast is dagerous, because the object is not necessarily a Person 
            //   (a string or other object could have been added in the list)
            Person john = (Person)vector[0];
            Console.WriteLine(john);
            // * To make sure it is a Person, we can use the is operator
            if (vector[0] is Person)
                ((Person)vector[0]).Birthday();
            Console.WriteLine(john);
            // * The previous code uses is and a cast, and both operations have 
            //   low runtime performance
            // * In this scenario, it is better to use as because it performs 
            //   the two operations in one
            Person person = vector[0] as Person;
            if (person != null)
                person.Birthday();
            Console.WriteLine(john);
        }

    }
}
