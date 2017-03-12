using System;

namespace TPP.ObjectOrientation.Overload {

    /// <summary>
    /// Example of the three different parameter passing mechanisms in C#
    /// </summary>
    class Parameters {

        /// <summary>
        /// Method with two parameters by value.
        /// Modifying the formal parameters does not involve
        /// modifying of the actual parameters (arguments).
        /// </summary>
        /// <param name="labase">base</param>
        /// <param name="elexponente">exponent</param>
        /// <returns>theBase raised to the power of theExponent</returns>
        static long Power(int theBase, int theExponent) {
            long toReturn = (long) Math.Pow(theBase, theExponent);
            // * We try to modify the paramters (innocuous)
            theBase = theExponent = 0;
            return toReturn;
        }

        /// <summary>
        /// Method with two parameters by reference (ref).
        /// Modifying the formal parameters involves 
        /// modifying of the actual parameters (arguments).
        /// </summary>
        /// <param name="labase">base</param>
        /// <param name="elexponente">exponent</param>
        /// <returns>theBase raised to the power of theExponent</returns>
        static long PowerRef(ref int theBase, ref int theExponent) {
            long toReturn = (long) Math.Pow(theBase, theExponent);
            // * We try to modify the paramters (accomplished)
            theBase = theExponent = 0;
            return toReturn;
        }

        /// <summary>
        /// Method with three output parameters (out).
        /// The three uninitialized refereces are modified in the method.
        /// </summary>
        /// <param name="firstName">Returns (modifies) the firstname</param>
        /// <param name="surname">Returns (modifies) the surname</param>
        /// <param name="idNumber">Returns (modifies) the idNumber</param>
        static void LeeDatos(out string firstName, out string surname, out string idNumber) {
            Console.Write("First name: ");
            firstName = Console.ReadLine();
            Console.Write("Surname: ");
            surname= Console.ReadLine();
            Console.Write("Id number: ");
            idNumber= Console.ReadLine();
        }


        static void Main() {
            int theBase = 2, theExponent = 3;
            Console.WriteLine("By value. Base: {0}, exponent: {1}, power: {2}.",
                theBase, theExponent, Power(theBase, theExponent));
            Console.WriteLine("After the invocation. Base: {0}, exponent: {1}.", theBase, theExponent);

            Console.WriteLine("By reference. Base: {0}, exponente: {1}, power: {2}.",
                theBase, theExponent, PowerRef(ref theBase, ref theExponent));
            Console.WriteLine("After the invocation. Base: {0}, exponente: {1}.", theBase, theExponent);

            string firstName, surname, idNumber;
            LeeDatos(out firstName, out surname, out idNumber);
            Console.WriteLine("First name: {0}, surname: {1}, id number: {2}.", firstName, surname, idNumber);
        }
    }
}
