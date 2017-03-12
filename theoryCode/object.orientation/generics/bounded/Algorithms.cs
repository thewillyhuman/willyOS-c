
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TPP.ObjectOrientation.Generics {


    public static class Algorithms {

        static public void Sort<T>(T[] vector) where T: IComparable<T> {
            for (int i=0; i<vector.Length; i++)
                for (int j = vector.Length-1; j > i; j--)
                    if (vector[i].CompareTo(vector[j]) >0) {
                        T aux = vector[i];
                        vector[i] = vector[j];
                        vector[j] = aux;
                    }
        }

    }
}
