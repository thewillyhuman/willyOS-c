using System;
using System.Collections.Generic;

namespace TPP.Functional.PatternMatching {

    class Program {

        /// <summary>
        /// By using the is operator, it is possible to inspect the type of the figure.
        /// This way of programming is an anti-pattern. 
        /// You should never program this way.
        /// This code is totally unmaintainable.
        /// </summary>
        static double AreaIs(Object figure) {
            if (figure is Circle)
                return Math.PI * Math.Pow(((Circle)figure).Radius,2);
            if (figure is Square)
                return Math.Pow(((Square)figure).Side, 2);
            if (figure is Rectangle) {
                Rectangle rectangle = figure as Rectangle;
                return rectangle.Height * rectangle.Width;
            }
            if (figure is Triangle) {
                Triangle triangle = figure as Triangle;
                return triangle.Base * triangle.Height / 2;
            }
            throw new ArgumentException("The parameter is not a figure");
        }

        /// <summary>
        /// The same kind of unmaintainable code, but using reflection.
        /// </summary>
        static double AreaGetType(Object figure) {
            switch(figure.GetType().Name) {
                case "Circle": return Math.PI * Math.Pow(((Circle)figure).Radius, 2);
                case "Square": return Math.Pow(((Square)figure).Side, 2);
                case "Rectangle":
                    Rectangle rectangle = figure as Rectangle;
                    return rectangle.Height * rectangle.Width;
                case "Triangle":
                    Triangle triangle = figure as Triangle;
                    return triangle.Base * triangle.Height / 2;
                default: throw new ArgumentException("The parameter is not a figure");
            }
        }

        static void Main() {
            Circle circle = new Circle { Radius = 2 };
            Square square = new Square { Side = 3 };
            Rectangle rectangle = new Rectangle { Width = 2, Height = 4 };
            Triangle triangle = new Triangle { Base = 2, Height = 4 };

            Console.WriteLine(AreaIs(circle));
            Console.WriteLine(AreaIs(square));
            Console.WriteLine(AreaIs(rectangle));
            Console.WriteLine(AreaIs(triangle));

            Console.WriteLine(AreaGetType(circle));
            Console.WriteLine(AreaGetType(square));
            Console.WriteLine(AreaGetType(rectangle));
            Console.WriteLine(AreaGetType(triangle));
        }


    }

}
