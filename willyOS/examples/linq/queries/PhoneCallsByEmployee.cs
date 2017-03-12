using System.Linq;

namespace examples.linq {

	/// <summary>
	/// Phone calls by employee.
	/// </summary>
	public class PhoneCallsByEmployee : IQuery {

		/// <summary>
		/// The model.
		/// </summary>
		Model _model;

		/// <summary>
		/// Initializes a new instance of the <see cref="T:examples.linq.PhoneCallsByEmployee"/> class.
		/// </summary>
		/// <param name="model">Model.</param>
		public PhoneCallsByEmployee(Model model) {
			_model = model;
		}

		/// <summary>
		/// Execute this instance.
		/// </summary>
		public void execute() {
			var result = _model.PhoneCalls.Where(
				call => _model.Employees.Any(
					e => e.TelephoneNumber.Equals(call.SourceNumber)));

			var result2 = result.Select(
				call => new {
					Duration = call.Seconds,
					Name = _model.Employees.First(e => e.TelephoneNumber.Equals(call.SourceNumber))
				});

			Query.Show(result2);
		}
	}
}
