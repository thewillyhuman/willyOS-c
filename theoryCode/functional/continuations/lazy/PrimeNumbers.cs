using System;
using System.Linq;
using System.Collections.Generic;

namespace TPP.Functional.Continuations {

    static internal class PrimeNumbers {

        /// <summary>
        /// Computes whether a number is prime or not
        /// </summary>
        private static bool IsPrime(int n) {
            bool isPrime= true;
            for (int i = 2; i <= Math.Sqrt(n) && isPrime; i++)
                isPrime = n % i != 0;
            return isPrime;
        }


        /// <summary>
        /// Returns a collection of "numberOfNumbers" prime numbers after the from-th prime number
        /// </summary>
        static internal IEnumerable<int> EagerPrimeNumbers(int from, int numberOfNumbers) {
            int n = 1, counter = 0;
            while (counter < from) {
                if (IsPrime(n))
                    counter++;
                n++;
            }
            IList<int> result = new List<int>();
            counter = 0;
            while (counter < numberOfNumbers) {
                if (IsPrime(n)) {
                    counter++;
                    result.Add(n);
                }
                n++;
            }
            return result;
        }


        /// <summary>
        /// Returns an infinite sequence of prime numbers, implemented the lazy way
        /// </summary>
        static private IEnumerable<int> LazyPrimeNumbersGenerator() {
            int n = 1;
            while (true) {
                if (IsPrime(n))
                    yield return n;
                n++;
            }
        }

        /// <summary>
        /// Returns a sequence of "numberOfNumbers" prime numbers after the from-th prime number,
        /// using the lazy prime number generator
        /// </summary>
        static internal IEnumerable<int> LazyPrimeNumbers(int from, int numberOfNumbers) {
            return LazyPrimeNumbersGenerator().Skip(from).Take(numberOfNumbers);
        }


        /// <summary>
        /// Functional version of performing an action over all the elements in a collection (iteration).
        /// Implemented as an extension method of IEnumerable<T>
        /// </summary>
        static internal void ForEach<T>(this IEnumerable<T> enumerable, Action<T> action, int? maximumNumberOfElements=null) {
            int counter = 0;
            foreach (T item in enumerable) {
                if (maximumNumberOfElements.HasValue && maximumNumberOfElements.Value < counter++)
                    break;
                action(item);
            }
        }

    }
}
