using System;

namespace TPP.ObjectOrientation.InheritancePolymorphism {

    /// <summary>
	/// Circumference is a type of Figure
	/// </summary>
	public class Circumference: Figure {

        private int radius;

		public int Radius {
			get { return radius; }
			set {
				radius=value;
				if (Visible) {
					Hide();
					Show();
				}
			}
		}

		/// <summary>
        /// Shows the circumference (only if it was hidden)
		/// </summary>
		public override void Show() {
            if (!Visible) {
                Console.WriteLine("The circumference in " +
                    "({0},{1}), and {2} radius is shown.", X, Y, radius);
                visible = true;
            }
		}

		/// <summary>
        /// Hides the circumference (in case it is visible)
		/// </summary>
		public override void Hide() {
            if (Visible) {
                Console.WriteLine("The circumference in " +
                    "({0},{1}), and {2} radius is hidden.", X, Y, radius);
                visible = false;
            }
		}

		public Circumference(int x, int y, int radio): base(x,y) { // base(x,y) calls the base constructor
			this.radius=radio;
		}

	} 
} 
