using System;

namespace TPP.ObjectOrientation.Encapsulation {

    /// <summary>
    /// Properties demo
    /// </summary>
    public class Program {

        static void Main() {
            Circumference circumference = new Circumference(0, 0, 0);
            System.Console.WriteLine(circumference);
            System.Console.WriteLine(circumference.X);
            circumference.Radius = 10;
            circumference.Move(-10, -20);
            System.Console.WriteLine(circumference);

            // * Different alternatives to build Person objects
            Person maria = new Person {
                FirstName = "María",
                Surname = "Pérez",
                Age = 43,
                IDNumber = "23746887-F"
            };
            Person juan = new Person { Surname = "García", Age = 10, FirstName = "Juan" };
            Console.WriteLine(maria);
            Console.WriteLine(juan);
        }

    }
}