using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace TPP.ObjectOrientation.Exceptions {

    /// <summary>
    /// Example of resource management (release) in algorithms that can throw exceptions.
    /// </summary>
    class Program {


        public static void Main() {
            new WrongManagement().Run();
            new CorrectManagement().Run();
        }


    }
}
