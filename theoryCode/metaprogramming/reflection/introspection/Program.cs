using System;
using System.Reflection;

namespace TPP.ObjectOrientation.Reflection {

    class Program {

        /// <summary>
        /// Example method that uses reflection (introspection) to obtain duck typing.
        /// </summary>
        static void Move(object figure, int x, int y) {
            Type type = figure.GetType();
            PropertyInfo xProperty = type.GetProperty("X");
            PropertyInfo yProperty = type.GetProperty("Y");
            int currentX = (int)xProperty.GetValue(figure, null);
            int currentY = (int)yProperty.GetValue(figure, null);
            xProperty.SetValue(figure, currentX + x, null);
            yProperty.SetValue(figure, currentY + y, null);
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
