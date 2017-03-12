using System;

namespace TPP.ObjectOrientation.Encapsulation {

    /// <summary>
    /// Example utility class that provides math services
    /// </summary>
    public static class Mathematics {

        /// <summary>
        /// Angle sine
        /// </summary>
        public static double Sine(double radians) {
            return Math.Sin(radians);
        }

        /// <summary>
        /// Angle cosine
        /// </summary>
        public static double Cosine(double radians) {
            return Math.Cos(radians);
        }

        /// <summary>
        /// Angle tangent
        /// </summary>
        public static double Tangent(double radians) {
            return Sine(radians) / Cosine(radians);
        }

        /// <summary>
        /// Factorial
        /// </summary>
        public static ulong Factorial(ulong n) {
            if (n == 0) 
                return 1;
            return n * Factorial(n - 1);
        }


        /// <summary>
        /// It is not allowed to implement instance (non-static) methods.
        /// If the following method is uncommented, a compiler error is obtained.
        /// </summary>
        //public void error() {
        //}

    }
}
