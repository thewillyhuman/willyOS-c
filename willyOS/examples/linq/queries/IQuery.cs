using System;
namespace examples.linq {

	/// <summary>
	/// Defines the entry point for every query.
	/// </summary>
	public interface IQuery {

		/// <summary>
		/// Execute this instance.
		/// </summary>
		void execute();
	}
}
