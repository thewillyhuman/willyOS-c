using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TPP.Functional.PatternMatching {

    class Program {


        /* The following C# code simulates the following ML function:
        let regular figure = 
            match figure with
            | Square (_) -> true 
            | Rectangle(width, height) when width = height -> true
            | Rectangle(_, _) -> false
            | Triangle(theBase, height) -> height = theBase*System.Math.Sqrt(3.0)/2.0
            | _ -> false 
        */
        static bool Regular(Figure figure) {
            return new PatternMatchExpression<Figure,bool>(figure)
                .With(f => f is Square, f => true)
                .With(f => f is Rectangle && ((Rectangle)f).Width == ((Rectangle)f).Height, f => true)
                .With(f => f is Rectangle, f => false)
                .With(f => f is Triangle, f => ((Triangle)f).Height == ((Triangle)f).Base * Math.Sqrt(3) / 2)
                .With(f => true, f => false)
                .Evaluate();
        }

        /* The following C# code simulates the following ML function:
           let area figure = 
            match figure with
            | Circle(radius) -> 3.141592 * radius * radius
            | Rectangle(width, height) -> width * height
            | Square(side) -> side * side
            | Triangle(theBase, height) -> theBase*height/2.0
        */
        static double Area(Figure figure) {
            return new PatternMatchExpression<Figure, double>(figure)
                .With(f => f is Circle, f => Math.PI*Math.Pow(((Circle)f).Radius,2))
                .With(f => f is Rectangle, f => ((Rectangle)f).Width*((Rectangle)f).Height)
                .With(f => f is Square, f => Math.Pow(((Square)f).Side,2))
                .With(f => f is Triangle, f => ((Triangle)f).Base*((Triangle)f).Height/2)
                .Evaluate();
        }

        static void Main() {
            Circle circle = new Circle { Radius = 2 };
            Square square = new Square { Side = 2 };
            Rectangle irregularRectangle = new Rectangle { Width = 2, Height = 4 };
            Rectangle regularRectangle = new Rectangle { Width = 4, Height = 4 };
            Triangle triangle = new Triangle { Base = 2, Height = 4 };

            Console.WriteLine("Area of the circle: {0}.", Area(circle));
            Console.WriteLine("Area of the square: {0}.", Area(square));
            Console.WriteLine("Area of the irregular rectangle: {0}.", Area(irregularRectangle));
            Console.WriteLine("Area of the regular rectangle: {0}.", Area(regularRectangle));
            Console.WriteLine("Area of the triangle: {0}.", Area(triangle));

            Console.WriteLine();

            Console.WriteLine("Is a circle regular? {0}.", Regular(circle));
            Console.WriteLine("Is a square regular? {0}.", Regular(square));
            Console.WriteLine("Is a rectangle with different sides regular? {0}.", Regular(irregularRectangle));
            Console.WriteLine("Is a rectangle with all sides equal regular? {0}.", Regular(regularRectangle));
            Console.WriteLine("Is the triangle regular? {0}.", Regular(triangle));
        }

    }

}
