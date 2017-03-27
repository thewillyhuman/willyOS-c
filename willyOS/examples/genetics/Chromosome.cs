using System;
namespace examples.genetics {

	/// <summary>
	/// Chromosome.
	/// </summary>
	public class Chromosome {

		public static char[] ONE = Generate(100);
		public static char[] TWO = Generate(100);
		public static char[] THREE = Generate(100);
		public static char[] FOUR = Generate(100);
		public static char[] FIVE = Generate(100);
		public static char[] SIX = Generate(100);
		public static char[] SEVEN = Generate(100);
		public static char[] EIGHT = Generate(100);
		public static char[] NINE = Generate(100);
		public static char[] TEN = Generate(100);
		public static char[] ELEVEN = Generate(100);
		public static char[] TWELVE = Generate(100);
		public static char[] TIRHTEEN = Generate(100);
		public static char[] FOURTEEN = Generate(100);
		public static char[] FIVETEEN = Generate(100);
		public static char[] SIXTEEN = Generate(100);
		public static char[] SEVENTEEN = Generate(100);
		public static char[] EIGHTEEN = Generate(100);
		public static char[] NINETEEN = Generate(100);
		public static char[] TWENTY = Generate(100);
		public static char[] TWENTYONE = Generate(100);
		public static char[] TWENTYTWO = Generate(100);
		public static char[] X = Generate(100);
		public static char[] Y = Generate(100);

		/// <summary>
		/// Generates a random chromosome of a given size.
		/// </summary>
		/// <returns>The generate.</returns>
		/// <param name="size">Size.</param>
		public static char[] Generate(int size) {
			char[] n = { 'A', 'G', 'T', 'C' };

			char[] tmp = new char[size];

			var rnd = new Random();
			var j = 0;
			for(int i = 0; i < size; i++) {
				j =rnd.Next(4);
				tmp[i] = n[j];
			}

			return tmp;
		}
	}
}
