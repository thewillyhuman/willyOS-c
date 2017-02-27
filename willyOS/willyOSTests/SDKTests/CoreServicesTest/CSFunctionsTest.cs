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
				Assert.AreEqual(i, list.Find(n => n == i));
			}
			var employee = RWEmployeeFactory.CreateEmployees(1);
			employee[0].Name = "Willy";
			employee[0].NIF = "112233-P";

			employees[0] = employee[0];
			Assert.AreEqual(employee[0].Name, employee.Find(n => n.Name == employee[0].Name).Name);
			Assert.AreEqual(employee[0].NIF, employee.Find(n => n.NIF.EndsWith("P", StringComparison.Ordinal)).NIF);
		}

		[Test]
		public void FilterTest() {
			for (int i = 0; i < 1000; i++) {
				list.Add(i);
			}
			var result = new int[] { 0, 1, 2 };
			Assert.AreEqual(result, list.Filter(n => n < 3));

			var FILTER_ARGUMENT = 500;
			result = new int[FILTER_ARGUMENT];
			for (int i = 0; i < 1000; i++) {
				if (i < FILTER_ARGUMENT) {
					result[i] = i;
				}
			}
			Assert.AreEqual(result, list.Filter(n => n < FILTER_ARGUMENT));
		}

		[Test]
		public void ReduceTest() {
			var result = new int[] { 0, 1, 2, 3 };
			int i = 0;
			Assert.AreEqual(6, result.Reduce((e1, e2) => e1 + e2, i));

			int temp = 0;
			for (i = 0; i < 1000; i++) {
				list.Add(i);
				temp += i;
			}
			i = 0;
			Assert.AreEqual(temp, list.Reduce((e1, e2) => e1 + e2, i));
		}

		[Test]
		public void InverseTest() {
			list = new NSList<int> { 1, 2, 3, 4 };

			var expected = 4;
			foreach (var el in list.Inverse()) {
				Assert.AreEqual(expected, el);
				expected--;
			}
			var result = new int[] { 0, 1, 2, 3, 4 };
			expected = 4;
			foreach (var el in result.Inverse()) {
				Console.WriteLine(el);
				Assert.AreEqual(expected, el);
				expected--;
			}
		}

		[Test]
		public void MapTest() {
			for (int i = 0; i < 10000; i++) {
				list.Add(i);
			}

			int j = 0;
			foreach (var el in list.Map(n => n = n * 2)) {
				Assert.AreEqual(list[j] * 2, el);
				j++;
			}
		}

		[Test]
		public void InvertedMapTest() {
			for (int i = 0; i < 10000; i++) {
				list.Add(i);
			}
			int count = 0;
			foreach (var el in list.Inverse().Map(n => n = n * 2)) {
				Assert.AreEqual(list[list.Count - 1 - count] * 2, el);
				count++;
			}
		}

		[Test]
		public void InvertedReduceTest() {
			var result = new int[] { 0, 1, 2, 3 };
			int i = 0;
			Assert.AreEqual(6, result.Reduce((e1, e2) => e1 + e2, i));

			int temp = 0;
			for (i = 0; i < 1000; i++) {
				list.Add(i);
				temp += i;
			}
			int j = 0;
			Assert.AreEqual(temp, list.Inverse().Reduce((e1, e2) => e2 + e1, j));
		}
	}
}