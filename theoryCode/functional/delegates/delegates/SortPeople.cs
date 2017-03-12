
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TPP.Functional.Delegates {


    public static class Algorithms {

        /// <summary>
        /// The Comparison delegate is defined.
        /// It receives two people and returns an integer denoting the result of the comparison.
        /// <returns>A negative if person1 is lower than person2.
        /// Zero if person1 and person2 are equal.
        /// A positive number if person1 is greater thann person2.</returns>
        public delegate int Comparison(Person person1, Person person2);

        static public void SortPeople(Person[] vector, Comparison comparison)  {
            for (int i=0; i<vector.Length; i++)
                for (int j = vector.Length-1; j > i; j--)
                    if (comparison(vector[i], vector[j]) >0) {
                        Person temp = vector[i];
                        vector[i] = vector[j];
                        vector[j] = temp;
                    }
        }

    }
}
