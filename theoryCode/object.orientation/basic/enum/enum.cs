using System;

namespace TPP.ObjectOrientation.Basic {
    /// <summary>
    /// Color enumeration
    /// </summary>
    internal enum Colors {
        blue, green=3, red, yellow
    }

    /// <summary>
    /// A simple example use of the Colors enumeration
    /// </summary>
    class Enumeration {
        static void Main(string[] args) {
            Colors color;
            color = Colors.blue;
            Console.WriteLine(color); // * blue
            color = (Colors)3;
            Console.WriteLine(color); // * green
        }
    }
}
