using System;

namespace TPP.ObjectOrientation.Encapsulation {

    /// <summary>
    /// An example point class
    /// </summary>
    class PointClass {

        public int X { get; set; }
        public int Y { get; set; }

        public PointClass(int x, int y) {
            this.X = x;
            this.Y = y;
        }

        public override string ToString() {
            return String.Format("Point object in ({0},{1}).", this.X, this.Y);
        }


    }

}
