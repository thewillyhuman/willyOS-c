using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TPP.Functional.Delegates {

    class Program {

        static void Main() {
            const int a = 2, b = 1;
            // * Anonymous delegates (methods)
            Func<int, int, int> binaryOperation = delegate(int p1, int p2) { return p1 + p2; };
            Console.WriteLine("Addition: {0}", binaryOperation(a, b));
            binaryOperation = delegate(int p1, int p2) { return p1 - p2; };
            Console.WriteLine("Subtraction: {0}", binaryOperation(a, b));

            Func<int, int> twice = delegate(int n) { return n + n; };
            Func<Func<int, int>, int, int> twiceTwice = delegate(Func<int, int> f, int n) { return f(f(n)); };
            Console.WriteLine("Twice twice: {0}", twiceTwice(twice, 3));

            // In just one statement
            Console.WriteLine("Twice twice in just one statement: {0}",
                ((Func<Func<int, int>, int, int>) // cast
                        (delegate(Func<int, int> f, int n) { return f(f(n)); }) // twiceTwice
                        ) // end of cast
                ( // the twiceTwice delegate is invoked
                delegate(int n) { return n + n; } , // first parameter (Funct<int,int>)
                3 // second parameter (int)
                ) // end of invocation
            );


            Predicate<int> isEven = delegate(int n) { return n%2==0; };
            Action<string> show;
            if (isEven(a))
                show = delegate(string str) {
                    ConsoleColor color = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(str);
                    Console.ForegroundColor = color;
                };
            else
                show = Console.WriteLine;
            show("Hello world!");

            Person[] people = PersonPrintout.CreatePeopleRandomly();
            Person[] beyond18 = Array.FindAll(people, delegate(Person p) { return p.Age >= 18; });
            beyond18.ForEach(delegate(Person p) { Console.WriteLine(p); });
        }


    }

}
