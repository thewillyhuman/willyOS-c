using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace TPP.ObjectOrientation.Exceptions {

    /// <summary>
    /// This class manages the resources correctly
    /// </summary>
    class CorrectManagement {

        private void Process(TextWriter file) {
            // * Method that process a file...
            file.Write("hello"); // no flush
            //   ... an exception can be thrown
            throw new Exception();
        }

        /// <summary>
        /// Correct management, but the code is not maintainable
        /// </summary>
        private void NonMaintainable(String fileName) {
            TextWriter file = new StreamWriter(fileName);
            // * The file is processed
            try {
                Process(file);
            }
            catch (Exception e) {
        		file.Close();
		        throw e;  // * We don't know how to handle it
            }
            // * file.Close() is repeated => no maintainable
            file.Close();
        }

        private void Maintainable(String fileName) {
            TextWriter file = new StreamWriter(fileName);
            // * The file is processed
            try {
                Process(file);
            }
            finally {
                // Resources are cleaned up only here
                file.Close();
            }
        }

        public void Run() {
            try {
                NonMaintainable("correctManagement1.txt");
            }
            catch (Exception) {
                Console.Error.WriteLine("Exception handled.");
            }

            try {
                Maintainable("correctManagement2.txt");
            }
            catch (Exception) {
                Console.Error.WriteLine("Exception handled.");
            }
        }


    }
}
