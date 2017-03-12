using System;
using System.Linq;

namespace examples.linq {

	/// <summary>
	/// Employees older than50.
	/// </summary>
	public class EmployeesOlderThan50 : IQuery {

		/// <summary>
		/// The model.
		/// </summary>
		Model _model;

		/// <summary>
		/// Initializes a new instance of the <see cref="T:examples.EmployeesOlderThan50"/> class.
		/// </summary>
		/// <param name="model">Model.</param>
		public EmployeesOlderThan50(Model model) {
			_model = model;
		}

		/// <summary>
		/// Execute this instance.
		/// </summary>
		public void execute() {
			var employees = _model.Employees;
			var employeesWith50 = _model.Employees.Where(e => e.Age > 50);
			var names = employeesWith50.Select(e => e.Name);

			Console.WriteLine("Employees:");
			Query.Show(names);
		}
	}
}
