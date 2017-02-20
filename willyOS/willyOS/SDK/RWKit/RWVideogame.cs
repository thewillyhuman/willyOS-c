using System;

namespace willyOS {

	/// <summary>
	/// RWP latform enum.
	/// </summary>
	public enum VidegamePlatform {
		PS3, Xbox360, Wii
	}

	/// <summary>
	/// Real World Videogame.
	/// </summary>
	public class RWVideogame {

		/// <summary>
		/// The sku.
		/// </summary>
		private int _sku;

		/// <summary>
		/// Gets or sets the sku.
		/// </summary>
		/// <value>The sku.</value>
		public int SKU {
			get {
				return _sku;
			}
			set {
				if (value > 9000) {
					_sku = value;
				}
			}
		}

		/// <summary>
		/// Gets or sets the available units.
		/// </summary>
		/// <value>The available units.</value>
		public int AvailableUnits { get; set; }

		/// <summary>
		/// Gets or sets the title.
		/// </summary>
		/// <value>The title.</value>
		public string Title { get; set; }

		/// <summary>
		/// Gets or sets the platform.
		/// </summary>
		/// <value>The platform.</value>
		public VidegamePlatform Platform { get; set; }

		/// <summary>
		/// The year.
		/// </summary>
		private int _year;

		/// <summary>
		/// Gets or sets the year.
		/// </summary>
		/// <value>The year.</value>
		public int Year {
			get {
				return _year;
			}
			set {
				if (value >= 1996 && value <= 2020)
					_year = value;
				else {
					throw new ArgumentException(value.ToString());
				}
			}
		}

		/// <summary>
		/// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:willyOS.RWVideogame"/>.
		/// </summary>
		/// <returns>A <see cref="T:System.String"/> that represents the current <see cref="T:willyOS.RWVideogame"/>.</returns>
		public override string ToString() {
			return string.Format("AvailableUnits: {0}, Title: {1}, Platform: {2}, Year: {3}, Genre: {4}, Editor: {5}, AmericaSales: {6}, EuropeSales: {7}, RestOfTheWorldSales: {8}\n\n", AvailableUnits, Title, Platform, Year, Genre, Editor, AmericaSales, EuropeSales, RestOfTheWorldSales);
		}

		/// <summary>
		/// Gets or sets the genre.
		/// </summary>
		/// <value>The genre.</value>
		public string Genre { get; set; }

		/// <summary>
		/// Gets or sets the editor.
		/// </summary>
		/// <value>The editor.</value>
		public string Editor { get; set; }

		/// <summary>
		/// Gets or sets the america sales.
		/// </summary>
		/// <value>The america sales.</value>
		public double AmericaSales { get; set; }

		/// <summary>
		/// Gets or sets the europe sales.
		/// </summary>
		/// <value>The europe sales.</value>
		public double EuropeSales { get; set; }

		/// <summary>
		/// Gets or sets the japan sales.
		/// </summary>
		/// <value>The japan sales.</value>
		public double JapanSales { get; set; }

		/// <summary>
		/// Gets or sets the rest of the world sales.
		/// </summary>
		/// <value>The rest of the world sales.</value>
		public double RestOfTheWorldSales { get; set; }

		/// <summary>
		/// Determines whether the specified <see cref="object"/> is equal to the current <see cref="T:willyOS.RWVideogame"/>.
		/// </summary>
		/// <param name="obj">The <see cref="object"/> to compare with the current <see cref="T:willyOS.RWVideogame"/>.</param>
		/// <returns><c>true</c> if the specified <see cref="object"/> is equal to the current <see cref="T:willyOS.RWVideogame"/>;
		/// otherwise, <c>false</c>.</returns>
		public override bool Equals(object obj) {
			RWVideogame videogame = obj as RWVideogame;
			if (videogame == null)
				return false;
			return Title.Equals(videogame.Title);
		}

		/// <summary>
		/// Serves as a hash function for a <see cref="T:willyOS.RWVideogame"/> object.
		/// </summary>
		/// <returns>A hash code for this instance that is suitable for use in hashing algorithms and data structures such as a hash table.</returns>
		public override int GetHashCode() {
			return Title.GetHashCode();
		}
	}
}
