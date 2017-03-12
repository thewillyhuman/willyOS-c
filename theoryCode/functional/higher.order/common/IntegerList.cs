using System;
using System.Linq;
using System.Collections.Generic;

namespace TPP.Functional.HigherOrder {

    /// <summary>
    /// Creates a collection of random integers
    /// </summary>
    static public class IntegerList {

        /// <summary>
        /// Returns a collection of random integers
        /// </summary>
        public static int[] CreateRandomIntegers(int numberOfElements, int lowest=Int32.MinValue, int greatest=Int32.MaxValue) {
            int[] collection = new int[numberOfElements];
            Random random = new Random();
            for (int i = 0; i < numberOfElements; i++)
                collection[i] = random.Next(lowest, greatest);
            return collection;
        }

    }

}
