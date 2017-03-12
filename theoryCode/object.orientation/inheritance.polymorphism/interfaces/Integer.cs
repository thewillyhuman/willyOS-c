using System;


namespace TPP.ObjectOrientation.InheritancePolymorphism {

    class Integer : IComparable {
        /// <summary>
        /// Compare method
        /// </summary>
        /// <param name="c">The object to be compared</param>
        /// <returns>A negative number if this is lower than c;
        /// zero if they are the same; 
        /// a positive number if this is greater than c.</returns>
        public int Compare(IComparable c) {
            Integer e=c as Integer;
            if (e == null)
                throw new ArgumentException("The prameter is not an integer");
            return this.Value - e.Value;
        }

        public override string ToString() {
            return m_integer.ToString();
        }

        private int m_integer;

        public Integer(int n) { m_integer = n; }

        public int Value {
            get { return m_integer; }
            set { m_integer = value; }
        }

    }

}
