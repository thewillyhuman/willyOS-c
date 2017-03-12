
using System;

namespace TPP.ObjectOrientation.InheritancePolymorphism {

    /// <summary>
    /// Example use of IDisposable
    /// </summary>
    class Program {

        static void Main() {
            string line;

            using (File file1 = new File("input1.txt")) { // Shows "opening input1.txt"
                line = file1.ReadLine();   // Shows "reading line"
                file1.WriteLine(line);  // Shows "writing line"
            } // * Shows "closing file"
            Console.WriteLine();

            File file2 = new File("input2.txt"); // Shows "opening input2.txt"
            line = file2.ReadLine();      // Shows "reading line"
            file2.WriteLine(line);     // Shows "writing line"
            // If the application does not end abnormally (exception or assert),
            // it will eventually show "closing input2.txt", but we don't know when

            // If we want explicitly close the file, we can call Dispose
            file2.Dispose();
            Console.WriteLine();

            using (File file3 = new File("input3.txt")) { // Shows "opening input3.txt"
                line = file3.ReadLine(); // Shows "reading line"
                file3.WriteLine(line + line.Length/"".Length);  // Throws a DiviceByZero exception
            } // * Shows "closing input3.txt" (aún incluso se haya lanzado la excepción)

            Console.WriteLine("This is not shown in the console."); // Because an exception was thrown
        }

    }


}
