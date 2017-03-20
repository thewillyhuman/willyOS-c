using System;
namespace examples.genetics {

	/// <summary>
	/// Search function.
	/// </summary>
	public class SearchFunction {

		/// <summary>
		/// Search the specified array.
		/// </summary>
		/// <returns>The search.</returns>
		/// <param name="array">Array.</param>
		public static double Search(char[] array) {

			var chain = new string(array);
			var result = 0;

			Console.WriteLine(chain);

			if(chain.Contains(new AAAGene().name)) {
				result++;
				Console.WriteLine("Find AAA");
			} else if(chain.Contains(new GTGene().name)) {
				result++;
				Console.WriteLine("Find GT");
			} else if(chain.Contains(new ABGene().name)) {
				result++;
				Console.WriteLine("Find AB");
			}
			
			return result;
		}
	}
}