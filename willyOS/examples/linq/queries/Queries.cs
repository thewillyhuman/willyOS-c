using System;
using System.Collections.Generic;
using System.Linq;
using Foundation;

namespace examples.linq {

	class Query {

		private static Model model = new Model();

		public static void Show<T>(IEnumerable<T> collection) {
			foreach (var item in collection) {
				Console.WriteLine(item);
			}
			Console.WriteLine("Number of items in the collection: {0}.", collection.Count());
		}

		static void Main(string[] args) {
			IQuery query = new EmployeesOlderThan50(model);
			query.execute();

			query = new NameAndEmailAsturiasWorkers(model);
			query.execute();

			query = new DepartmentsWithMoreThanOneEmp18AndOfficeStarts2(model);
			query.execute();

			query = new PhoneCallsByEmployee(model);
			query.execute();

			query = new PhoneCallsByEmployeeB(model);
			query.execute();

			query = new EmployeeNamesByProvince(model);
			query.execute();

			// Homework.

			query = new CSEmployeesByAge(model);
			query.execute();

			query = new TotalDurationCSDept(model);
			query.execute();

			query = new TotalDurationPhoneCallsByDept(model);
			query.execute();

			query = new DepartmentsWithYoungestEmployee(model);
			query.execute();

			query = new TotalDurationPhoneCallsByDept(model);
			query.execute();
		}
	}
}
