using System;
using System.Collections.Generic;
using System.Text;

namespace TPP.ObjectOrientation.InheritancePolymorphism {

    /// <summary>
    /// Person is compared by age
    /// </summary>
    class Person : IComparable {
        private String firstName, surname;
        public String FirstName {
            get { return firstName; }
        }
        public String Surname {
            get { return surname; }
        }

        private byte age;
        public byte Age {
            get { return age; }
        }

        /// <summary>
        /// Compare method
        /// </summary>
        /// <param name="c">The object to be compared</param>
        /// <returns>A negative number if this is lower than c;
        /// zero if they are the same; 
        /// a positive number if this is greater than c.</returns>
        public int Compare(IComparable c) {
            Person p = (Person)c;
            return this.Age - p.Age;
        }

        public override String ToString() {
            return firstName + " " + Surname + ", " + Age + " years old";
        }

        public void Birthday() {
            age++;
        }

        public Person(String firstName, String surname, byte age) {
            this.firstName = firstName;
            this.surname = surname;
            this.age = age;
        }
    }
}
