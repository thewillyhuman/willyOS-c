using System;
using System.Collections.Generic;

namespace TPP.Functional.Delegates {

    static class EnumerableExtensionMethods {

        /// <summary>
        /// Extension method to execute any action on the items in a enumerable
        /// </summary>
        static public void ForEach<T>(this IEnumerable<T> collection, Action<T> action) {
            foreach (T item in collection)
                Console.WriteLine(item);
        }
    }

}
