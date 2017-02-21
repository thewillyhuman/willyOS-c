using System;
using System.Text;

namespace RWKit {

	/// <summary>
	/// Contract type.
	/// </summary>
	public enum ContractType { Partial = 4, Full = 8 }

	/// <summary>
	/// Real World Employee.
	/// </summary>
	public class RWEmployee : RWPerson {

		/// <summary>
		/// Gets or sets the number of hours.
		/// </summary>
		/// <value>The number of hours.</value>
		public ContractType NumberOfHours { get; set; }

		/// <summary>
		/// Gets or sets the first surname.
		/// </summary>
		/// <value>The first surname.</value>
		public string FirstSurname { get; set; }

		/// <summary>
		/// Gets or sets the second surname.
		/// </summary>
		/// <value>The second surname.</value>
		public string SecondSurname { get; set; }

		/// <summary>
		/// Gets or sets the nif.
		/// </summary>
		/// <value>The nif.</value>
		public string NIF { get; set; }

		/// <summary>
		/// Gets or sets the birth date.
		/// </summary>
		/// <value>The birth date.</value>
		public DateTime BirthDate { get; set; }

		/// <summary>
		/// Gets or sets the comments.
		/// </summary>
		/// <value>The comments.</value>
		public string Comments { get; set; }

		/// <summary>
		/// The identifier.
		/// </summary>
		private int _id;

		/// <summary>
		/// Gets or sets the identifier.
		/// </summary>
		/// <value>The identifier.</value>
		public int ID {
			get {
				return _id;
			}
			set {
				if (value > 0) {
					_id = value;
				}
			}
		}

		//Non-parameter constructor is needed to allow Property-based construction
		public RWEmployee() {
			Comments = "";
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="T:willyOS.RWEmployee"/> class.
		/// </summary>
		/// <param name="name">Name.</param>
		/// <param name="NIF">Nif.</param>
		/// <param name="numberOfHours">Number of hours.</param>
		public RWEmployee(string name, string NIF, ContractType numberOfHours) {
			Name = name;
			NumberOfHours = numberOfHours;
			this.NIF = NIF;
			Comments = "";
		}

		/// <summary>
		/// Wage the specified daysWorked and pricePerHour.
		/// </summary>
		/// <returns>The wage.</returns>
		/// <param name="daysWorked">Days worked.</param>
		/// <param name="pricePerHour">Price per hour.</param>
		public double Wage(int daysWorked, double pricePerHour) {
			return Math.Round(daysWorked * pricePerHour * (int)NumberOfHours);
		}

		/// <summary>
		/// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:willyOS.RWEmployee"/>.
		/// </summary>
		/// <returns>A <see cref="T:System.String"/> that represents the current <see cref="T:willyOS.RWEmployee"/>.</returns>
		public override string ToString() {
			StringBuilder sb = new StringBuilder();

			sb.Append("Name: " + Name);
			sb.Append("; ");
			sb.Append("FirstSurname: " + FirstSurname);
			sb.Append("; ");
			sb.Append("SecondSurname: " + SecondSurname);
			sb.Append("; ");
			sb.Append("NIF: " + NIF);
			sb.Append("; ");
			sb.Append("BirthDate: " + BirthDate);
			sb.Append("; ");
			sb.Append("NumberOfHours: " + NumberOfHours);
			sb.Append("; ");
			sb.Append("Comments: " + Comments);
			sb.Append(";\n");

			return sb.ToString();
		}

		/// <summary>
		/// Determines whether the specified <see cref="object"/> is equal to the current <see cref="T:willyOS.RWEmployee"/>.
		/// </summary>
		/// <param name="obj">The <see cref="object"/> to compare with the current <see cref="T:willyOS.RWEmployee"/>.</param>
		/// <returns><c>true</c> if the specified <see cref="object"/> is equal to the current <see cref="T:willyOS.RWEmployee"/>;
		/// otherwise, <c>false</c>.</returns>
		public override bool Equals(object obj) {
			RWEmployee person = obj as RWEmployee;
			if (person == null)
				return false;
			return Name.Equals(person.Name);
		}

		/// <summary>
		/// Serves as a hash function for a <see cref="T:willyOS.RWEmployee"/> object.
		/// </summary>
		/// <returns>A hash code for this instance that is suitable for use in hashing algorithms and data structures such as a hash table.</returns>
		public override int GetHashCode() {
			return Name.GetHashCode();
		}
	}
}
