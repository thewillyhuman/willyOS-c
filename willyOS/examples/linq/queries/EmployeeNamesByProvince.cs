using System;
using System.Linq;

namespace examples.linq {

	/// <summary>
	/// Employee names by province.
	/// </summary>
	public class EmployeeNamesByProvince : IQuery {

		/// <summary>
		/// The model.
		/// </summary>
		Model _model;

		/// <summary>
		/// Initializes a new instance of the <see cref="T:examples.linq.EmployeeNamesByProvince"/> class.
		/// </summary>
		/// <param name="model">Model.</param>
		public EmployeeNamesByProvince(Model model) {
			_model = model;
		}

		/// <summary>
		/// Show, ordered by age, the names of the employees in the Computer Science department,  
		/// who have an office in the Faculty of Science,  and who have done phone calls longer than one minute.
		/// </summary>
		public void execute() {
			var groups = _model.Employees.GroupBy(e => e.Province);
			var ordered = groups.OrderBy(g => g.Key);

			foreach (var group in ordered) {
				Console.WriteLine(group.Key);
				var orderedEmployees = group.OrderBy(e => e.Name);
				foreach (var emp in orderedEmployees) {
					Console.WriteLine("\t" + emp.Name);
				}
			}
		}
	}
}
