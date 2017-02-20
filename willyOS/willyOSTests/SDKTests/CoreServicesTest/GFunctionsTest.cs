using System;
using NUnit.Framework;

namespace willyOS.tests {

	public class GFunctionsTest {

		NSList<int> list;
		RWEmployee[] employees;

		[SetUp]
		public void BeforeEachTest() {
			list = new NSList<int>();
			employees = RWEmployeeFactory.CreateEmployees(100);
		}

		[Test]
		public void FindTest() {
			for (int i = 0; i < 1000; i++) {
				list.Add(i);
			}

			for (int i = 0; i < 1000; i++) {
				Assert.AreEqual(i, CSFunctions.Find(n => n == i, list));
			}
			var employee = RWEmployeeFactory.CreateEmployees(1);
			employee[0].Name = "Willy";
			employee[0].NIF = "112233-P";

			employees[0] = employee[0];
			Assert.AreEqual(employee[0].Name, CSFunctions.Find(n => n.Name == employee[0].Name, employees).Name);
			Assert.AreEqual(employee[0].NIF, CSFunctions.Find(n => n.NIF.EndsWith("P", StringComparison.Ordinal), employees).NIF);

		}
	}
}
