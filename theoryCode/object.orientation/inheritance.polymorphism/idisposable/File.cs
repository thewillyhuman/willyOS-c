
using System;

namespace TPP.ObjectOrientation.InheritancePolymorphism {

    /// <summary>
    /// An example class that is supposed to control text files.
    /// It only prints messages in the console to show the behavior of IDisposable and using () { ... }
    /// </summary>
    class File: IDisposable {

        private string fileName;

        /// <summary>
        /// To know whether the file is open or closed
        /// </summary>
        private bool isOpen;

        public File(string fileName) {
            this.fileName = fileName;
            this.isOpen = true;
            Console.WriteLine("Opening the {0} file.", fileName);
        }

        public void Dispose() {
            if (this.isOpen) {
                this.isOpen = false;
                Console.WriteLine("Closing the {0} file.", fileName);
            }
        }

        ~File() {
            this.Dispose();
        }

        /// <summary>
        /// This method simulates writing a text line in a file.
        /// </summary>
        public void WriteLine(string line) {
            Console.WriteLine("Writing the line \"{0}\" in the {1} file.", line, this.fileName);
        }

        /// <summary>
        /// Method that simulates reading a text line from a file.
        /// </summary>
        public string ReadLine() {
            Console.WriteLine("Reading a line from the {0} file.", this.fileName);
            return "Text line";
        }

    }


}
