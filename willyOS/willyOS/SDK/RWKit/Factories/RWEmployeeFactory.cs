using System;

namespace willyOS {
	public class RWEmployeeFactory {

		static DateTime RandomDate() {
			DateTime start = new DateTime(1978, 1, 1);
			Random gen = new Random();

			int range = (DateTime.Today - start).Days;
			return start.AddDays(gen.Next(range));
		}

		/// <summary>
		/// Creates a random Employee array
		/// </summary>
		/// <returns>An employee array</returns>
		public static RWEmployee[] CreateEmployees(int numEmployees = 100) {
			string[] names = { "María", "Juan", "Pepe", "Luis", "Carlos", "Miguel", "Cristina" };
			string[] surnames = { "Díaz", "Pérez", "Hevia", "García", "Rodríguez", "Pérez", "Sánchez" };

			RWEmployee[] listing = new RWEmployee[numEmployees];
			Random random = new Random();
			for (int i = 0; i < numEmployees; i++)
				listing[i] = new RWEmployee {
					Name = names[random.Next(0, names.Length)],
					FirstSurname = surnames[random.Next(0, surnames.Length)],
					SecondSurname = surnames[random.Next(0, surnames.Length)],
					NIF = random.Next(9000000, 90000000) + "-" + (char)random.Next('A', 'Z'),
					NumberOfHours = i % 2 == 0 ? ContractType.Full : ContractType.Partial,
					ID = i,
					BirthDate = RandomDate(),
					Comments = RAWordGenerator.GenerateRandomText()
				};

			return listing;
		}

	}

}

