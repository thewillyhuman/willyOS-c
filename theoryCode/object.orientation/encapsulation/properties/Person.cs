namespace TPP.ObjectOrientation.Encapsulation {

    /// <summary>
    /// Properties demo
    /// </summary>
    public class Person {

        public string FirstName { get; set; }

        public string Surname { get; set; }

        public int Age { get; set; }

        public string IDNumber { get; set; }

        public override string ToString() {
            if (this.IDNumber == null)
                return string.Format("{0} {1}, {2} years old.", this.FirstName, this.Surname, this.Age, this.IDNumber);
            return string.Format("{0} {1}, {2} years old, and {3} IdNumber.",
                this.FirstName, this.Surname, this.Age, this.IDNumber);

        }

    }
}