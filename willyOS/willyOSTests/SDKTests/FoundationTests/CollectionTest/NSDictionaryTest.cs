using System.Collections.Generic;
using NUnit.Framework;

namespace willyOS.tests {

	public class NSDictionaryTest {

		IDictionary<int, string> dic;

		[SetUp]
		public void BeforeEachTest() {
			dic = new NSDictionary<int, string>();
		}

		[Test]
		public void AddTest() {
			dic.Add("lalala".GetHashCode(), "lalala");
			Assert.AreEqual(1, dic.Count);
			dic.Add("lalalaa".GetHashCode(), "lalalaa");
			Assert.AreEqual(2, dic.Count);

			dic = new Dictionary<int, string>() { { 2, "s" }, { 1, "a" } };
			Assert.AreEqual(2, dic.Count);
		}

		[Test]
		public void CountTest() {
			dic.Add("lalala".GetHashCode(), "lalala");
			Assert.AreEqual(1, dic.Count);
			dic.Add("lalalaa".GetHashCode(), "lalalaa");
			Assert.AreEqual(2, dic.Count);
		}

		[Test]
		public void GetTest() {
			dic.Add("lalala".GetHashCode(), "lalala");
			//Assert.AreNotEqual("lalala", dic["lalal".GetHashCode()]);
			Assert.AreEqual("lalala", dic["lalala".GetHashCode()]);
			//Assert.AreNotEqual("lalala", dic["lalalaa".GetHashCode()]);
			dic.Add("lalalaa".GetHashCode(), "lalalaa");
			Assert.AreEqual("lalalaa", dic["lalalaa".GetHashCode()]);
		}

		[Test]
		public void ContainsTest() {
			dic.Add("lalala".GetHashCode(), "lalala");
			Assert.AreEqual(false, dic.ContainsKey("lalal".GetHashCode()));
			Assert.AreEqual(true, dic.ContainsKey("lalala".GetHashCode()));
			Assert.AreEqual(false, dic.ContainsKey("lalalaa".GetHashCode()));
			dic.Add("lalalaa".GetHashCode(), "lalalaa");
			Assert.AreEqual(true, dic.ContainsKey("lalala".GetHashCode()));
			Assert.AreEqual(true, dic.ContainsKey("lalalaa".GetHashCode()));
			Assert.AreEqual(false, dic.ContainsKey("lalalaaa".GetHashCode()));

		}

		[Test]
		public void DeleteTest() {
			dic.Add("lalala".GetHashCode(), "lalala");
			Assert.AreEqual(false, dic.ContainsKey("lalal".GetHashCode()));
			Assert.AreEqual(true, dic.ContainsKey("lalala".GetHashCode()));
			Assert.AreEqual(false, dic.ContainsKey("lalalaa".GetHashCode()));
			dic.Add("lalalaa".GetHashCode(), "lalalaa");
			Assert.AreEqual(true, dic.ContainsKey("lalala".GetHashCode()));
			Assert.AreEqual(true, dic.ContainsKey("lalalaa".GetHashCode()));
			Assert.AreEqual(false, dic.ContainsKey("lalalaaa".GetHashCode()));

			dic.Remove("lalala".GetHashCode());
			dic.Remove("lalalaa".GetHashCode());
			Assert.AreEqual(false, dic.ContainsKey("lalala".GetHashCode()));
			Assert.AreEqual(false, dic.ContainsKey("lalalaa".GetHashCode()));
		}

		[Test]
		public void IterateTest() {
			string[] example = { "a", "b", "c", "d", "3", "aaa", "s3d", "?e3", "sss", "-1", ".1", "\nee" };
			for (int i = 0; i < example.Length; i++) {
				dic.Add(example[i].GetHashCode(), example[i]);
			}

			int counter = 0;
			foreach (KeyValuePair<int, string> pair in dic) {
				Assert.AreEqual(example[counter], pair.Value);
				counter++;
			}
		}

	}
}
