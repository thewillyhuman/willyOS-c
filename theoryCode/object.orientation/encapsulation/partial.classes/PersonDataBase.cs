using System;
namespace TPP.ObjectOrientation.Encapsulation {

    /// <summary>
    /// Partial classes demo.
    /// The following file is expected to be created by an ORM (Object-Relational Mapping)
    /// That is, by analyzing the database, the C# code is generated, controlling the
    /// CRUD (create, retrieve, update and delete) operations.
    /// The most important thing is to realize that, it this file is updated, the rest of the class
    /// in the other file stays the same. The result is that business rules are not erased.
    /// </summary>
    partial class Person {

        public string FirstName { get; set; }

        public string Surname { get; set; }

        public int Age { get; set; }

        public string IDNumber { get; set; }

        /// <summary>
        /// The method that is supposed to create an entry in the database, returning an object
        /// </summary>
        public static Person Create(string name, string surname, int age, string idNumber) {
            Console.WriteLine("Creating the object in the DB...");
            return new Person {
                FirstName = name,
                Surname = surname,
                Age = age,
                IDNumber = idNumber,
            };
        }

        /// <summary>
        /// Is supposed to search an object in the DB, returning it
        /// </summary>
        public static Person Retrieve(string DNI) {
            Console.WriteLine("Retrieving the object from the DB...");
            return null; 
        }

        /// <summary>
        /// Is supposed to update the object in the DB
        /// </summary>
        public void Update() {
            Console.WriteLine("Updating the object in the DB...");
        }

        /// <summary>
        /// Is supposed to delete the object in the DB
        /// </summary>
        public void Delete() {
            Console.WriteLine("Deleting the object in the DB...");
        }
    }
}