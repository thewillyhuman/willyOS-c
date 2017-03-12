using System;

namespace TPP.ObjectOrientation.Generics {

    public class Person {

        public string FirstName { get; set; }
        public string Surname { get; set; }

        /// <summary>
        /// Age of the person.
        /// Let's suppose it is taken from a database, and that it can be nullable (in the DB).
        /// </summary>
        public int? Age { get; set; }

        public string IDNumber { get; set; }

        public override string ToString() {
            if (this.Age.HasValue)
                // * We show the age because it is defined
                return string.Format("{0} {1}, {2} years old and IDNumber {3}.",
                    this.FirstName, this.Surname, this.Age.Value, this.IDNumber);
            else
                // * No age is defined
                return string.Format("{0} {1}, IDNumber {2}.", this.FirstName, this.Surname, this.IDNumber);
        }


    }

}
