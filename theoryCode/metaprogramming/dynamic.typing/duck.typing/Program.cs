using System;

namespace TPP.ObjectOrientation.DynamicTyping {

    class Program {

        /// <summary>
        /// Example method that uses duck typing.
        /// Different figures can be used, but no hinheritance relationship has been defined.
        /// </summary>
        static void Move(dynamic figure, int x, int y) {
            figure.X += x;
            figure.Y += y;
        }

        static void Main() {
            Circumference circumference = new Circumference(1, 20, 5);
            Rectangle rectangle = new Rectangle(-10, -34, 10, 20);
            Console.WriteLine(circumference);
            Console.WriteLine(rectangle);
            Move(circumference, 10, 20);
            Move(rectangle, 10, 20);
            Console.WriteLine(circumference);
            Console.WriteLine(rectangle);
        }

    }

}
