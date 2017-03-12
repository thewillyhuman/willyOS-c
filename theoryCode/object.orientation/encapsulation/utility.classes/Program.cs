using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TPP.ObjectOrientation.Encapsulation {

    /// <summary>
    /// Class constructor and utility class demo
    /// </summary>
    internal class Program {

        public static void Main() {
            // * Creates three objects
            Class obj1 = new Class(),
                   obj2 = new Class(),
                   obj3 = new Class();

            Console.WriteLine("Values of the objects: {0}, {1}, {2}.",
                obj1.GetRandomValue(), obj2.GetRandomValue(), obj3.GetRandomValue());

            // * Using a utility class

            Console.WriteLine("Sine: {0}, Cosine: {1}, Factorial of 5: {2}.",
                Mathematics.Sine(obj1.GetRandomValue()),
                Mathematics.Cosine(obj1.GetRandomValue()),
                Mathematics.Factorial(5));
                

        }

    }

}
