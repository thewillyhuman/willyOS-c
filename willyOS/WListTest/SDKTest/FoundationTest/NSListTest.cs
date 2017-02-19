using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace willyOS.tests {


	public class NSListTest {

		NSList<int> intList;
		NSList<String> stringList;
		// NSList<NSList<NSList<int>>> hiDegreeList;

		[SetUp]
		public void BeforeEachTest() {
			intList = new NSList<int>();
			stringList = new NSList<String>();
			// hiDegreeList = new NSList<NSList<NSList<int>>>();
		}

		[Test]
		public void AddTest() {
			Assert.AreEqual(0, intList.Count);
			Assert.AreEqual(0, stringList.Count);

			for (int i = 0; i < 1000; i++) {
				intList.Add(i);
				stringList.Add("a");
				Assert.AreEqual(i + 1, intList.Count);
				Assert.AreEqual(i + 1, stringList.Count);
			}
		}

		[Test]
		public void GetTest() {
			try {
				Assert.AreEqual(-1, intList[-1]);
				Assert.Fail();
			} catch (IndexOutOfRangeException) { }

			for (int i = 0; i < 1000; i++) {
				intList.Add(i);
				stringList.Add("a");
				Assert.AreEqual(i, intList[i]);
				Assert.AreEqual("a", stringList[i]);
			}
		}

		[Test]
		public void SetTest() {
			intList.Add(1);
			Assert.AreEqual(1, intList[0]);

			intList[0] = 2;
			Assert.AreEqual(2, intList[0]);

			intList.Clear();

			for (int i = 0; i < 1000; i++) {
				intList.Add(i);
				Assert.AreEqual(i, intList[i]);
				intList[i] = i + 1;
				Assert.AreEqual(i + 1, intList[i]);
			}
		}

		[Test]
		public void ContainsTest() {
			intList.Add(1);
			Assert.AreEqual(false, intList.Contains(-1));
			Assert.AreEqual(false, intList.Contains(0));
			Assert.AreEqual(true, intList.Contains(1));
			Assert.AreEqual(false, intList.Contains(2));
			stringList.Add("a");
			Assert.AreEqual(false, stringList.Contains("A"));
			Assert.AreEqual(false, stringList.Contains("b"));
			Assert.AreEqual(true, stringList.Contains("a"));
			Assert.AreEqual(false, stringList.Contains("c"));

			for (int i = 2; i < 1000; i++) {
				intList.Add(i);
				Assert.AreEqual(true, intList.Contains(i));
			}
		}

		[Test]
		public void RemoveTest() {
			for (int i = 0; i < 1000; i++) {
				intList.Add(i);
			}
			Assert.AreEqual(1000, intList.Count);
			for (int i = 999; i > -1; i--) {
				intList.Remove(i);
			}
			Assert.AreEqual(0, intList.Count);

			intList.Add(321);
			Assert.AreEqual(1, intList.Count);
			Assert.AreEqual(true, intList.Contains(321));
			intList.Remove(321);
			Assert.AreEqual(false, intList.Contains(321));
		}

		[Test]
		public void ToStringTest() {
			Assert.AreEqual("List -> ", intList.ToString());

			intList.Add(2);
			Assert.AreEqual("List -> [2] -> ", intList.ToString());
			intList.Add(4);
			Assert.AreEqual("List -> [2] -> [4] -> ", intList.ToString());

			intList.Remove(2);
			Assert.AreEqual("List -> [4] -> ", intList.ToString());

			stringList.Add("a");
			Assert.AreEqual("List -> [a] -> ", stringList.ToString());
			stringList.Add("b");
			Assert.AreEqual("List -> [a] -> [b] -> ", stringList.ToString());

			stringList.Remove("a");
			Assert.AreEqual("List -> [b] -> ", stringList.ToString());
		}

		[Test]
		public void EnumeratorTest() {
			intList = new NSList<int>() { 1, 2, 3, 4, 5 };

			int expected = 1;
			foreach (int number in intList) {
				Assert.AreEqual(expected, number);
				expected++;
			}
		}

		[Test]
		public void CopyToTest() {
			intList = new NSList<int>() { 2, 2, 3, 4, 5 };
			var array = new int[2];
			array[0] = 1;
			array[1] = 2;
			intList.CopyTo(array, 0);

			for (int i = 0; i < intList.Count; i++) {
				Assert.AreEqual(array[i], intList[i]);
			}
		}

		[Test]
		public void SafeCopyToTest() {
			intList = new NSList<int>() { 2, 2, 3, 4, 5 };
			var array = new int[2];
			array[0] = 1;
			array[1] = 2;
			intList.SafeCopyTo(ref array, 4);

			for (int i = 0; i < intList.Count; i++) {
				Assert.AreEqual(array[i + 4], intList[i]);
			}
		}
	}
}