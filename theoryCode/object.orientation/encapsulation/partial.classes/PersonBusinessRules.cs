namespace TPP.ObjectOrientation.Encapsulation {

    /// <summary>
    /// Partial classes demo.
    /// In this part of the class, the business rules of the Person class are placed.
    /// The benefit is that, if the PersonDataBase.cs file is updated (e.g., by a ORM)
    /// the business rules will not be destroyed
    /// </summary>
    partial class Person {

        /// <summary>
        /// A simple business rule
        /// </summary>
        public void Birthday() {
            this.Age++;
        }

        public override string ToString() {
            return string.Format("{0} {1}, {2} years old; IDNumber {3}.",
                this.FirstName, this.Surname, this.Age, this.IDNumber);

        }

    }
}