using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace TPP.ObjectOrientation.Exceptions {

    /// <summary>
    /// This class does not handle the resources properly.
    /// Files are not closed and, thus, the "hello" string is not written in the file.
    /// </summary>
    class WrongManagement {

        private void Process(TextWriter file) {
            // * Method that process a file...
            file.Write("hello"); // no flush
            //   ... an exception can be thrown
            throw new Exception();
        }

        private void Resources(String fileName) {
            TextWriter fichero = new StreamWriter(fileName);
            // * The file is processed
            Process(fichero);
            fichero.Close();
        }

        public void Run() {
            try {
                Resources("wrongManagement.txt");
            }
            catch (Exception) {
                Console.Error.WriteLine("Exception handled.");
            }
        }


    }
}
