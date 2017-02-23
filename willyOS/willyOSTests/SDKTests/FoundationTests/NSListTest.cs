using System;
using System.Collections.Generic;
using Foundation;
using NUnit.Framework;

namespace willyOS.tests {

	/// <summary>
	/// NSList test.
	/// </summary>
	public class NSListTest {

		IList<int> intList;
		IList<string> stringList;
		// NSList<NSList<NSList<int>>> hiDegreeList;

		[SetUp]
		public void BeforeEachTest() {
			intList = new NSList<int>();
			stringList = new NSList<string>();
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
			Assert.AreEqual(false, intList.Contains(item: -1));
			Assert.AreEqual(false, intList.Contains(item: 0));
			Assert.AreEqual(true, intList.Contains(item: 1));
			Assert.AreEqual(false, intList.Contains(item: 2));
			stringList.Add("a");
			Assert.AreEqual(false, stringList.Contains(item: "A"));
			Assert.AreEqual(false, stringList.Contains(item: "b"));
			Assert.AreEqual(true, stringList.Contains(item: "a"));
			Assert.AreEqual(false, stringList.Contains(item: "c"));

			for (int i = 2; i < 1000; i++) {
				intList.Add(i);
				Assert.AreEqual(true, intList.Contains(item: i));
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
			Assert.AreEqual(true, intList.Contains(item: 321));
			intList.Remove(321);
			Assert.AreEqual(false, intList.Contains(item: 321));
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
			// Testing with some easy cases like integers.
			intList = new NSList<int>() { 1, 2, 3, 4, 5 };
			int expected = 1;
			foreach (int number in intList) {
				Assert.AreEqual(expected, number);
				expected++;
			}

			// Testing that the foreach can reach the objects inside the collection.
			stringList = new NSList<string>() { "a", "b", "c", "d", "e" };
			var resList = new NSList<string>() { "A", "B", "C", "D", "E" };
			int i = 0;
			foreach (string str in stringList) {
				Assert.AreEqual(resList[i], str.ToUpper());
				i++;
			}

		}

		[Test]
		public void CopyToTest() {
			intList = new NSList<int>() { 2, 2, 3, 4, 5 };
			var array = new int[2];
			array[0] = 1;
			array[1] = 2;
			intList.CopyTo(array: array, arrayIndex: 0);

			for (int i = 0; i < intList.Count; i++) {
				if (i < array.Length)
					Assert.AreEqual(array[i], intList[i]);
			}
		}

		[Test]
		public void SafeCopyToTest() {
			intList = new NSList<int>() { 2, 2, 3, 4, 5 };
			var array = new int[2];
			array[0] = 1;
			array[1] = 2;

			// Only for Next Step Lists
			((NSList<int>)intList).SafeCopyTo(ref array, 4);

			for (int i = 0; i < intList.Count; i++) {
				Assert.AreEqual(array[i + 4], intList[i]);
			}
		}
	}
}