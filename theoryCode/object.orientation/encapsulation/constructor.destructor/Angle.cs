using System;

namespace TPP.ObjectOrientation.Encapsulation {

    /// <summary>
    /// Example class that offers basic angle services
    /// </summary>
    public class Angle {

        /// <summary>
        /// Angle radians
        /// </summary>
        private double Radians;

        /// <summary>
        /// Public method to get the angle radians
        /// </summary>
        public double GetRadians() {
            return this.Radians;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="radians">Angle in radians</param>
        public Angle(double radians) {
            this.Radians = radians;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="degrees">Sexagesimal degrees</param>
        public Angle(int degrees) {
            Radians = degrees / 180.0 * Math.PI;
        }

        /// <summary>
        /// Example destructor
        /// </summary>
        ~Angle() {
            Console.WriteLine("Executing the destructor of an angle of {0} radians.", Radians);
        }

        /// <summary>
        /// Computes the sine
        /// </summary>
        /// <returns>The sine of the implicit object</returns>
        public double Sine() {
            return Math.Sin(Radians);
        }

        /// <summary>
        /// Computes the cosine
        /// </summary>
        /// <returns>The cosine of the angle</returns>
        public double Cosine() {
            return Math.Cos(Radians);
        }

        /// <summary>
        /// Computes the tangent of the angle
        /// </summary>
        /// <returns>The tangent of the implicit object</returns>
        public double Tangent() {
            return Sine() / Cosine();
        }


        static void Main() {
            Angle angle1 = new Angle(180), // * Degrees
                    angle2 = new Angle(Math.PI); // * Radians
            Console.WriteLine("Sine:     {0,6:F} {1,6:F}", angle1.Sine(), angle2.Sine());
            Console.WriteLine("Cosine:   {0,6:F} {1,6:F}", angle1.Cosine(), angle2.Cosine());
            Console.WriteLine("Tangent:  {0,6:F} {1,6:F}", angle1.Tangent(), angle2.Tangent());
        }
    }
}
