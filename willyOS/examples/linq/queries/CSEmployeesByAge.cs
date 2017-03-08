using System;
using System.Linq;

namespace examples.linq {

	/// <summary>
	/// CSE mployees by age.
	/// </summary>
	public class CSEmployeesByAge : IQuery {

		Model _model;

		/// <summary>
		/// Initializes a new instance of the <see cref="T:examples.linq.CSEmployeesByAge"/> class.
		/// </summary>
		public CSEmployeesByAge(Model model) {
			_model = model;
		}

		/// <summary>
		/// Execute this instance.
		/// </summary>
		public void execute() {
			var calls = _model.PhoneCalls.Where(call => call.Seconds > 60).Join(
				_model.Employees.Where(
					d => d.Office.Building.Equals("Faculty of Science") &&
					d.Department.Name.Equals("Computer Science")),
				call => call.SourceNumber,
				emp => emp.TelephoneNumber,
				(call, emp) => new {
					emp.Name,
					emp.Age
				}
			).OrderBy(emp => emp.Age);

			Query.Show(calls);
		}
	}
}
