using System;
using System.Collections.Generic;

namespace willyOS {

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
		/// <typeparam name="TOutput">The 1st type parameter.</typeparam>
		public static TOutput Find<TOutput>(Predicate<TOutput> f, IEnumerable<TOutput> e) {
			foreach (var el in e) {
				if (f(el))
					return el;
			}
			throw new Exception();
		}

		/// <summary>
		/// Filter the specified f and e.
		/// </summary>
		/// <returns>The filter.</returns>
		/// <param name="f">F.</param>
		/// <param name="e">E.</param>
		/// <typeparam name="TOutput">The 1st type parameter.</typeparam>
		public static IEnumerable<TOutput> Filter<TOutput>(Predicate<TOutput> f, IEnumerable<TOutput> e) {
			var temp = new NSList<TOutput>();

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
