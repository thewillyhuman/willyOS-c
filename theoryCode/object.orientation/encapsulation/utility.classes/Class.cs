using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TPP.ObjectOrientation.Encapsulation {

    /// <summary>
    /// Static and instance constructor demo
    /// </summary>
    internal class Class {

        /// <summary>
        /// The same random value for all the objects of this class
        /// </summary>
        static private int randomValue;

        /// <summary>
        /// Instance method that returns the same value for all the objects in the class
        /// </summary>
        /// <returns></returns>
        internal int GetRandomValue() {
            return randomValue;
        }

        /// <summary>
        /// Class constructor.
        /// It is executed only once, when the class is loaded.
        /// </summary>
        static Class() {
            Console.WriteLine("The class (static) constructor is being executed.");
            randomValue = new Random().Next();
        }

        /// <summary>
        /// Instance constructor
        /// </summary>
        internal Class() {
            Console.WriteLine("The instance (non-static) constructor is executed.");
        }

    }

}
