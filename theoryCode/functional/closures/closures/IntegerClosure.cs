using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TPP.Functional.Closures {

    /// <summary>
    /// Class that creates two closures 
    /// </summary>
    static class IntegerClosure {

        /// <summary>
        /// This function returns two closures, simulating the constructor of an object
        /// with a private state (integer) and two public methods (get and set)
        /// </summary>
        internal static void Constructor(int initialValue, out Func<int> get, out Action<int> set) {
            // * Field
            int integer = initialValue;
            // * Two closures representing two methods (integer is the private field)
            get = () => integer;
            set = (value) => integer = value;
        }

        /// <summary>
        /// This function is similar to the one above, but returns an object with two 
        /// properties; each one is a clause
        /// </summary>
        internal static Integer Constructor(int initialValue) {
            // * Field
            int integer = initialValue;
            // * Two closures representing two methods (integer is the private field)
            Func<int> get = () => integer;
            Action<int> set = (valor) => integer = valor;
            // * A record with the two closures are returned
            return new Integer { Get = get, Set = set };
        }

    }

    /// <summary>
    /// The Integer instances hold two closures, but no state is stored by the object
    /// (apart from the closures' state)
    /// </summary>
    class Integer {
        public Func<int> Get { get; set; }
        public Action<int> Set { get; set; }
    }

}
