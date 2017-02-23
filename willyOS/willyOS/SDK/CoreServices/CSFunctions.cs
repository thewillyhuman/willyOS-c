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
		public static T Find<T>(Predicate<T> f, IEnumerable<T> e) {
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
		public static IEnumerable<T> Filter<T>(Predicate<T> f, IEnumerable<T> e) {
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
		public static TResult Reduce<TInput, TResult>(Func<TResult, TInput, TResult> f, IEnumerable<TInput> en, TResult seed = default(TResult)) {
			TResult temp = seed;
			foreach (var el in en) {
				temp = f(temp, el);
			}
			return temp;
		}
	}
}
