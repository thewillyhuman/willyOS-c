using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TPP.Functional.Closures {

    class Program {

        /// <summary>
        /// A curried addition function.
        /// Receives a unique parameter and returns a function.
        /// The returned function is another function that, when invoked,
        /// adds the value of the first invocation with the value of the 
        /// second one.
        /// </summary>
        static Func<int, int> CurriedAdd(int a) {
            return b => a + b;
        }

        /// <summary>
        /// A generic contains curried function (predicate).
        /// The first parameter is a generic array.
        /// Returns a function that, receiving an element, checks whether
        /// the element is contained in the array.
        /// </summary>
        static Func<T, bool> CurriedContains<T>(T[] vector) {
            return element => {
                foreach (T el in vector)
                    if (el.Equals(element))
                        return true;
                return false;
            };
        }

        static void Main() {
            const int a = 2, b = 1;
            Console.WriteLine("Curried addition: {0}", CurriedAdd(a)(b));

            int[] integers = { 1, 2, 3, 4, 5 };
            // * We can use the returned function...
            var containsInteger = CurriedContains(integers);
            // * ... and use it in different contexts
            Console.WriteLine("Does 2 exist in the collection? {0}", containsInteger(2));
            Console.WriteLine("Does 10 exist in the collection? {0}", containsInteger(10));

            string[] languages = { "C#", "F#", "ML", "Haskell" };
            Console.WriteLine("Does ML exist in the collection? {0}", CurriedContains(languages)("ML"));
            Console.WriteLine("Does Java exist in the collection? {0}", CurriedContains(languages)("Java"));
        }


    }

}
