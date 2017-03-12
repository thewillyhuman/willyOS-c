using System;
using System.Linq;

namespace examples.linq {

	/// <summary>
	/// Name and email asturias workers.
	/// </summary>
	public class NameAndEmailAsturiasWorkers : IQuery {

		/// <summary>
		/// The model.
		/// </summary>
		Model _model;

		/// <summary>
		/// Initializes a new instance of the <see cref="T:examples.linq.NameAndEmailAsturiasWorkers"/> class.
		/// </summary>
		/// <param name="model">Model.</param>
		public NameAndEmailAsturiasWorkers(Model model) {
			_model = model;
		}

		/// <summary>
		/// Execute this instance.
		/// </summary>
		public void execute() {
			var employees = _model.Employees.Where(e => e.Province.Equals("Asturias")).Select(e => new {
				e.Name,
				e.Email,
				e.Age
			});

			Console.WriteLine("Employees:");
			Query.Show(employees);
		}
	}
}
