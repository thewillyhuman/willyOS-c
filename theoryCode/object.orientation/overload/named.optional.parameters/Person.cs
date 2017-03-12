using System;

namespace TPP.ObjectOrientation.Overload {

    public class Person {

        public string FirstName { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public string IDNumber { get; set; }

        public override string ToString() {
            return string.Format("{0} {1}, {2} years old, and IdNumber {3}.",
                this.FirstName, this.Surname, this.Age, this.IDNumber);

        }


    }

}
