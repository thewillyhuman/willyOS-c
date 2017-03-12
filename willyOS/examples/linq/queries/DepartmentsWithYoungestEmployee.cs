using System;
using System.Linq;

namespace examples.linq {

	/// <summary>
	/// Departments with youngest employee.
	/// </summary>
	public class DepartmentsWithYoungestEmployee : IQuery {

		/// <summary>
		/// The model.
		/// </summary>
		Model _model;

		/// <summary>
		/// Initializes a new instance of the <see cref="T:examples.linq.DepartmentsWithYoungestEmployee"/> class.
		/// </summary>
		/// <param name="model">Model.</param>
		public DepartmentsWithYoungestEmployee(Model model) {
			_model = model;
		}

		/// <summary>
		/// Execute this instance.
		/// </summary>
		public void execute() {
			var youngest = _model.Employees.Where(e => e.Age.Equals(_model.Employees.Min().Age));
			foreach (var p in youngest) {
				Console.WriteLine(p.Department + " : " + p.Name + "  " + p.Age);
			}
		}
	}
}
