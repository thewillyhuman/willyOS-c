using System;

namespace TPP.ObjectOrientation.Basic {
    /// <summary>
    /// Example of the multiple switch conditional
    /// </summary>
    class Switch {
        /// <summary>
        /// The Main function receives a party to be voted
        /// </summary>
        /// <param name="args">A single string with the party to be voted</param>
        static void Main(string[] args) {
            if (args.Length == 0) {
                Console.Error.WriteLine("A party is required!");
                return;
            }
            switch (args[0]) {
                case "Democrat":
                    Console.WriteLine("You voted Democratic.\n");
                    break;
                case "Liberal Republican":  // * Continues
                case "Republican":
                    Console.WriteLine("You voted Republican.\n");
                    break;
                case "New Left":
                    Console.WriteLine("NewLeft is now Progressive");
                    goto case "Progressive";
                case "Progressive":
                    Console.WriteLine("You voted Progressive.\n");
                    break;
                case "Libertarian":
                    Console.WriteLine("Libertarians are voting Republican");
                    goto case "Republican";
                default:
                    Console.WriteLine("You have voted for an invalid party.\n");
                    break;
            }
            Console.WriteLine("Thank you for voting!");
        }
    }
}
