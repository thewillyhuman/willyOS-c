using System;
using CoreServices;
using Foundation;
using NUnit.Framework;
using RWKit;

namespace willyOS.tests {

	public class CSFunctionsTest {

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

		[Test]
		public void FilterTest() {
			for (int i = 0; i < 1000; i++) {
				list.Add(i);
			}
			var result = new int[] { 0, 1, 2 };
			Assert.AreEqual(result, CSFunctions.Filter(n => n < 3, list));

			var FILTER_ARGUMENT = 500;
			result = new int[FILTER_ARGUMENT];
			for (int i = 0; i < 1000; i++) {
				if (i < FILTER_ARGUMENT) {
					result[i] = i;
				}
			}
			Assert.AreEqual(result, CSFunctions.Filter(n => n < FILTER_ARGUMENT, list));
		}

		[Test]
		public void ReduceTest() {
			var result = new int[] { 0, 1, 2, 3 };
			int i = 0;
			int temp = 0;
			Assert.AreEqual(6, CSFunctions.Reduce((e1, e2) => e1 + e2, result, i));

			for (i = 0; i < 1000; i++) {
				list.Add(i);
				temp += i;
			}
			i = 0;
			Assert.AreEqual(temp, CSFunctions.Reduce((e1, e2) => e1 + e2, list, i));
		}
	}
}