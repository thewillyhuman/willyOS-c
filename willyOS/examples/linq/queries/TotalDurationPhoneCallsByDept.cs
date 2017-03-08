using System;
using System.Linq;
using examples.linq;
using Foundation;

namespace examples {

	/// <summary>
	/// Total duration phone calls by dept.
	/// </summary>
	public class TotalDurationPhoneCallsByDept : IQuery {

		/// <summary>
		/// The model.
		/// </summary>
		Model _model;

		/// <summary>
		/// Initializes a new instance of the <see cref="T:examples.TotalDurationPhoneCallsByDept"/> class.
		/// </summary>
		public TotalDurationPhoneCallsByDept(Model model) {
			_model = model;
		}

		/// <summary>
		/// Execute this instance.
		/// </summary>
		public void execute() {
			// Show the greatest summation of phone call durations, in seconds, 
			// of the employees in the same department, together with the name of the department 
			// (it can be assumed that there is only one department fulfilling that condition)

			var phonecallsAndPeople = _model.PhoneCalls.Join(
				_model.Employees,
				call => call.SourceNumber,
				emp => emp.TelephoneNumber,
				(call, freak) => new {
					Freak = freak,
					Call = call
				}
			).GroupBy(dep => dep.Freak.Department.Name);

			NSDictionary<string, int> calls = new NSDictionary<string, int>();

			foreach (var dep in phonecallsAndPeople) {
				calls.Add(dep.Key, dep.Sum(s => s.Call.Seconds));
			}

			var ordered = calls.OrderByDescending(c => c.Value);
			Console.WriteLine(ordered.First().Key + " : " + ordered.First().Value);
		}
	}
}
