namespace TPP.ObjectOrientation.Encapsulation {

    /// <summary>
    /// Properties demo
    /// </summary>
    public class Circumference {
        /// <summary>
        /// Private fields
        /// </summary>
        private int x;

        /// <summary>
        /// X readonly property
        /// </summary>
        public int X {
            get { return x; }
        }

        /// <summary>
        /// Radius read/write property
        /// With the following syntax, you do not need to define the corresponding private field
        /// </summary>
        public uint Radius  { get; set; }
        
        
        /// <summary>
        /// A new syntax to define a readonly property.
        /// The setter is declared private.
        /// No field is required.
        /// </summary>
        public int Y { get; private set; }

        /// <summary>
        /// To modify the coordinates, we have to call Move
        /// </summary>
        /// <param name="relx">Relative x movement</param>
        /// <param name="rely">Relative y movement</param>
        public void Move(int relx, int rely) {
            x += relx;
            Y += rely;
        }


        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="x">X coordinate</param>
        /// <param name="y">Y coordinate</param>
        /// <param name="radius">Radius</param>
        public Circumference(int x, int y, uint radius) {
            this.x = x;
            this.Y = y;
            this.Radius = radius;
        }

        /// <summary>
        /// To show circumferences.
        /// We'll see later on what "override" means.
        /// </summary>
        /// <returns>A textual representation of circumferences.</returns>
        public override string ToString() {
            return "Circumference in (" + x + "," + Y + ")" +
                ", with " + Radius + " radius.";
        }

    }
}