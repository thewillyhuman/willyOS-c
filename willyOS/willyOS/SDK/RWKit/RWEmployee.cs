using System;
namespace willyOS {
	public class RWEmployee : RWPerson {

		/// <summary>
		/// The surname.
		/// </summary>
		private string surname1, surname2;

		/// <summary>
		/// The identifier.
		/// </summary>
		public uint Id;

		/// <summary>
		/// Gets or sets the surname.
		/// </summary>
		/// <value>The surname.</value>
		public string Surname1 {
			get {
				return surname1;
			}
			set {
				if (value == null)
					throw new ArgumentException("The name cannot be null.");
				this.surname1 = value;
			}
		}

		/// <summary>
		/// Gets or sets the surname.
		/// </summary>
		/// <value>The surname.</value>
		public string Surname2 {
			get {
				return surname2;
			}
			set {
				if (value == null)
					throw new ArgumentException("The name cannot be null.");
				this.surname2 = value;
			}
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="T:willyOS.RWEmployee"/> class.
		/// </summary>
		/// <param name="Id">Identifier.</param>
		/// <param name="Name">Name.</param>
		/// <param name="Surname1">Surname.</param>
		/// <param name="Surname2">Surname.</param>
		/// <param name="Age">Age.</param>
		public RWEmployee(uint Id, string Name = "", string Surname1 = "", string Surname2 = "", uint Age = 0) {
			this.Name = Name;
			this.Surname1 = Surname1;
			this.Surname2 = Surname2;
			this.Age = Age;
			this.Id = Id;
		}
	}
}
