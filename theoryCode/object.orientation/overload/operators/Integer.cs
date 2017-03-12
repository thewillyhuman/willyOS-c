using System;

namespace TPP.ObjectOrientation.Overload {

    /// <summary>
    /// Operator overload example.
    /// Use breakpoints to see how the code is executed.
    /// </summary>
    class Integer {
        private int integer;

        public Integer(int n) { integer = n; }

        public int Value {
            get { return integer; }
            set { integer = value; }
        }

        /// <summary>
        /// Overload of the + operator.
        /// += is automatically generated.
        /// The method must be static.
        /// </summary>
        /// <param name="e1">First operand</param>
        /// <param name="e2">Second operand</param>
        /// <returns>Resulting summation</returns>
        public static Integer operator +(Integer e1, Integer e2) {
            return new Integer(e1.Value + e2.Value);
        }

        /// <summary>
        /// Implementation of the prefix ++.
        /// The postfix ++ is automatically generated.
        /// </summary>
        /// <param name="e">The integet to be incremented.</param>
        /// <returns>The integer, after the incrementation.</returns>
        public static Integer operator++(Integer e) {
            return new Integer(e.Value + 1);
        }

        /// <summary>
        /// Implicit conversion from int to Integer (promotion).
        /// Explicit conversion is implemented using "explicit" instead of "implicit".
        /// </summary>
        /// <param name="n">int to be converted to Integer</param>
        /// <returns>The Integer</returns>
        public static implicit operator Integer(int n) {
            return new Integer(n);
        }

        /// <summary>
        /// Implementation of an indexer to overload the [] operator.
        /// This operator is widely used in collections.
        /// In this example, we simply return the index (silly) for get,
        /// and assigns the rvalue in the set.
        /// </summary>
        public Integer this[int indice] {
            get { return new Integer(indice); }
            set { integer = value.Value; }
        }

        public override String ToString() { return "" + integer; }
    }

}