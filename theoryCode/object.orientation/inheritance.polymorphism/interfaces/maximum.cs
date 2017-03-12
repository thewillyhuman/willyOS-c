using System;

namespace TPP.ObjectOrientation.InheritancePolymorphism {

    class Maximum {

        /// <summary>
        /// Polymorphic method that computes the maximum value of any pair of IComparable objects
        /// </summary>
        /// <returns>The greatest object</returns>
        static IComparable Max(IComparable a, IComparable b) {
            return a.Compare(b) > 0 ? a : b;
        }

        static void Main() {
            Angle a1 = new Angle(30), a2 = new Angle(90);
            Console.WriteLine(Max(a1, a2));
            Person p1 = new Person("Pepe", "Pérez", 33),
                p2 = new Person("Juana", "Reglero", 16);
            Console.WriteLine(Max(p1, p2));
            Integer e1 = new Integer(1), e2 = new Integer(2);
            Console.WriteLine(Max(e1, e2));
        }
    }
}
