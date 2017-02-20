using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace willyOS {

	public class RAWordGenerator {
		/// <summary>
		/// Generates a random word, randomly choosing from a list of common spanish words
		/// </summary>
		/// <returns></returns>
		public static string GenerateRandomWord() {
			Random random = new Random();
			int wordIndex = random.Next(0, RARandomWordGeneratorData.words.Length);

			return RARandomWordGeneratorData.words[wordIndex];
		}

		/// <summary>
		/// Generates a random text of the specified minimum and maximum size, with the frequency of dots an commas specified. Text is fully random, and text words are also
		/// chosen from a spanish dictionary, so the text has no meaning by itself. 
		/// </summary>
		/// <param name="minWords">Minimum text words</param>
		/// <param name="maxWords">Maximum text words</param>
		/// <param name="dotsPerWord">A dot will be placed in the text each N words</param>
		/// <param name="commasPerWord">A comma will be placed in the text each N words</param>
		/// <returns></returns>
		public static string GenerateRandomText(int minWords = 10, int maxWords = 50, int dotsPerWord = 13, int commasPerWord = 7) {
			Random random = new Random();
			StringBuilder sb = new StringBuilder();

			int limit = random.Next(minWords, maxWords);
			CultureInfo cultureInfo = Thread.CurrentThread.CurrentCulture;
			TextInfo textInfo = cultureInfo.TextInfo;
			bool capitalizeNext = false;

			for (int i = 0; i < limit; i++) {
				int wordIndex = random.Next(0, RARandomWordGeneratorData.words.Length);

				if (i == 0) //First word of the text
					sb.Append(textInfo.ToTitleCase(RARandomWordGeneratorData.words[wordIndex]));
				else {
					//Next word have to be capitalized (We placed a dot in the previous iteration
					if (capitalizeNext) {
						sb.Append(" " + textInfo.ToTitleCase(RARandomWordGeneratorData.words[wordIndex]));
						capitalizeNext = false;
					} else
						sb.Append(" " + RARandomWordGeneratorData.words[wordIndex]);

					//Dots and commas cannot be placed at the very beginning of the text
					if (i > 1) {
						if (i % commasPerWord == 0)
							sb.Append(",");
						else {
							if (i % dotsPerWord == 0) {
								sb.Append(".");
								capitalizeNext = true;
							}
						}
					}
				}
			}

			sb.Append(".");
			return sb.ToString();
		}
	}
}