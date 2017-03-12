using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace TPP.ObjectOrientation.Generics {

    class Program {

        static void Main() {
            // Creates a vector
            const uint NUMBER_ELEMENTS = 50;
            int[] vector = new int[NUMBER_ELEMENTS];

            // Random values are assigned
            Random random = new Random();
            for (int i = 0; i < vector.Length; i++)
                vector[i] = random.Next(Int32.MinValue, Int32.MaxValue);

            // We sort it (Int32 implements Comparable<Int32>)
            Algorithms.Sort(vector);

            // We check that the vector is sorted
            for (int i = 0; i < vector.Length - 1; i++)
                Debug.Assert(vector[i] <= vector[i + 1]);
        }

    }
}
