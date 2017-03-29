using System;
using System.Collections.Generic;
using Foundation.Concurrent;

namespace CoreServices {

	/// <summary>
	/// Core Services provided for prining.
	/// </summary>
	public class CSPrint {

		/// <summary>
		/// Print the specified separator, terminator and items.
		/// </summary>
		/// <returns>The print.</returns>
		/// <param name="separator">Separator.</param>
		/// <param name="terminator">Terminator.</param>
		/// <param name="items">Items.</param>
		/// <typeparam name="T">The 1st type parameter.</typeparam>
		public void print<T>(string separator = default(string), string terminator = default(string), params T[] items) {
			foreach(var col in items) {
				Console.Write(col + separator);
			}
			Console.WriteLine(terminator);
		}

		/// <summary>
		/// Print the specified items, separator and terminator.
		/// </summary>
		/// <returns>The print.</returns>
		/// <param name="items">Items.</param>
		/// <param name="separator">Separator.</param>
		/// <param name="terminator">Terminator.</param>
		/// <typeparam name="T">The 1st type parameter.</typeparam>
		public void print<T>(IEnumerable<T> items, string separator = default(string), string terminator = default(string)) {
			foreach(var col in items) {
				Console.Write(col + separator);
			}
			Console.WriteLine(terminator);
		}

		/// <summary>
		/// Print the specified separator and items.
		/// </summary>
		/// <returns>The print.</returns>
		/// <param name="separator">Separator.</param>
		/// <param name="items">Items.</param>
		/// <typeparam name="T">The 1st type parameter.</typeparam>
		public void print<T>(string separator = default(string), params T[] items) {
			foreach(var item in items) {
				Console.Write(item + separator);
			}
			Console.WriteLine();
		}
	}
}
