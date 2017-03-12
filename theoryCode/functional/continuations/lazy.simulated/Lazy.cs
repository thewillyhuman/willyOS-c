using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TPP.Functional.Continuations {

    static class Lazy {

        /// <summary>
        /// Function that simulates the square of one of the two parameters (at random).
        /// Uses lazy evaluation. Since C# does not implement lazy parameters, it is
        /// achieved passing two functions as parameters. Whenever the value of the
        /// paramters are needed, the functions are called.
        /// If the parameters are not used, the functions are not called.
        /// The functions are memoized.
        /// </summary>
        /// <returns>The square of one of the parameters (at random)</returns>
        internal static double LazySquare(Func<int> param1, Func<int> param2) {
            if (new Random().Next()%2==0) 
                return param1.Memoize() * param1.Memoize();
            else 
                return param2.Memoize() * param2.Memoize();
        }


        /// <summary>
        /// Memoization of functions with no parameter and return an integer.
        /// Implemented using extesion methods (Func<int>).
        /// </summary>
        /// <param name="funcion">The function to memoize</param>
        /// <returns>The value returned by function. It is chached (memoized).</returns>
        internal static int Memoize(this Func<int> function) {
            if (values.Keys.Contains(function))
                // * In case it was computed already, we return the cached (memoized) value
                return values[function];
            // * Otherwise, we call it and we memoized it before returning it
            int result = function();
            values.Add(function, result);
            return result;
        }

        /// <summary>
        /// Memoized values per function
        /// </summary>
        private static IDictionary<Func<int>, int> values = new Dictionary<Func<int>, int>();

    }

}
