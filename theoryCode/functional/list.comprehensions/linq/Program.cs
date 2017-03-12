using System;
using System.Collections.Generic;
using System.Linq;

namespace TPP.Functional.ListComprehensions {

    class Program {

        public static IEnumerable<uint> NaturalNumber(uint max) {
            uint n = 0;
            while (n<max)
                yield return n++;
        }

        public static IEnumerable<uint> WithoutSyntaxSugar() {
            return NaturalNumber(10)
                .Where(x => x % 2 == 0)
                .Select(x => 2 * x);
        }

        public static IEnumerable<uint> WithSyntaxSugar() {
            return 
                from x in NaturalNumber(10) 
                where x % 2 == 0 
                select 2 * x;
        }

        static void Show<T>(IEnumerable<T> collection) {
            int i = 0;
            Console.Write("[");
            foreach (T item in collection) {
                Console.Write(item);
                if (++i < collection.Count())
                    Console.Write(", ");
            }
            Console.WriteLine("]");
        }

        static void Main(string[] args) {
            Show(WithoutSyntaxSugar());
            Show(WithSyntaxSugar());
        }

    }
}
