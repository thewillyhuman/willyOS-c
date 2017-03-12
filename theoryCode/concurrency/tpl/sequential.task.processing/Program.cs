using System;
using System.IO;
using System.Threading;
using System.Text;
using System.Collections.Generic;
using System.Linq;


namespace TPP.Concurrency.TPL {

    /// <summary>
    /// Example sequential program that processes a file with different tasks.
    /// It will be parallelized in the task.parallelism project.
    /// </summary>
    class Program {


        static void Main(string[] args) {
            String text = TextProcessing.ReadTextFile(@"..\..\..\clarin.txt");
            string[] words = TextProcessing.DivideIntoWords(text);

            // Processing
            DateTime before = DateTime.Now;
            int punctuationMarks = TextProcessing.NumberOfPunctuationMarks(text);
            var longestWords = TextProcessing.LongestWords(words);
            var shortestWords = TextProcessing.ShortestWords(words);
            int greatestOccurrence, lowestOccurrence;
            var wordsAppearMoreTimes = TextProcessing.WordsAppearMoreTimes(words, out greatestOccurrence);
            var wordsAppearFewerTimes = TextProcessing.WordsAppearFewerTimes(words, out lowestOccurrence);
            DateTime after = DateTime.Now;

            TextProcessing.ShowResults(punctuationMarks, shortestWords, longestWords, wordsAppearFewerTimes, lowestOccurrence, 
                wordsAppearMoreTimes, greatestOccurrence);

            Console.WriteLine("\nElapsed time: {0:N} milliseconds.", (after - before).Ticks / TimeSpan.TicksPerMillisecond);
        }



    }

}
