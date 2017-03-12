using System;

namespace TPP.ObjectOrientation.InheritancePolymorphism {
    /// <summary>
	/// Rectangle is a type of figure
	/// </summary>
	public class Rectangle:Figure	{
		/// <summary>
		/// Width and height of the rectangle
		/// </summary>
		private int width,height;

		/// <summary>
		/// Read and write width property
		/// </summary>
		public int Width {
			get { return width; }
			set {
				width=value;
				if (Visible) {
					Hide();
					Show();
				}
			}
		}
		/// <summary>
		/// Read and write height property
		/// </summary>
		public int Height {
			get { return height; }
			set {
				height=value;
				if (Visible) {
					Hide();
					Show();
				}
			}
		}

        /// <summary>
        /// Shows the rectangle (only if it was hidden)
        /// </summary>
        public override void Show() {
			if (!Visible) {
				Console.WriteLine("A rectangle in "+
					"({0},{1}), width {2} and height {3} is shown.",X,Y,width,height);
				visible=true;
			}
		}

        /// <summary>
        /// Hides the rectangle (in case it is visible)
        /// </summary>
        public override void Hide() {
			if (Visible) {
                Console.WriteLine("A rectangle in " +
                    "({0},{1}), width {2} and height {3} is hidden.", X, Y, width, height);
                visible = false;
			}
		}

		public Rectangle(int x, int y, int ancho,int alto): base(x,y) { // base(x,y) calls the base constructor
			this.width=ancho;
			this.height=alto;
		}


	} 
} 
