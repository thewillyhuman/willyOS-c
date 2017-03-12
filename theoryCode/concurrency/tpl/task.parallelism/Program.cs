using System;
using System.IO;
using System.Threading;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace TPP.Concurrency.TPL {

    /// <summary>
    /// This is the parallel version, using TPL, of the sequential.task.processing project.
    /// </summary>
    class Program {


        static void Main() {
            String text = TextProcessing.ReadTextFile(@"..\..\..\clarin.txt");
            string[] words = TextProcessing.DivideIntoWords(text);

            // Processing
            DateTime before = DateTime.Now;
            string[] longestWords = null, shortestWords = null, wordsAppearMoreTimes = null, wordsAppearFewerTimes = null;
            int greatestOccurrence = 0, lowestOccurrence = 0, punctuationMarks=0;
            Parallel.Invoke(
                () => punctuationMarks = TextProcessing.NumberOfPunctuationMarks(text),
                () => longestWords = TextProcessing.LongestWords(words),
                () => shortestWords = TextProcessing.ShortestWords(words),
                () => wordsAppearMoreTimes = TextProcessing.WordsAppearMoreTimes(words, out greatestOccurrence),
                () => wordsAppearFewerTimes = TextProcessing.WordsAppearFewerTimes(words, out lowestOccurrence)
                 );
            DateTime after = DateTime.Now;

            TextProcessing.ShowResults(punctuationMarks, shortestWords, longestWords, wordsAppearFewerTimes, lowestOccurrence, 
                wordsAppearMoreTimes, greatestOccurrence);

            Console.WriteLine("\nElapsed time: {0:N} milliseconds.", (after - before).Ticks / TimeSpan.TicksPerMillisecond);
        }



    }

}
