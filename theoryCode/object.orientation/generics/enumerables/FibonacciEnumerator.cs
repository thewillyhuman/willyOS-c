using System;
using System.Collections;
using System.Collections.Generic;

namespace TPP.ObjectOrientation.Generics {


    /// <summary>
    /// Class that implements a Fibonacci enumerator (iterator).
    /// </summary>
    internal class FibonacciEnumerator : IEnumerator<int> {
        /// <summary>
        /// Index is the position of the term in the sequence.
        /// FirstTerm and secondTerm store the two last terms.
        /// SecondTerm is the current term.
        /// </summary>
        int index, firstTerm, secondTerm;

        /// <summary>
        /// Maximum number of elements in this enumerator (iterator).
        /// </summary>
        int elements;

        public FibonacciEnumerator(int elements) {
            this.elements = elements;
            Reset();
        }

        /// <summary>
        /// The current term (generic version)
        /// </summary>
        int IEnumerator<int>.Current {
            get { return secondTerm; }
        }

        /// <summary>
        /// The current term (polymorphic method)
        /// </summary>
        object IEnumerator.Current {
            get { return secondTerm; }
        }

        /// <summary>
        /// Increments the enumerator (iterator) going to the following term
        /// </summary>
        /// <returns>True if the increment was successful; false if the end was reached</returns>
        public bool MoveNext() {
            if (index >= this.elements)
                return false;
            if (++index > 2) {
                int temp = secondTerm;
                secondTerm += firstTerm;
                firstTerm = temp;
            }
            return true;
        }

        /// <summary>
        /// Resets the enumerator (iterator), setting it to the begining of the sequence
        /// </summary>
        public void Reset() {
            index = 0;
            firstTerm = secondTerm = 1;
        }

        /// <summary>
        /// This method is called when the object is destroyed.
        /// It is used to free its resources (nothing in this case).
        /// It must be implemented, though, because it is part of the IEnumerator.
        /// </summary>
        public void Dispose() {
        }

    } // FibonacciEnumerator

} // namespace
