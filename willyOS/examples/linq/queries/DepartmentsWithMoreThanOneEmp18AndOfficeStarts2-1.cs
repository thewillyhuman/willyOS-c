using System;
using System.Linq;

namespace examples.linq {

	/// <summary>
	/// Departments with more than one emp18 and office starts2.
	/// </summary>
	public class DepartmentsWithMoreThanOneEmp18AndOfficeStarts2 : IQuery {

		/// <summary>
		/// The model.
		/// </summary>
		Model _model;

		/// <summary>
		/// Initializes a new instance of the <see cref="T:examples.linq.DepartmentsWithMoreThanOneEmp18AndOfficeStarts2"/> class.
		/// </summary>
		/// <param name="model">Model.</param>
		public DepartmentsWithMoreThanOneEmp18AndOfficeStarts2(Model model) {
			_model = model;
		}

		/// <summary>
		/// Execute this instance.
		/// </summary>
		public void execute() {
			var employees = _model.Departments.Where(
				d => d.Employees.Count(
					e => e.Age > 18
					) > 1
					).Where(
				d => d.Employees.Any(
					e => e.Office.Number.StartsWith("2.1", StringComparison.Ordinal))).Count();

			Console.WriteLine("Employees:" + employees);
			//Show(employees);
		}
	}
}
