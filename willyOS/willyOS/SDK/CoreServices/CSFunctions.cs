using System;
using System.Collections.Generic;
using Foundation;

namespace CoreServices {

	/// <summary>
	/// Core Service Functions.
	/// </summary>
	public static class CSFunctions {

		/// <summary>
		/// Find the specified f and e.
		/// </summary>
		/// <returns>The find.</returns>
		/// <param name="f">F.</param>
		/// <param name="e">E.</param>
		/// <typeparam name="T">The 1st type parameter.</typeparam>
		public static T Find<T>(this IEnumerable<T> e, Predicate<T> f) {
			foreach (var el in e) {
				if (f(el))
					return el;
			}
			return default(T);
		}

		/// <summary>
		/// Filter the specified f and e.
		/// </summary>
		/// <returns>The filter.</returns>
		/// <param name="f">F.</param>
		/// <param name="e">E.</param>
		/// <typeparam name="T">The 1st type parameter.</typeparam>
		public static IEnumerable<T> Filter<T>(this IEnumerable<T> e, Predicate<T> f) {
			var temp = new NSList<T>();
			foreach (var el in e) {
				if (f(el)) {
					temp.Add(el);
				}
			}
			return temp;
		}

		/// <summary>
		/// Reduce the specified f, en and seed.
		/// </summary>
		/// <returns>The reduce.</returns>
		/// <param name="f">F.</param>
		/// <param name="en">En.</param>
		/// <param name="seed">Seed.</param>
		/// <typeparam name="TInput">The 1st type parameter.</typeparam>
		/// <typeparam name="TResult">The 2nd type parameter.</typeparam>
		public static TResult Reduce<TInput, TResult>(this IEnumerable<TInput> en, Func<TResult, TInput, TResult> f, TResult seed = default(TResult)) {
			TResult temp = seed;
			foreach (var el in en) {
				temp = f(temp, el);
			}
			return temp;
		}

		/// <summary>
		/// Inverse the specified en.
		/// </summary>
		/// <returns>The inverse.</returns>
		/// <param name="list">En.</param>
		/// <typeparam name="T">The 1st type parameter.</typeparam>
		public static IEnumerable<T> Inverse<T>(this IList<T> list) {
			T[] inversed = new T[list.Count];
			Console.WriteLine("-- Fast version of the inverse executing --");
			for (int i = 0; i < list.Count / 2; i++) {
				inversed[i] = list[list.Count - i - 1];
				inversed[list.Count - i - 1] = list[i];
				if (list.Count % 2 != 0) {
					inversed[list.Count / 2] = list[list.Count / 2];
				}
			}
			return inversed;
		}

		/// <summary>
		/// Inverse the specified en.
		/// </summary>
		/// <returns>The inverse.</returns>
		/// <param name="en">En.</param>
		/// <typeparam name="T">The 1st type parameter.</typeparam>
		public static IEnumerable<T> Inverse<T>(this IEnumerable<T> en) {
			var inversed = new NSList<T>();
			var stack = new Stack<T>();

			Console.WriteLine("-- Slow version of the inverse executing --");

			foreach (var el in en) {
				stack.Push(el);
			}

			foreach (var el in stack) {
				inversed.Add(el);
			}

			return inversed;
		}

		/// <summary>
		/// Map the specified en and f.
		/// </summary>
		/// <returns>The map.</returns>
		/// <param name="en">En.</param>
		/// <param name="f">F.</param>
		/// <typeparam name="T1">The 1st type parameter.</typeparam>
		/// <typeparam name="T2">The 2nd type parameter.</typeparam>
		public static IEnumerable<T2> Map<T1, T2>(this IEnumerable<T1> en, Func<T1, T2> f) {
			var temp = new NSList<T2>();
			foreach (var e in en) {
				temp.Add(f(e));
			}
			return temp;
		}

		/// <summary>
		/// Fors the each.
		/// </summary>
		/// <param name="e">E.</param>
		/// <param name="a">The alpha component.</param>
		/// <typeparam name="T">The 1st type parameter.</typeparam>
		public static void ForEach<T>(this IEnumerable<T> e, Action<T> a) {
			foreach (var el in e) {
				a(el);
			}
		}
	}
}
