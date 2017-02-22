using System;
using System.Collections.Generic;
using Foundation;
using NUnit.Framework;

namespace willyOS.tests {

	/// <summary>
	/// Next Step List performance test.
	/// </summary>
	public class NSListPerformanceTest {

		IList<int> list;

		[SetUp]
		public void BeforeTest() {
			list = new NSList<int>();
		}

		[Test]
		public void AddPerformanceTest() {

			var StartTime = DateTime.Now;

			for (int i = 0; i < 100000; i++) {
				list.Add(i);
			}

			Console.WriteLine("Time to add 1000000 elements: {0}", (DateTime.Now - StartTime).TotalSeconds);
		}

		[Test]
		public void RemovePerformanceTest() {
			for (int i = 0; i < 100000; i++) {
				list.Add(i);
			}

			var StartTime = DateTime.Now;

			for (int i = 0; i < 100000; i++) {
				list.Remove(i);
			}

			Console.WriteLine("Time to remove 1000000 elements: {0}", (DateTime.Now - StartTime).TotalSeconds);
		}

		[Test]
		public void ContainsPerformanceTest() {
			for (int i = 0; i < 100000; i++) {
				list.Add(i);
			}

			var StartTime = DateTime.Now;

			for (int i = (10000 - 1); i >= 0; i--) {
				Assert.AreEqual(true, list.Contains(i));
			}

			Console.WriteLine("Time to check that contains all 1000000 elements: {0}", (DateTime.Now - StartTime).TotalSeconds * (1000000 / 10000));
		}

	}
}
