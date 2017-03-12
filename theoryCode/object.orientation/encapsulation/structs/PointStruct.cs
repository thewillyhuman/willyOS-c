using System;

namespace TPP.ObjectOrientation.Encapsulation {

    /// <summary>
    /// An example point struct
    /// </summary>
    struct PointStruct {

        public int X { get; set; }
        public int Y { get; set; }

        public override string ToString() {
            return String.Format("Point struct in ({0},{1}).", this.X, this.Y);
        }

    }

}
