using System;

namespace TPP.ObjectOrientation.Exceptions {

    class ExceptionsDemo {

        /// <summary>
        /// A method that can throw 3 different exceptions
        /// </summary>
        /// <param name="n">A parameter used to select the exception to be thrown</param>
        static void ThrowException(int n) {
            switch (n) {
                case 1:
                    int a = 0;
                    Console.WriteLine(n / a); // * DivideByZeroException 
                    break;
                case 2:
                    String s=null;
                    s.Clone(); // *  NullReferenceException
                    break;
                default:
                    throw new ApplicationException("Another exception");
            }
        }


        static void Main(string[] args) {
            // * Here, the IndexOutOfRange exception could be thrown
            // * if no parameters have been passed to the Main method
            int option = Int32.Parse(args[0]);

            // * We execute code that can throw exceptions
            try {
                ThrowException(option);
            } catch (NullReferenceException e) {
                Console.Error.WriteLine(e.Message);
                // * The finally block is executed
            } catch (Exception e) {
                // * The two other exceptions are handled here, due to polymorphism.
                Console.Error.WriteLine(e.Message+"\n"+e.Source+"\n"+e.StackTrace);
                // * The finally block is executed
            } finally {
                Console.WriteLine("This setence is always executed.");
            }
            Console.WriteLine("The application has handled its exceptions and it keeps running.");
        }
    }

}
