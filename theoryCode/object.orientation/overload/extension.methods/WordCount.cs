using System;
using System.Text;
using System.Text.RegularExpressions;

namespace TPP.ObjectOrientation.Overload {

    /// <summary>
    /// This class adds a new functionality to the String class.
    /// Using extension methods, it is possible to count the words in a String.
    /// </summary>
    static class StringExtension {

        /// <summary>
        /// Extension method
        /// </summary>
        /// <param name="theString">The string to count words in</param>
        /// <returns>The number of words in the string</returns>
        static public uint CountWords(this string theString) {
            // * We break the string using regular expressions
            var lines = Regex.Split(theString, "\r|\n|[.]|[,]|[ ]");
            uint numberOfWords = 0;
            foreach (var line in lines)
                // * Empty strings and spaces are skipped
                if (!String.IsNullOrEmpty(line) && !String.IsNullOrWhiteSpace(line))
                    numberOfWords++;
            return numberOfWords;
        }

    }


}
