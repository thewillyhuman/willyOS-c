using System;
using System.Linq;
using System.Collections.Generic;

namespace TPP.Functional.Closures {

    /// <summary>
    /// Example of partial application of functions
    /// </summary>
    static class Program {

        /// <summary>
        /// Curried function that represent the integer + operator
        /// </summary>
        static Func<int, int> Add(int a) {
            return b => a + b;
        }

        /// <summary>
        /// Curried function that represent the integer > operator
        /// </summary>
        static Predicate<int> GreaterThan(int a) {
            return b => a > b;
        }

        /// <summary>
        /// Function that partially applies the "paramter" as the second parameter of the binary "function"
        /// </summary>
        static Predicate<int> SecondParameter(Func<int, Predicate<int>> predicate, int parameter) {
            return a => predicate(a)(parameter);
        }

        /// <summary>
        /// Function that applies "function" to all the elements in "source" and returns the
        /// collection of the corresponding values returned by those invocations
        /// </summary>
        /// <param name="source">The source collection</param>
        /// <param name="function">The function to be applied to all the elements in the collection</param>
        /// <returns>The resulting collection with the values returned by the corresponding invocations</returns>
        static int[] Map(this int[] source, Func<int, int> function) {
            int[] destination = new int[source.Length];
            for (int i = 0; i < source.Length; i++)
                destination[i] = function(source[i]);
            return destination;
        }

        /// <summary>
        /// Returns a collection with all the elements of the source collection
        /// that fulfill the predicate
        /// </summary>
        static IEnumerable<int> Filter(this IEnumerable<int> source, Predicate<int> predicate) {
            IList<int> destination = new List<int>();
            foreach (int item in source)
                if (predicate(item))
                    destination.Add(item);
            return destination;
        }

        static void Main() {
            int[] integers = new int[10];
            Random random = new Random();
            for (int i = 0; i < integers.Length; i++)
                integers[i] = random.Next(-10, 11);

            Console.Write("Original collection: ");
            integers.Show();

            // Using partial application, we can increment all the elements
            // with the curried addition
            Console.Write("The collection with incremented values: ");
            integers.Map(Add(1)).Show();

            // Only the positive elements are shown
            Console.Write("Positive elements: ");
            integers.Filter(SecondParameter(GreaterThan, 0)).Show();
        }


        static void Show<T>(this IEnumerable<T> collection) {
            int i = 0;
            Console.Write("[");
            foreach (T item in collection) {
                Console.Write(item);
                if (++i < collection.Count())
                    Console.Write(", ");
            }
            Console.WriteLine("]");
        }

    }
}