using System;

namespace TPP.ObjectOrientation.InheritancePolymorphism {

    public class Angle : IComparable {

        /// <summary>
        /// Compare method
        /// </summary>
        /// <param name="c">The object to be compared</param>
        /// <returns>A negative number if this is lower than c;
        /// zero if they are the same; 
        /// a positive number if this is greater than c.</returns>
        public int Compare(IComparable c) {
            Angle a = (Angle)c;
            return this.Radians < a.Radians ? -1 : 1;
        }

        public override string ToString() {
            return ((int)(Radians/Math.PI*180)).ToString()+"º";
        }

        private double Radians;

        public Angle(double radians) {
            this.Radians = radians;
        }

        public Angle(int degrees) {
            Radians = degrees / 180.0 * Math.PI;
        }

        public double Sine() {
            return Math.Sin(Radians);
        }

        public double Cosine() {
            return Math.Cos(Radians);
        }

        public double Tangent() {
            return Sine() / Cosine();
        }
    }
}
