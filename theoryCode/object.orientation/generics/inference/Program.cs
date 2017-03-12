using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TPP.ObjectOrientation.Generics {

    class Program {

        /// <summary>
        /// Generic swap method
        /// </summary>
        /// <typeparam name="T">Generic type</typeparam>
        /// <param name="lhs">Left hand side</param>
        /// <param name="rhs">Right hand side</param>
        static void Swap<T>(ref T lhs, ref T rhs) {
            T temp;
            temp = lhs;
            lhs = rhs;
            rhs = temp;
        }

        static void Main() {
            int a = 1, b = 2;
            // Inference of argument types (int)
            Swap(ref a, ref b);
            double c = 3.3, d=4.4;
            // Inference of argument types (double)
            Swap(ref c, ref d);
            // Cannot infer the types of arguments
            //Swap(ref a, ref d); // Error

            // Inference of implicitly typed local variables
            var vector = new[] { 1, 2, 3 }; // vector is int[]
            foreach (var item in vector) // item is int
                Console.Write("{0} ", item);
        }
    }

}
