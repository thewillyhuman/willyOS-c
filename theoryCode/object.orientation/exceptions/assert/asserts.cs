/* 
To see how conditional compilation and assert (dis)abling work, 
change the project type from “Debug” to “Release”
This change can be performed in the tool bar, near to the “play” button.
 */

using System;
using System.Diagnostics;

namespace TPP.ObjectOrientation.Exceptions {

    class Asserts {
        static void Main(string[] args) {
#if DEBUG
            Console.WriteLine("Debug mode");
#else
            Console.WriteLine("Release mode");
#endif

            Debug.Assert(false, "Optional error message");
        }
    }
}
