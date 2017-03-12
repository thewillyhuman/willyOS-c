using System;
using System.IO;
using System.Threading;
using System.Text;
using System.Linq;
using System.Collections.Generic;

namespace TPP.Concurrency.TPL {

    /// <summary>
    /// Utility class with file and text processing services.
    /// </summary>
    public static class TextProcessing {

        /// <summary>
        /// Reads a file
        /// </summary>
        /// <param name="fileName">The name of the input text file</param>
        /// <returns>A string with the text in the file</returns>
        public static String ReadTextFile(string fileName) {
            using (StreamReader stream = File.OpenText(fileName)) {
                StringBuilder text = new StringBuilder();
                string line;
                while ((line = stream.ReadLine()) != null) {
                    text.AppendLine(line);
                }
                return text.ToString();
            }
        }

        /// <summary>
        /// Returns the number of punctuation marks ( . , ; : ) in the text
        /// </summary>
        public static int NumberOfPunctuationMarks(string text) {
            return text.Count(character => character == '.' || character == ',' || character == ';' || character == ':'); 
        }


        /// <summary>
        /// Divides a text into words
        /// </summary>
        public static string[] DivideIntoWords(String text) {
            return text.Split(new char[] { ' ', '\r', '\n', ',', '.', ';', ':', '-', '!', '¡', '¿', '?', '/', '«', 
                                            '»', '_', '(', ')', '\"', '*', '\'', 'º', '[', ']', '#' },
                StringSplitOptions.RemoveEmptyEntries);
        }

        /// <summary>
        /// Returns the list of words with greatest length
        /// </summary>
        public static string[] LongestWords(string[] words) {
            // We use Linq higher-order functions
            return words
                .GroupBy( word => word.Length)  // words are classified in groups of words with the same length
                .OrderByDescending( group => group.Key)  // the groups are ordered by descending length
                .Select( group => group.Distinct()) // repeated words per group are erased
                .First() // we take the first group (words with the greatest length)
                .ToArray(); // and convert it to an array
        }

        /// <summary>
        /// Returns the list of words with smallest length
        /// </summary>
        public static string[] ShortestWords(string[] words) {
            return words
                .GroupBy(word => word.Length) // words are classified in groups of words with the same length
                .OrderBy(grupo => grupo.Key) // the groups are ordered by ascending length
                .Select(grupo => grupo.Distinct()) // repeated words per group are erased
                .First() // we take the first group (words with the smallest length)
                .ToArray(); // and convert it to an array

        }

        /// <summary>
        /// Returns a list of those words that appear fewer times in the text
        /// <param name="words">The list of words</param>
        /// <param name="occurrence">Output parameter: the number of occurrences of the returned words</param>
        /// <returns>A list of those words that appear fewer times in the text</returns>
        /// </summary>
        public static string[] WordsAppearFewerTimes(string[] words, out int occurrence) {
            var wordsAndOccurrences = words
                .GroupBy(word => word.ToLower()) // words are grouped by its lowercase representation
                .Select(group => new { Word = group.Key, Occurrences = group.Count() }) // we convert it in a list of pairs {Word, Occurrence}
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
        /// Returns a list of those words that appear more times in the text
        /// <param name="words">The list of words</param>
        /// <param name="occurrence">Output parameter: the number of occurrences of the returned words</param>
        /// <returns>A list of those words that appear more times in the text</returns>
        /// </summary>
        public static string[] WordsAppearMoreTimes(string[] words, out int occurrence) {
            var wordsAndOccurrences = words
                .GroupBy(word => word.ToLower()) // words are grouped by its lowercase representation
                .Select(group => new { Word = group.Key, Occurrences = group.Count() }) // we convert it in a list of pairs {Word, Occurrence}
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
        /// Method to show the results of processing the text
        /// </summary>
        public static void ShowResults(int punctuationMarks, string[] shortestWords, string[] longestWords, 
                                       string[] wordsAppearFewerTimes, int lowestOccurrence, 
                                       string[] wordsAppearMoreTimes, int greatestOccurrence) {
            const int maxNumberOfElementsToShow = 20;

            Console.WriteLine("> There were {0} punctuation marks. ", punctuationMarks);

            Console.Write("> {0} shortest words: ", shortestWords.Count());
            Show(shortestWords, Console.Out, maxNumberOfElementsToShow);
            Console.WriteLine();

            Console.Write("> {0} longest words: ", longestWords.Count());
            Show(longestWords, Console.Out, maxNumberOfElementsToShow);
            Console.WriteLine();

            Console.Write("> {0} words appeared fewer times ({1}): ", wordsAppearFewerTimes.Count(), lowestOccurrence);
            Show(wordsAppearFewerTimes, Console.Out, maxNumberOfElementsToShow);
            Console.WriteLine();

            Console.Write("> {0} words appreared more times ({1}): ", wordsAppearMoreTimes.Count(), greatestOccurrence);
            Show(wordsAppearMoreTimes, Console.Out, maxNumberOfElementsToShow);
            Console.WriteLine();
        }

        /// <summary>
        /// Generic method to show the elements in a collection.
        /// A maximum number of elements to be shown is passed.
        /// </summary>
        private static void Show<T>(IEnumerable<T> collection, TextWriter stream, int maxNumberOfElements) {
            int i = 0;
            foreach (T element in collection) {
                stream.Write(element);
                i = i + 1;
                if (i == maxNumberOfElements) {
                    stream.Write("...");
                    break;
                }
                if (i < collection.Count())
                    stream.Write(", ");
            }
        }

    }

}
