using System;

namespace TPP.ObjectOrientation.Basic {
    
    class ConsoleDemo {
        static void Main(string[] args) {
            const double PI = 3.141592;
            const int integer = -34;
            Console.WriteLine("Number Formats:");
            Console.WriteLine(
                "(C) Currency: . . . . . . . . {0,20:C}\n" +
                "(D) Decimal:. . . . . . . . . {0,20:D}\n" +
                "(E) Scientific: . . . . . . . {1,20:E}\n" +
                "(F) Fixed point:. . . . . . . {1,20:F}\n" +
                "(G) General:. . . . . . . . . {0,20:G}\n" +
                "    (default):. . . . . . . . {0,20} (default = 'G')\n" +
                "(N) Number: . . . . . . . . . {0,20:N}\n" +
                "(P) Percent:. . . . . . . . . {1,20:P}\n" +
                "(R) Round-trip: . . . . . . . {1,20:R}\n" +
                "(X) Hexadecimal:. . . . . . . {0,20:X}\n",
                integer, PI);
        }
    }
}
