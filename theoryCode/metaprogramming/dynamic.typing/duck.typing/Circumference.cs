using System;

namespace TPP.ObjectOrientation.DynamicTyping {

    public class Circumference {
        private int radius;

        public int X { get; set; }

        public int Y { get; set; }

        public int Radius {
            get { return this.radius; }
        }

        public Circumference(int x, int y, int radius) {
            this.X = x;
            this.Y = y;
            this.radius = radius;
        }

        public override string ToString() {
            return String.Format("Circumference in ({0}, {1}) with a radius of {2}.",
                this.X, this.Y, this.Radius);
        }

    }
}
