using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TPP.Functional.Delegates {

    public class Person {
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
        /// Age comparison
        /// </summary>
        /// <returns>A negative number if person1.Age is lower than person2.Age.
        /// Zero if person1.Age == person2.Age.
        /// A positive number if person1.Age is greater than person2.Age.</returns>
        public static int CompareByAge(Person person1, Person person2) {
            return person1.Age - person2.Age;
        }

        /// <summary>
        /// Surname + FirstName comparsion.
        /// </summary>
        /// <returns>A negative number if person1 is lower than person2.
        /// Zero if person1 and person2 have the same name and surname.
        /// A positive numbre if person1 is greater than person2.</returns>
        public static int CompareBySurnameAndName(Person person1, Person person2) {
            if (!person1.Surname.Equals(person2.Surname))
                return person1.Surname.CompareTo(person2.Surname);
            return person1.FirstName.CompareTo(person2.FirstName);
        }

        public override String ToString() {
            return firstName + " " + Surname + ", " + Age + " years old";
        }

        public void BirthDay() {
            age++;
        }
        
        public Person(String firstName, String surname, byte age) {
            this.firstName = firstName;
            this.surname = surname;
            this.age = age;
        }

    }

}
