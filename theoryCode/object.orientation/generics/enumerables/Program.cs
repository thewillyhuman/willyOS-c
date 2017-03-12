using System;
using System.Collections.Generic;
using System.IO;

namespace TPP.ObjectOrientation.Generics {

    class Program {

        static public void ShowWithForEach<T>(IEnumerable<T> enumerable,TextWriter output) {
            output.Write("[ ");
            foreach (T item in enumerable)
                output.Write("{0} ",item);
            output.WriteLine("]");
        }

        static public void ShowWithEnumerator<T>(IEnumerable<T> enumerable, TextWriter output) {
            IEnumerator<T> iterador = enumerable.GetEnumerator();
            output.Write("[ ");
            while (iterador.MoveNext())
                output.Write("{0} ", iterador.Current);
            output.WriteLine("]");
        }

        static public void Main() {
            string[] array = { "How", "are", "you", "doing", "?" };
            ShowWithForEach(array, Console.Out);
            ShowWithEnumerator(array, Console.Out);

            Fibonacci fibonacci = new Fibonacci(10);
            ShowWithForEach(fibonacci, Console.Out);
            ShowWithEnumerator(fibonacci, Console.Out);
        }
    }
}
