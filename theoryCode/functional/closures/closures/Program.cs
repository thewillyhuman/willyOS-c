using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TPP.Functional.Closures {

    class Program {

        /// <summary>
        /// High-order function that simulates a While control structure
        /// </summary>
        /// <param name="condition">Function to be evaluated at the begining of each iteration,
        /// know whether the loop has finished or not</param>
        /// <param name="body">A function (action) modeling the loop body</param>
        static void WhileLoop(Func<bool> condition, Action body) {
            if (condition()) {
                body();
                WhileLoop(condition, body); // recursion to iterate
            }
        }


        static void Main() {
            // * A very simple closure
            int value = 1;
            // * In the following function, value is a free variable,
            //   but it is bound to the value local variable
            Func<int> doubleValue = () => value * 2;
            Console.WriteLine("Two times {0} is {1}.", value, doubleValue());
            value = 7;
            Console.WriteLine("Two times {0} is {1}.", value, doubleValue());


            // * Modeling loops by means of closures
            int i = 0; // The i variable is used in both closures (condition and body)
            WhileLoop(() => i < 10, () => { Console.Write(i+" "); i++; });
            Console.WriteLine();

            Counter();
            Integer();
        }

        /// <summary>
        /// It shows how to represent the private states with closures
        /// </summary>
        static void Counter() {
            const int iterations = 10;
            // * Object oriented version
            CounterClass anObject = new CounterClass();
            for (int i = 0; i < iterations; i++)
                anObject.Increment();
            Console.WriteLine("Value of the counter object: {0}", anObject.Value);

            // * Functional version
            var closure = CounterClosure.ReturnCounter();
            int value = 0;
            for (int i = 0; i < iterations; i++)
                value = closure();
            Console.WriteLine("Last value returned by the closure: {0}", value);
        }

        /// <summary>
        /// Shows how to represent an object with multiple methods by means of closures
        /// </summary>
        static void Integer() {
            // * Object oriented version
            IntegerClass anObject = new IntegerClass(1);
            Console.WriteLine("Object value: {0}", anObject.Get());
            anObject.Set(11);
            Console.WriteLine("Object value: {0}", anObject.Get());

            // * Functional version returning two closures
            Func<int> objGet;
            Action<int> objSet;
            IntegerClosure.Constructor(2, out objGet, out objSet);
            Console.WriteLine("Private value of the closure: {0}", objGet());
            objSet(22);
            Console.WriteLine("Private value of the closure: {0}", objGet());

            // * Functional version returning a pair of closures
            Integer obj = IntegerClosure.Constructor(3);
            Console.WriteLine("Private value of the closure: {0}", obj.Get());
            obj.Set(33);
            Console.WriteLine("Private value of the closure: {0}", obj.Get());
        }

    }
}
