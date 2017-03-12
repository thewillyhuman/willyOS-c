using System;
using System.Collections;
using System.Collections.Generic;

namespace TPP.ObjectOrientation.Encapsulation {

    /// <summary>
    /// Multi dimensional arrays demo
    /// </summary>
    class MultiDimensionalArrays {

        static internal void Run() {
            // * Linear multidimensional arrays 
   	        string[,] vector=new string[3,4];
            // * Length returns the multiplication (12)
            System.Console.WriteLine("Number of elements: {0}.", vector.Length);
            // * Rank = dimensions
            System.Console.WriteLine("Numer of dimensions: {0}.", vector.Rank);

            // * To know the size of each dimension, GetLength must be used
            for (int i = 0; i < vector.GetLength(0); i++) 
                for (int j = 0; j < vector.GetLength(1); j++)
                    vector[i,j]="("+(i+1)+","+(j+1)+")";
            // * They can be iterated as if they were one dimension
            foreach (string s in vector)
                Console.Write(s + '\t');
            Console.WriteLine();

            // * Array of arrays
	    	// * Creation of multidimentional arrays
    		int[][] table=new int[10][]; // * Multiplication table
            for (int i=0;i<table.Length;i++)
                table[i]=new int[10];
            for (int i=0;i<table.Length;i++)
			    for (int j=0;j<table[i].Length;j++)
				    table[i][j]=(i+1)*(j+1);

    		// * A triangular matrix
	    	int[][] triangular=new int[10][];
		    for (int i=0;i<triangular.Length;i++)
                triangular[i] = new int[triangular.Length-i];

            // * Visualization
		    Console.WriteLine("Table:");
            Show(table);
		    Console.WriteLine("Triangular matrix:");
            Show(triangular);
        }

        static void Show(int[][] vector) {
                    foreach (int[] v in vector) {
                        foreach (int i in v)
                            Console.Write(i + " ");
                        Console.WriteLine();
                    }
                }
    }
}
