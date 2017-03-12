using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TPP.Functional.Closures {

    /// <summary>
    /// This class creates a closure
    /// </summary>
    static class CounterClosure {

        /// <summary>
        /// This function returns a closure
        /// </summary>
        /// <returns>The closure (function with state)</returns>
        internal static Func<int> ReturnCounter() {
            int counter = 0;
            // * The closure accesses the counter variable, incrementing its value each time
            //   the closure is invoked.
            // * This variable implies a private state of the function returned, 
            //   as the objects in object orientation
            return () => ++counter;
        }

    }
}
