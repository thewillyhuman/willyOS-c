using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TPP.Functional.Delegates {

    class Program {

        /// <summary>
        /// Delegate that receives two integers and returns another integer
        /// </summary>
        private delegate int BinaryOperation(int a, int b);

        private static int Add(int a, int b) {
            return a + b;
        }

        private static int Sub(int a, int b) {
            return a - b;
        }

        /// <summary>
        /// Higher-order function that receives a function and applies (invokes) it
        /// twice to the second argument
        /// </summary>
        private static int DoubleApplication(Func<int,int> function, int integer) {
            return function(function(integer));
        }

        private static int Twice(int integer) {
            return integer + integer;
        }

        private static bool IsEven(int a) {
            return a % 2 == 0;
        }

        private static void ShowInRed(string str) {
            ConsoleColor color = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(str);
            Console.ForegroundColor = color;
        }

        private static bool PersonAge18OrBeyond(Person person) {
            return person.Age >= 18;
        }

        static void Main() {
            const int a = 2, b = 1;

            // * A delegate variable using a user defined type 
            BinaryOperation operation = Program.Add;
            Console.WriteLine("Addition: {0}", operation(a, b));
            operation = Program.Sub;
            Console.WriteLine("Subtraction: {0}", operation(a, b));

            // * A delegate variable using a predefined type 
            Func<int, int, int> function = Program.Add;
            Console.WriteLine("Addition: {0}", function(a, b));
            function = Program.Sub;
            Console.WriteLine("Subtaction: {0}", function(a, b));

            // * The DoubleApplication higher-order function is called,
            //   passing another Twice (Func<int,int>) funcion as a parameter
            Console.WriteLine("Double application of twice: {0}", DoubleApplication(Twice, 3));

            // * Two more variables of predefined delegate types
            Predicate<int> isEven = Program.IsEven; 
            Action<string> show;
            if (isEven(a))
                show = Program.ShowInRed;
            else
                show = Console.WriteLine;
            show("Hello world!");

            // * A BCL higher-order method (FindAll) is called, 
            //   passing a predicate delegate as a parameter
            Person[] people = PersonPrintout.CreatePeopleRandomly();
            Person[] beyond18 = Array.FindAll(people, Program.PersonAge18OrBeyond);
            beyond18.ForEach(Console.WriteLine);
        }


    }

}
