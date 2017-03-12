using System;

namespace TPP.ObjectOrientation.InheritancePolymorphism {

    /// <summary>
    /// Figure is a polymorphic class
	/// </summary>
	public class Figure {
		/// <summary>
		/// Bidimensional cooridnates
		/// </summary>
		private int x,y;
		/// <summary>
		/// X readonly property
		/// </summary>
		public int X {
			get { return x; }
		}
		/// <summary>
		/// Y readonly property
		/// </summary>
		public int Y {
			get { return y; }
		}

		/// <summary>
		/// To known whether a figure is being shown
		/// </summary>
		protected bool visible;
		public bool Visible {
			get { return visible; }
		}

        /// <summary>
        /// Shows the figure (only if it was hidden)
        /// </summary>
        public virtual void Show() {
			if (!visible) {
				Console.WriteLine("The figure in ({0},{1}) is showed.",x,y);
				visible=true;
			}
		}

        /// <summary>
        /// Hides the figure (in case it is visible)
        /// </summary>
        public virtual void Hide() {
			if (visible) {
				Console.WriteLine("The figure in ({0},{1}) is hidden.",x,y);
				visible=false;
			}
		}

		/// <summary>
		/// Moves a figure
		/// </summary>
		/// <param name="x">The new x coordinate</param>
		/// <param name="y">the new y coordinate</param>
        public void Move(int x, int y) {
            if (visible) {
                Hide();
                this.x = x;
                this.y = y;
                Show();
            }
            else {
                this.x = x;
                this.y = y;
            }
        }

		public Figure(int x, int y){
			this.x=x;
			this.y=y;
			this.visible=false;
	}

	} 
}
