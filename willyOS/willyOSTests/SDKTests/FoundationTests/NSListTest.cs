using System;
using System.Collections.Generic;
using Foundation;
using NUnit.Framework;
using RAKit;
using RWKit;

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
		public void InitializerTest() {

			// Checking that the intList and the stringList are initialized correctly at the SetUp.
			Assert.IsInstanceOf(typeof(NSList<int>), intList);
			Assert.IsInstanceOf(typeof(NSList<string>), stringList);

			// Testing the call of non-static methods / porperties over a null IList. Shoud produce an exception.
			IList<object> emptyList = null;
			try {
				Assert.AreEqual(0, emptyList.Count);
				Assert.Fail("You cannot instantiate a method over a null object.");
			} catch (NullReferenceException) { }

			// Diferent ways of initialize a list.
			// Array injection at the declaration.
			intList = new NSList<int> { 1, 2, 3, 4 };
			Assert.AreEqual(4, intList.Count);

			// Injection of an empty array at the declaration.
			intList = new NSList<int> { };
			Assert.AreEqual(0, intList.Count);

			// Usual constructor.
			intList = new NSList<int>();
			Assert.AreEqual(0, intList.Count);

			// Same for string but also checking the nullable option.
			// String array injection.
			stringList = new NSList<string> { "a", "b", "c", "d" };
			Assert.AreEqual(4, stringList.Count);

			// String array injection with one null value at the end.
			stringList = new NSList<string> { "a", "b", "c", null };
			Assert.AreEqual(4, stringList.Count);

			// String array injection with one null value at the beginning.
			stringList = new NSList<string> { null, "b", "c", "d" };
			Assert.AreEqual(4, stringList.Count);

			// String array injection with two null values, at the beginning and at the end.
			stringList = new NSList<string> { null, "b", "c", null };
			Assert.AreEqual(4, stringList.Count);

			// String array injection with one single null value and no more values.
			stringList = new NSList<string> { null };
			Assert.AreEqual(1, stringList.Count);

			// Empty string array injection.
			stringList = new NSList<string> { };
			Assert.AreEqual(0, stringList.Count);

			// Usual constructor.
			stringList = new NSList<string>();
			Assert.AreEqual(0, stringList.Count);
		}

		[Test]
		public void AddTest() {

			// Checking that we begin the test with empty lists.
			Assert.AreEqual(0, intList.Count);
			Assert.AreEqual(0, stringList.Count);

			// Testing the base case of adding one single element.
			intList.Add(1);
			Assert.AreEqual(1, intList.Count);
			Assert.AreEqual(true, intList.Contains(1));
			Assert.AreEqual(0, intList.IndexOf(1));

			// Testing the base case of adding one single element that is a variable.
			var t = 2;
			intList.Add(t);
			Assert.AreEqual(2, intList.Count);
			Assert.AreEqual(true, intList.Contains(2));
			Assert.AreEqual(1, intList.IndexOf(2));
			Assert.AreEqual(true, intList.Contains(t));
			Assert.AreEqual(1, intList.IndexOf(t));

			// Testing the base case of adding a repeated element as fas a 1 already belongs to the intList.
			intList.Add(1);
			Assert.AreEqual(3, intList.Count);
			Assert.AreEqual(true, intList.Contains(1));
			Assert.AreEqual(0, intList.IndexOf(1));


			// Same for strings but checking the nullable condition.
			// Testing the base case of adding one single element.
			stringList.Add("a");
			Assert.AreEqual(1, stringList.Count);
			Assert.AreEqual(true, stringList.Contains("a"));
			Assert.AreEqual(0, stringList.IndexOf("a"));

			// Testing the base case of adding one single element that is a variable.
			var s = "b";
			stringList.Add(s);
			Assert.AreEqual(2, stringList.Count);
			Assert.AreEqual(true, stringList.Contains(s));
			Assert.AreEqual(1, stringList.IndexOf(s));

			// Testing the base case for nullable objects of adding a null value to the list.
			stringList.Add(null);
			Assert.AreEqual(3, stringList.Count);
			Assert.AreEqual(true, stringList.Contains(null));
			Assert.AreEqual(2, stringList.IndexOf(null));

			// Testing the base case of adding a repeated element as fas a 's' already belongs to the stringList.
			stringList.Add(s);
			Assert.AreEqual(4, stringList.Count);
			Assert.AreEqual(true, stringList.Contains(s));
			Assert.AreEqual(1, stringList.IndexOf(s));


			// Testing for open lists that accept any kind of object.
			var objectList = new NSList<object>();

			// Adding an int to a object type list.
			objectList.Add(1);
			Assert.AreEqual(1, objectList.Count);
			Assert.AreEqual(true, objectList.Contains(1));
			Assert.AreEqual(0, objectList.IndexOf(1));

			// Ading an string to an object type list that already contains an int.
			objectList.Add("a");
			Assert.AreEqual(2, objectList.Count);
			Assert.AreEqual(true, objectList.Contains("a"));
			Assert.AreEqual(1, objectList.IndexOf("a"));

			// Adding a null value to an object list type.
			objectList.Add(null);
			Assert.AreEqual(3, objectList.Count);
			Assert.AreEqual(true, objectList.Contains(null));
			Assert.AreEqual(2, objectList.IndexOf(null));

			// Adding a repeated element to an object list type. Notice that the repeated element it's also null.
			objectList.Add(null);
			Assert.AreEqual(4, objectList.Count);
			Assert.AreEqual(true, objectList.Contains(null));
			Assert.AreEqual(2, objectList.IndexOf(null));

			// Clearing our list to some performance test.
			intList.Clear();
			stringList.Clear();

			// Adding some values to our lists to check that can add multiple values with no problem.
			for (int i = 0; i < 100000; i++) {
				intList.Add(i);
				stringList.Add(RAWordGenerator.GenerateRandomWord());
				Assert.AreEqual(i + 1, intList.Count);
				Assert.AreEqual(i + 1, stringList.Count);
			}
		}

		[Test]
		public void GetTest() {

			// Trying to get the value from a negative index.
			try {
				Assert.AreEqual(-1, intList[-1]);
				Assert.AreEqual(-1, intList[int.MinValue]);
				Assert.Fail();
			} catch (IndexOutOfRangeException) { }

			// Trying to access the list with an index that does no exists.
			try {
				Assert.AreEqual(-1, intList[intList.Count]);
				Assert.AreEqual(-1, intList[int.MaxValue]);
				Assert.Fail();
			} catch (IndexOutOfRangeException) { }


			// Base case of adding one single element.
			intList.Add(1);
			Assert.AreEqual(1, intList[0]);

			// Base case of adding one single element.
			stringList.Add("a");
			Assert.AreEqual("a", stringList[0]);

			// Base case of adding a null value a nullable type list.
			stringList.Add(null);
			Assert.AreEqual(null, stringList[1]);

			// Asigning to one position the value of another.
			stringList[1] = stringList[0];
			Assert.AreEqual("a", stringList[1]);

			// Changing the value of the position asigned and checking that the reference does not change.
			stringList[0] = "b";
			Assert.AreEqual("b", stringList[0]);
			Assert.AreNotEqual("b", stringList[1]);
			Assert.AreEqual("a", stringList[1]);

			// Clearing th lists for some performance testing.
			intList.Clear();
			stringList.Clear();
			for (int i = 0; i < 10000; i++) {
				intList.Add(i);
				stringList.Add("a");
				Assert.AreEqual(i, intList[i]);
				Assert.AreEqual("a", stringList[i]);
			}
		}

		[Test]
		public void SetTest() {
			// Checking that we begin the test with empty lists.
			Assert.AreEqual(0, intList.Count);
			Assert.AreEqual(0, stringList.Count);

			// Trying to set an index that does not exists.
			try {
				intList[0] = 1;
				Assert.Fail();
			} catch (IndexOutOfRangeException) { }

			// Trying to set an index that does not exists.
			try {
				intList[-1] = 1;
				Assert.Fail();
			} catch (IndexOutOfRangeException) { }

			// Adding one integer to the list to be able so set some value.
			intList.Add(1);
			Assert.AreEqual(1, intList[0]);

			// Base case. Setting an index that exists.
			intList[0] = 2;
			Assert.AreEqual(2, intList[0]);

			// Base case. Setting an index that exists with a variable.
			int t = 1;
			intList[0] = t;
			Assert.AreEqual(t, intList[0]);

			// Changing the value of the variable. Notice that the value of the index does not change.
			t = 2;
			Assert.AreNotEqual(t, intList[0]);
			Assert.AreEqual(1, intList[0]);

			// Adding an string to the stringList.
			stringList.Add("a");
			Assert.AreEqual("a", stringList[0]);

			// Checking that a null can be setted.
			stringList[0] = null;
			Assert.AreEqual(null, stringList[0]);

			// Clearing the intList for some performance test.
			intList.Clear();
			for (int i = 0; i < 10000; i++) {
				intList.Add(i);
				Assert.AreEqual(i, intList[i]);
				intList[i] = i + 1;
				Assert.AreEqual(i + 1, intList[i]);
			}
		}

		[Test]
		public void ContainsTest() {

			// Checking thet when we add one nnumber the list contains and only contains that number.
			intList.Add(1);
			Assert.AreEqual(false, intList.Contains(item: -1));
			Assert.AreEqual(false, intList.Contains(item: 0));
			Assert.AreEqual(true, intList.Contains(item: 1));
			Assert.AreEqual(false, intList.Contains(item: 2));

			// Same for strings.
			stringList.Add("a");
			Assert.AreEqual(false, stringList.Contains(item: "A"));
			Assert.AreEqual(false, stringList.Contains(item: "b"));
			Assert.AreEqual(true, stringList.Contains(item: "a"));
			Assert.AreEqual(false, stringList.Contains(item: "c"));

			// Some performance test.
			for (int i = 2; i < 10000; i++) {
				intList.Add(i);
				Assert.AreEqual(true, intList.Contains(item: i));
			}

			// Checking that the stringList does not contains any null value.
			Assert.AreEqual(false, stringList.Contains(item: null));

			// Adding some strings to the stringList.
			stringList.Add("b");
			stringList.Add("c");
			stringList.Add("d");

			// Setting one of the values to null to test the contains with null.
			stringList[2] = null;
			Assert.AreEqual(true, stringList.Contains(item: null));

			// Quick check of the indexOf.
			Assert.AreEqual(2, stringList.IndexOf(item: null));

			// Checking with non-primitive objects.
			var peopleList = new NSList<RWPerson>();

			// Creating some people.
			var john = new RWPerson("John", 29);
			var johnClone = new RWPerson("John", 29); // A clon of john.
			var johnFather = new RWPerson("John", 64); // John's father.
			var mary = new RWPerson("Mary", 36); // Ramdom person.

			// Adding john to the list.
			peopleList.Add(john);

			// With the following assertions we're checking that the contains uses the default Equals or (if) the overrided one.
			Assert.AreEqual(true, peopleList.Contains(john));
			Assert.AreEqual(true, peopleList.Contains(johnClone));
			Assert.AreEqual(true, peopleList.Contains(new RWPerson("John", 29)));
			Assert.AreEqual(true, peopleList.Contains(new RWPerson("jOhN", 29)));
			Assert.AreEqual(false, peopleList.Contains(johnFather));
			Assert.AreEqual(false, peopleList.Contains(mary));


		}

		[Test]
		public void RemoveTest() {

			// Checking that we begin the test with empty lists.
			Assert.AreEqual(0, intList.Count);
			Assert.AreEqual(0, stringList.Count);

			// Trying to remove an element that does not exists in the list.
			Assert.AreEqual(false, intList.Remove(1));

			// Adding a repeated element to the list {1, 1}
			intList.Add(1);
			intList.Add(1);

			// Removing the first appearence of 1. And Checking that the second one passes to the index of the first one.
			Assert.AreEqual(true, intList.Remove(1));
			Assert.AreEqual(1, intList[0]);
			Assert.AreEqual(1, intList.Count);

			// Checking with non-primitive objects.
			var peopleList = new NSList<RWPerson>();

			// Creating some people.
			var john = new RWPerson("John", 29);
			var johnClone = new RWPerson("John", 29); // A clon of john.
			var johnFather = new RWPerson("John", 64); // John's father.
			var mary = new RWPerson("Mary", 36); // Ramdom person.

			// Adding some people to the list.
			peopleList.Add(john);
			peopleList.Add(johnClone);
			peopleList.Add(johnFather);
			peopleList.Add(mary);

			Assert.AreEqual(true, peopleList.Remove(johnClone));

			// Notice that because of the equals of person and that the list contains a clone we can still check
			// that the list contains john and jhonClone.
			Assert.AreEqual(true, peopleList.Contains(johnClone));
			Assert.AreEqual(true, peopleList.Contains(john));

			// We have still one john in the list
			Assert.AreEqual(true, peopleList.Remove(johnClone));

			// No more jhons should be in the list.
			Assert.AreEqual(false, peopleList.Remove(johnClone));
			Assert.AreEqual(false, peopleList.Remove(john));

			// Checking that we can also remove by using the equals of the object.
			Assert.AreEqual(true, peopleList.Remove(new RWPerson("Mary", 36)));

			// Clearing the list for some performance tests.
			intList.Clear();
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
			intList = new NSList<int> { 1, 2, 3, 4, 5 };
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

			// Checking that the expected exception is thrown when trying to copy to a null array.
			int[] nullArray = null;
			intList.Add(1);
			try {
				intList.CopyTo(nullArray, 0);
				Assert.Fail();
			} catch (NullReferenceException) { }

			// Copying a simple array and testing it.
			intList = new NSList<int> { 2, 2, 3, 4, 5 };
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

			// Checking that the expected exception is thrown when trying to copy to a null array.
			int[] nullArray = null;
			intList.Add(1);
			try {
				((NSList<int>)intList).SafeCopyTo(ref nullArray);
				Assert.Fail();
			} catch (ArgumentException) { }

			// Copying a simple array and testing it.
			intList = new NSList<int> { 2, 2, 3, 4, 5 };
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