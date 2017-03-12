using System;

namespace TPP.ObjectOrientation.Generics {

    class Generics {

        /// <summary>
        /// Generic method that returns a reference with the appropriate type
        /// or null if the cast is not valid
        /// </summary>
        /// <typeparam name="T">The type we want to cast the parameter</typeparam>
        /// <param name="reference">The expression to be cast</param>
        /// <returns>The expression with the new type, or null if the cast was not valid</returns>
        public static T ConvertReference<T>(Object reference) {
            if (!(reference is T))
                return default(T); // default value of T type (e.g., 0 for int, double, short...; null for references; false for bool...)
            return (T)reference;
        }

        public static void Main() {
            Object myString = "hello", myInteger = 3;
            // Correct conversions
            Console.WriteLine(ConvertReference<String>(myString));
            Console.WriteLine(ConvertReference<int>(myInteger));
            // Wrong conversions
            Console.WriteLine(ConvertReference<int>(myString));
            Console.WriteLine(ConvertReference<String>(myInteger));
        }
    }

}