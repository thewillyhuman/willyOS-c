using System;
using System.Diagnostics;
using IOKit;
using CoreServices;
namespace examples {
	
	public class TextExample : CSPrint {

		public static void Main(string[] args) {
			var chrono = new Stopwatch();

			// We create the file we will use later.
			var file = new TextFile(@"../../../HolaCaracola.txt");

			// Secuential version.
			chrono.Start();
			var first = TextFile.WordsAppearance(TextFile.DivideIntoWords(file.Content));
			foreach(var word in first)
				print(word.Key + word.Value);
			chrono.Stop();
			print("Elapsed Time Secuential: " + chrono.ElapsedMilliseconds);

			// Parallel Version using PLinq.
			chrono.Start();
			var second = TextFile.WordsAppearancePLinq(TextFile.DivideIntoWords(file.Content));
			foreach(var word in second)
				print(word.Key + word.Value);
			chrono.Stop();
			print("Elapsed Time Parallel: " + chrono.ElapsedMilliseconds);
		}
	}
}
