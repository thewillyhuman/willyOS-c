using System.Linq;

namespace examples.linq {

	/// <summary>
	/// Phone calls by employee b.
	/// </summary>
	public class PhoneCallsByEmployeeB : IQuery {

		/// <summary>
		/// The model.
		/// </summary>
		Model _model;

		/// <summary>
		/// Initializes a new instance of the <see cref="T:examples.linq.PhoneCallsByEmployeeB"/> class.
		/// </summary>
		/// <param name="model">Model.</param>
		public PhoneCallsByEmployeeB(Model model) {
			_model = model;
		}

		/// <summary>
		/// Execute this instance.
		/// </summary>
		public void execute() {
			var result = _model.PhoneCalls.Join(
				_model.Employees,
				call => call.SourceNumber,
				emp => emp.TelephoneNumber,
				(call, emp) => new {
					emp.Name,
					Duration = call.Seconds
				});

			Query.Show(result);
		}
	}
}
