using System;
using System.Collections.Generic;
using System.Text;

namespace TPP.Functional.Delegates {

    class Program {

        static void Main() {
            const int a = 2, b = 1;

            // * Lambda expression, with explicit type declaration
            Func<int, int, int> operation = (int p1, int p2) => { return p1 + p2; };
            Console.WriteLine("Addition : {0}", operation(a, b));
            // * Lambda expression, with explicit type declaration
            // * In case it is a simple return, both the "return" word and { } can be omitted
            operation = (p1, p2) => p1 - p2;
            Console.WriteLine("Subtraction: {0}", operation(a, b));

            // * Let's use Predicate and Action
            // * With one single parameter, () can be omitted
            Predicate<int> isEven = n => n % 2 == 0;
            Action<string> show;
            if (isEven(a))
                show = (str)  => {
                    ConsoleColor color = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(str);
                    Console.ForegroundColor = color;
                };
            else
                show = Console.WriteLine;
            show("Hello world!");

            // * Higher-order function
            Func<Func<int, int>, int, int> applyTwice = (f, n) => f(f(n)); 
            Console.WriteLine("Double application of twice: {0}", applyTwice( n => n+n, 3));
            Console.WriteLine("Double of twice in a single statement: {0}", 
                        ( (Func<Func<int, int>, int, int>)  ((f, n) => f(f(n))) )                
                                (n => n + n, 3)
                        );

            
            Person[] people = PersonPrintout.CreatePeopleRandomly();
            // * A lambda function is passed as a paramter to a BCL method (FindAll)
            Person[] beyond18 = Array.FindAll(people, person => person.Age >= 18);
            // * The people array supports our ForEach method becase it is an extension method.
            // * A lambda function (action) is passed as a parameter
            beyond18.ForEach(person => Console.WriteLine(person));
        }


    }

}
