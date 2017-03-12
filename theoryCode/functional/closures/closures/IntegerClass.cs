using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TPP.Functional.Closures {

    class IntegerClass {

        private int integer;

        internal int  Get() { 
            return this.integer; 
        }

        internal void Set(int value) {
            this.integer = value;
        }

        internal IntegerClass(int integer) {
            this.integer = integer;
        }


    }
}
