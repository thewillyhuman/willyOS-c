using System;
using System.Linq;

namespace examples.linq {

	/// <summary>
	/// Total duration CSD ept.
	/// </summary>
	public class TotalDurationCSDept : IQuery {

		/// <summary>
		/// The model.
		/// </summary>
		Model _model;

		/// <summary>
		/// Initializes a new instance of the <see cref="T:examples.TotalDurationCSDept"/> class.
		/// </summary>
		public TotalDurationCSDept(Model model) {
			_model = model;
		}

		/// <summary>
		/// Execute this instance.
		/// </summary>
		public void execute() {
			var callsByFreak = _model.PhoneCalls.Join(
				_model.Employees.Where(e => e.Department.Name.Equals("Computer Science")),
				call => call.SourceNumber,
				emp => emp.TelephoneNumber,
				(call, freak) => new {
					freak.Name,
					Duration = call.Seconds
				}
			).Sum(call => call.Duration);

			Console.WriteLine("Total amount of calls by the IT Dept: {0}", callsByFreak);
		}
	}
}
