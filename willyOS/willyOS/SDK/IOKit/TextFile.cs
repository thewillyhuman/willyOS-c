using System;
using System.IO;
using System.Linq;
using System.Text;
using CoreServices;
using Foundation;

namespace IOKit {

	/// <summary>
	/// File.
	/// </summary>
	public class TextFile : CSPrint {

		/// <summary>
		/// The content.
		/// </summary>
		string _content;

		/// <summary>
		/// Gets the content.
		/// </summary>
		/// <value>The content.</value>
		public string Content {
			get {
				return _content;
			}
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="T:IOKit.TextFile"/> class.
		/// </summary>
		/// <param name="fileName">File name.</param>
		public TextFile(string fileName) {
			_content = ReadTextFile(fileName);
		}

		/// <summary>
		/// Reads the text file.
		/// </summary>
		/// <returns>The text file.</returns>
		/// <param name="fileName">File name.</param>
		public static string ReadTextFile(string fileName) {
			using(StreamReader stream = File.OpenText(fileName)) {
				StringBuilder text = new StringBuilder();
				string line;
				while((line = stream.ReadLine()) != null) {
					text.AppendLine(line);
				}
				return text.ToString();
			}
		}

		/// <summary>
		/// Divides the into words.
		/// </summary>
		/// <returns>The into words.</returns>
		/// <param name="text">Text.</param>
		public static string[] DivideIntoWords(string text) {
			return text.Split(new char[] { ' ', '\r', '\n', ',', '.', ';', ':', '-', '!', '¡', '¿', '?', '/', '«',
											'»', '_', '(', ')', '\"', '*', '\'', 'º', '[', ']' },
				StringSplitOptions.RemoveEmptyEntries);
		}

		/// <summary>
		/// Punctuations the marks.
		/// </summary>
		/// <returns>The marks.</returns>
		/// <param name="text">Text.</param>
		public static int PunctuationMarks(string text) {
			return text.Count(character => character == '.' || character == ',' || character == ';' || character == ':');
		}

		/// <summary>
		/// Longests the words.
		/// </summary>
		/// <returns>The words.</returns>
		/// <param name="words">Words.</param>
		public static string[] LongestWords(string[] words) {
			// We use Linq higher-order functions
			return words
				.GroupBy(word => word.Length)  // words are classified in groups of words with the same length
				.OrderByDescending(group => group.Key)  // the groups are ordered by descending length
				.Select(group => group.Distinct()) // repeated words per group are erased
				.First() // we take the first group (words with the greatest length)
				.ToArray(); // and convert it to an array
		}

		/// <summary>
		/// Shortests the words.
		/// </summary>
		/// <returns>The words.</returns>
		/// <param name="words">Words.</param>
		public static string[] ShortestWords(string[] words) {
			return words
				.GroupBy(word => word.Length) // words are classified in groups of words with the same length
				.OrderBy(grupo => grupo.Key) // the groups are ordered by ascending length
				.Select(grupo => grupo.Distinct()) // repeated words per group are erased
				.First() // we take the first group (words with the smallest length)
				.ToArray(); // and convert it to an array

		}

		/// <summary>
		/// Wordses the appear fewer times.
		/// </summary>
		/// <returns>The appear fewer times.</returns>
		/// <param name="words">Words.</param>
		/// <param name="occurrence">Occurrence.</param>
		public static string[] WordsAppearFewerTimes(string[] words, out int occurrence) {
			var wordsAndOccurrences = words
				.GroupBy(word => word.ToLower()) // words are grouped by its lowercase representation
				.Select(group => new {
					Word = group.Key, Occurrences = group.Count()
				}) // we convert it in a list of pairs {Word, Occurrence}
				.OrderBy(pair => pair.Occurrences); // pairs are sorted ascending by occurrences
													// We take lowest occurrence from the first pair 
			int lowestOccurrence = occurrence = wordsAndOccurrences.First().Occurrences;
			// We return all the words whose occurrences are the same to the lowest one
			return wordsAndOccurrences
				.Where(pair => pair.Occurrences == lowestOccurrence) // pairs are filtered with the lowest number of occurrences
				.Select(pair => pair.Word)  // we take the lowercase word
				.ToArray(); // and convert it to an array
		}

		/// <summary>
		/// Wordses the appear more times.
		/// </summary>
		/// <returns>The appear more times.</returns>
		/// <param name="words">Words.</param>
		/// <param name="occurrence">Occurrence.</param>
		public static string[] WordsAppearMoreTimes(string[] words, out int occurrence) {
			var wordsAndOccurrences = words
				.GroupBy(word => word.ToLower()) // words are grouped by its lowercase representation
				.Select(group => new {
					Word = group.Key, Occurrences = group.Count()
				}) // we convert it in a list of pairs {Word, Occurrence}
				.OrderByDescending(pair => pair.Occurrences); // pairs are sorted descending by occurrences
															  // We take greatest occurrence from the first pair 
			int greatestOccurrence = occurrence = wordsAndOccurrences.First().Occurrences;
			// We return all the words whose occurrences are the same to the greatest one
			return wordsAndOccurrences
				.Where(pair => pair.Occurrences == greatestOccurrence) // pairs are filtered with the greatest number of occurrences
				.Select(pair => pair.Word)  // we take the lowercase word
				.ToArray(); // and convert it to an array
		}

		/// <summary>
		/// Wordses the appearance.
		/// </summary>
		/// <param name="words">Words.</param>
		public static NSDictionary<string, int> WordsAppearancePLinq(string[] words) {
			var tmp = new NSDictionary<string, int>();
			var wordsAndOccurrences = words.AsParallel()
				.GroupBy(word => word.ToLower()).AsParallel() // words are grouped by its lowercase representation
				.Select(group => new {
					Word = group.Key, Occurrences = group.Count()
				}) // we convert it in a list of pairs {Word, Occurrence}
				.OrderByDescending(pair => pair.Occurrences);

			foreach(var word in wordsAndOccurrences) {
				tmp.Add(word.Word, word.Occurrences);
			}

			return tmp;
		}

		/// <summary>
		/// Wordses the appearance.
		/// </summary>
		/// <param name="words">Words.</param>
		public static NSDictionary<string, int> WordsAppearance(string[] words) {
			var tmp = new NSDictionary<string, int>();
			var wordsAndOccurrences = words
				.GroupBy(word => word.ToLower()).AsParallel() // words are grouped by its lowercase representation
				.Select(group => new {
					Word = group.Key, Occurrences = group.Count()
				}) // we convert it in a list of pairs {Word, Occurrence}
				.OrderByDescending(pair => pair.Occurrences).ToList();

			foreach(var word in wordsAndOccurrences) {
				tmp.Add(word.Word, word.Occurrences);
			}

			return tmp;
		}
	}
}
