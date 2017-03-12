using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TPP.Functional.Closures {

    class CounterClass {

        private int number;

        internal int Value {
            get { return this.number; }
        }

        internal CounterClass() {
            this.number = 0;
        }

        internal void Increment() {
            this.number++;
        }

    }
}
