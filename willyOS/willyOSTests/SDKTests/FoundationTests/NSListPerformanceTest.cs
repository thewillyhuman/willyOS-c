using System;
using Foundation;
using NUnit.Framework;

namespace willyOS.tests {

	/// <summary>
	/// Next Step List performance test.
	/// </summary>
	public class NSListPerformanceTest {

		/// <summary>
		/// The list.
		/// </summary>
		NSList<int> list;

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

			Console.WriteLine("Time to add 100000 elements: {0}", (DateTime.Now - StartTime).TotalSeconds);
		}

		[Test]
		public void RemovePerformanceTest() {
			for (int i = 0; i < 100000; i++) {
				list.Add(i);
				//Console.WriteLine(i + " " + list.Containss(i));
			}

			var StartTime = DateTime.Now;

			for (int i = 0; i < 100000; i++) {
				//Assert.AreEqual(true, list.Containss(i));
				//Assert.AreEqual(true, list.Contains(i));
				//Assert.AreEqual(true, list.Containss(i));
				list.Remove(i);
			}

			Console.WriteLine("Time to remove 100000 elements: {0}", (DateTime.Now - StartTime).TotalSeconds);
		}

		[Test]
		public void ContainsPerformanceTest() {
			list = new NSList<int>();
			for (int i = 0; i < 100000; i++) {
				list.Add(i);
			}

			var StartTime = DateTime.Now;

			for (int i = (100000 - 1); i >= 0; i--) {
				Assert.AreEqual(true, list.Contains(i));
			}

			list[0] = -222;
			Assert.AreEqual(true, list.Contains(-222));
			list.Remove(-222);
			Assert.AreEqual(false, list.Contains(-222));
			list[1] = 10;
			Assert.AreEqual(1, list.IndexOf(10));
			Console.WriteLine("Time to check that contains all 100000 elements: {0}", (DateTime.Now - StartTime).TotalSeconds);
		}
	}
}
