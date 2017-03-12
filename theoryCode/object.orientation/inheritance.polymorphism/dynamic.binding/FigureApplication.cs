using System;

namespace TPP.ObjectOrientation.InheritancePolymorphism {

	class FigureApplication {

        public static void Main() {
            Figure figure;
            figure = new Circumference(0, 0, 10);
            figure.Show();
            figure = new Rectangle(10, -10, 20, 5);
            figure.Show();
            figure.Move(10, 0);
        }

	} 
} 
