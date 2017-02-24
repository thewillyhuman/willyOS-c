using System;

namespace RWKit {

	/// <summary>
	/// Real World Person.
	/// </summary>
	public class RWPerson {

		/// <summary>
		/// The name.
		/// </summary>
		private string _name;

		/// <summary>
		/// Sets the name.
		/// </summary>
		/// <value>The name.</value>
		public string Name {
			get {
				return _name;
			}
			set {
				if (value == null)
					throw new ArgumentException("The name cannot be null.");
				_name = value;
			}
		}

		/// <summary>
		/// Sets the age.
		/// </summary>
		/// <value>The age.</value>
		public uint Age;

		public RWPerson(string Name = "", uint Age = 0) {
			this.Name = Name;
			this.Age = Age;
		}

		/// <summary>
		/// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:willyOS.RWPerson"/>.
		/// </summary>
		/// <returns>A <see cref="T:System.String"/> that represents the current <see cref="T:willyOS.RWPerson"/>.</returns>
		public override string ToString() {
			return string.Format("[RWPerson: Name={0}, Age={1}]", Name, Age);
		}
	}
}
