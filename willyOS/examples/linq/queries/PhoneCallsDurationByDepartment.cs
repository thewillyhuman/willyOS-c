using System;
using System.Linq;

namespace examples.linq {

	/// <summary>
	/// Phone calls duration by department.
	/// </summary>
	public class PhoneCallsDurationByDepartment : IQuery {

		Model _model;
		/// <summary>
		/// Initializes a new instance of the <see cref="T:examples.linq.PhoneCallsDurationByDepartment"/> class.
		/// </summary>
		public PhoneCallsDurationByDepartment(Model model) {
			_model = model;
		}

		/// <summary>
		/// Execute this instance.
		/// </summary>
		public void execute() {
			var phonecallsAndPeople = _model.PhoneCalls.Join(
				_model.Employees,
				call => call.SourceNumber,
				emp => emp.TelephoneNumber,
				(call, freak) => new {
					Freak = freak,
					Call = call
				}
			).GroupBy(dep => dep.Freak.Department.Name);

			foreach (var dep in phonecallsAndPeople) {
				Console.WriteLine(dep.Key);
				var sum = dep.Sum(s => s.Call.Seconds);
				Console.WriteLine("\t" + sum);
			}
		}
	}
}
