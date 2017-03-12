using System;

namespace TPP.ObjectOrientation.Reflection {

    public class Rectangle {
        private int width, height;

        public int X { get; set; }

        public int Y { get; set; }

        public int Width {
            get { return this.width; }
        }

        public int Height {
            get { return this.height; }
        }

        public Rectangle(int x, int y, int width, int height) {
            this.X = x;
            this.Y = y;
            this.width = width;
            this.height = height;
        }


        public override string ToString() {
            return String.Format("Rectangle in ({0}, {1}), width {2} and height {3}.",
                this.X, this.Y, this.Width, this.Height);
        }
    }
}
