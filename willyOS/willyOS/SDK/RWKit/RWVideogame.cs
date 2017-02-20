using System;
namespace willyOS {

	/// <summary>
	/// Real World Videogame.
	/// </summary>
	public class RWVideogame {

		/// <summary>
		/// The sku.
		/// </summary>
		private int sku;

		/// <summary>
		/// Gets or sets the sku.
		/// </summary>
		/// <value>The sku.</value>
		public int SKU {
			get {
				return sku;
			}
			set {
				if (value < 9000) {
					throw new ArgumentException("The value must be over 9000.");
				}
				sku = value;
			}
		}

		/// <summary>
		/// The year.
		/// </summary>
		private int year;

		/// <summary>
		/// Gets or sets the year.
		/// </summary>
		/// <value>The year.</value>
		public int Year {
			get {
				return year;
			}
			set {
				if (value < 1996 || value > 2020) {
					throw new ArgumentException("The year must be between 1996 and 2020");
				}
				year = value;
			}
		}

		public string Title, Genre, Editor;

		public double AmericanSales, EuropeanSales, JapanSales, RestOfTheWorldSales;

		public RWPlatformEnum Platform;

		/// <summary>
		/// Initializes a new instance of the <see cref="T:willyOS.RWVideogame"/> class.
		/// </summary>
		public RWVideogame(int SKU, string Title, RWPlatformEnum Platform, int Year,
						   string Genre, string Editor, double AmericanSales = 0.0,
						   double EuropeanSales = 0.0, double JapanSales = 0.0,
						   double RestOfTheWorldSales = 0.0) {
			this.SKU = SKU;
			this.Title = Title;
			this.Platform = Platform;
			this.Year = Year;
			this.Genre = Genre;
			this.Editor = Editor;
			this.AmericanSales = AmericanSales;
			this.EuropeanSales = EuropeanSales;
			this.JapanSales = JapanSales;
			this.RestOfTheWorldSales = RestOfTheWorldSales;
		}
	}
}
