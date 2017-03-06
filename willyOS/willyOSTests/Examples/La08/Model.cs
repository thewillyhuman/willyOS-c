using System;
using System.Collections.Generic;
using RWKit;

namespace willyOS.tests.examples {


	public class Model {

		public IList<RWDepartment> Departments { get { return departments; } }
		public IList<RWEmployee> Employees { get { return employees; } }
		public IList<RWOffice> Offices { get { return offices; } }
		public IList<RWPhoneCall> PhoneCalls { get { return phoneCalls; } }


		static Model() {
			ResetModel();
		}

		private static void ResetModel() {

			offices = new List<RWOffice> {
				new RWOffice("2.1", "Faculty of Science"),
				new RWOffice("2.2", "Faculty of Science"),
				new RWOffice("2.1", "Polytechnical"),
				new RWOffice("3.1", "Headquarters"),
				new RWOffice("2.1", "Headquarters")
				};

			employees = new List<RWEmployee> {
				new RWEmployee ("Alvaro", "Alvarez", new DateTime(1945,10,19), "985 001", "alvaro@uniovi.es", "Cantabria", offices[0] ),
				new RWEmployee ("Bernardo", "Bernardez", new DateTime(1973,12,09), "985 002", "bernardo@uniovi.es", "Asturias", offices[1]),
				new RWEmployee ("Carlos", "Carlez", new DateTime(1969,10,03), "985 003", "carlos@uniovi.es", "Alicante", offices[4]),
				new RWEmployee ("Dario", "Dariez", new DateTime(1973,12,16), "100 004", "dario@uniovi.es", "Cantabria", offices[2]),
				new RWEmployee ("Eduardo", "Eduardez", new DateTime(1945,02,10), "985 005", "eduardo@uniovi.es", "Granada", offices[2]),
				new RWEmployee ("Felipe", "Felipez", new DateTime(1950,02,20), "985 006", "felipe@uniovi.es", "Asturias", offices[1]),
				};

			departments = new List<RWDepartment> {
				new RWDepartment ( "Mathematics", new List<RWEmployee> {employees[4]} ),
				new RWDepartment ( "Computer Science",new List<RWEmployee> {employees[1], employees[2]}),
				new RWDepartment ( "Medicine",new List<RWEmployee> {employees[0], employees[3]}),
				new RWDepartment ( "Physics",new List<RWEmployee> {employees[5]}),
				};

			employees[4].Department = departments[0];
			employees[1].Department = employees[2].Department = departments[1];
			employees[0].Department = employees[3].Department = departments[2];
			employees[5].Department = departments[3];

			phoneCalls = new List<RWPhoneCall> {
				new RWPhoneCall { SourceNumber = "985 001", DestinationNumber = "100 000", Seconds = 02, Date = new DateTime(2011,    1,  7,  8,  12, 0)},
				new RWPhoneCall { SourceNumber = "985 001", DestinationNumber = "200 000", Seconds = 15, Date = new DateTime(2011,    1,  7,  13, 12, 0) },
				new RWPhoneCall { SourceNumber = "100 000", DestinationNumber = "985 005", Seconds = 15, Date = new DateTime(2011,    2,  7,  9,  23, 0) },
				new RWPhoneCall { SourceNumber = "200 000", DestinationNumber = "985 002", Seconds = 01, Date = new DateTime(2011,    2,  7,  10, 5,  0) },
				new RWPhoneCall { SourceNumber = "985 005", DestinationNumber = "100 000", Seconds = 23, Date = new DateTime(2011,    3,  8,  10, 40, 0) },
				new RWPhoneCall { SourceNumber = "985 002", DestinationNumber = "985 001", Seconds = 63, Date = new DateTime(2011,    3,  8,  14, 0,  0) },
				new RWPhoneCall { SourceNumber = "985 002", DestinationNumber = "985 005", Seconds = 07, Date = new DateTime(2011,    4,  8,  14, 37, 0) },
				new RWPhoneCall { SourceNumber = "100 000", DestinationNumber = "985 001", Seconds = 20, Date = new DateTime(2011,    4,  8,  17, 12, 0) },
				new RWPhoneCall { SourceNumber = "985 001", DestinationNumber = "985 006", Seconds = 05, Date = new DateTime(2011,    5,  12, 8,  12, 0)},
				new RWPhoneCall { SourceNumber = "985 005", DestinationNumber = "985 001", Seconds = 22, Date = new DateTime(2011,    5,  5,  10, 35, 0) },
				new RWPhoneCall { SourceNumber = "985 001", DestinationNumber = "985 002", Seconds = 10, Date = new DateTime(2011,    6,  7,  13, 12, 0) },
				new RWPhoneCall { SourceNumber = "985 006", DestinationNumber = "985 001", Seconds = 07, Date = new DateTime(2011,    6,  7,  20, 34, 0) },
				new RWPhoneCall { SourceNumber = "985 005", DestinationNumber = "985 005", Seconds = 03, Date = new DateTime(2011,    7,  8,  10, 40, 0) },
				new RWPhoneCall { SourceNumber = "985 002", DestinationNumber = "985 001", Seconds = 32, Date = new DateTime(2011,    7,  8,  14, 0,  0) },
			};
		}

		private static List<RWDepartment> departments;
		private static List<RWEmployee> employees;
		private static List<RWOffice> offices;
		private static List<RWPhoneCall> phoneCalls;
	}
}