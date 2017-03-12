using System;
using System.Collections.Generic;

namespace TPP.Functional.PatternMatching {

    internal class Figure {
        public int X { get; set; }
        public int Y { get; set; }
    }

    internal class Circle : Figure {
        public int Radius { get; set; }
    }

    internal class Square: Figure {
        public int Side { get; set; }
    }

    internal class Rectangle: Figure {
        public int Width { get; set; }
        public int Height { get; set; }
    }

    internal class Triangle: Figure {
        public int Base { get; set; }
        public int Height { get; set; }
    }


}
