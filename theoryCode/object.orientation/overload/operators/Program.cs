using System;

namespace TPP.ObjectOrientation.Overload {


    class IntegerDemo {

        static void Main() {
            Integer e1 = new Integer(1), e2, e3;
            // * Implicit conversion overload
            e2 = 2;
            // * + operator overload
            e3 = e1 + e2;
            System.Console.WriteLine(e1 + "\n" + e2 + "\n" + e3);
            // * The += operator is automatically obtained
            e3 += e3;
            // * prefix and postfix +++
            System.Console.WriteLine(e3++);
            System.Console.WriteLine(++e3);
            // * [] operator
            System.Console.WriteLine(e3[0]);
            e3[0] = e1;
            System.Console.WriteLine(e3);
        }


    }
}