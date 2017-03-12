using System;
using System.Collections.Generic;

namespace TPP.Functional.HigherOrder {

    public class Person {

        private String firstName, surname;

        public String FirstName {
            get { return firstName; }
        }
        public String Surname {
            get { return surname; }
        }

        private int age;

        public int Age {
            get { return age; }
        }

        private string idNumber;

        public string IDNumber {
            get { return this.idNumber; }
        }

        public override String ToString() {
            return firstName + " " + Surname + ", " + Age + " years old, id number " + this.IDNumber;
        }

        public Person Birthday() {
            age++;
            return this;
        }
        
        public Person(String firstName, String surname, byte age, string idNumber) {
            this.firstName = firstName;
            this.surname = surname;
            this.age = age;
            this.idNumber = idNumber;
        }

    }

}
