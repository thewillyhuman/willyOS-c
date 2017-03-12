using System;
using System.Collections.Generic;

namespace TPP.Functional.HigherOrder {

    /// <summary>
    /// Extension methods for the Enumerable type
    /// </summary>
    public static class EnumerableExtensionMethods {

        /// <summary>
        /// Extension method to apply an action to the items in a collection
        /// </summary>
        /// <typeparam name="T">The type of the elements in the collection</typeparam>
        /// <param name="collection">The collection</param>
        /// <param name="action">The action to be performed with every element in the collection</param>
        public static void ForEach<T>(this IEnumerable<T> collection, Action<T> action) {
            foreach (T item in collection)
                action(item);
        }

        /// <summary>
        /// Extension method to apply two actions to the items in a collection
        /// </summary>
        /// <typeparam name="T">The type of the elements in the collection</typeparam>
        /// <param name="collection">The collection</param>
        /// <param name="action1">The first action to be performed with every element in the collection</param>
        /// <param name="action2">The second action to be performed with every element in the collection</param>
        public static void ForEach<T>(this IEnumerable<T> collection, Action<T> action1, Action<T> action2) {
            foreach (T item in collection) {
                action1(item);
                action2(item);
            }
        }

    }

}
