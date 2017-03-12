using System;

namespace TPP.Functional.Delegates {

    /// <summary>
    /// A class that will be registered to the Button's click event
    /// </summary>
    class Integer {
        private int integer;

        public Integer(int n) {
            this.integer = n;
        }

        public int Value {
            get { return integer; }
            set { integer = value; }
        }

        public override string ToString() {
            return integer.ToString();
        }

        /// <summary>
        /// The method that will be called when the event is triggered.
        /// </summary>
        public void Show() {
            Console.WriteLine(this);
        }
    }


}
