using System;
using System.IO;

namespace TPP.ObjectOrientation.DynamicTyping {

    class Program {

        /// <summary>
        /// Method with dynamic parameters.
        /// Typechecking is postponed until runtime.
        /// </summary>
        /// <param name="a">First value of any type</param>
        /// <param name="b">Second value of any type</param>
        /// <returns>The maximum value, with any type</returns>
        static dynamic Max(dynamic a, dynamic b) {
            return a > b ? a : b;
        }

        static void Main() {
            Console.WriteLine(Max(3, 4));
            Console.WriteLine(Max(4.4, 3.3));
            Console.WriteLine(Max(4, 3.3));
            // No compile-time error, but runtime error
            Console.WriteLine(Max(3.4, "no compiler error"));

            int[] v = new int[] { 1, 2, 3 };
            Show(Concat.dynamicConcat(1, 2), Console.Out);
            Show(Concat.dynamicConcat(0, v), Console.Out);
            Show(Concat.dynamicConcat(v, 4), Console.Out);
            Show(Concat.dynamicConcat(v, new[] { 4, 5, 6 }), Console.Out);
        }

        static void Show<T>(T[] vector, TextWriter output) {
            int i = 0;
            output.Write("[");
            foreach (T item in vector) {
                output.Write(item);
                if (++i < vector.Length)
                    output.Write(", ");
            }
            output.WriteLine("]");
        }

    }
}
