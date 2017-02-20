using System;
using NUnit.Framework;
namespace willyOS.tests {

	public class NSSTackTest {

		NSStack stack;

		[SetUp]
		public void BeforeEachTest() {
			stack = new NSStack(1000);
		}

		[Test]
		public void PushTest() {

			// Creating some elements...
			for (int i = 1; i <= 1000; i++) {
				stack.Push(i);
			}
			Assert.AreEqual(true, stack.IsFull);
			Assert.AreEqual(false, stack.IsEmpty);

			// Trying to push an element when the stack is full.
			try {
				stack.Push(1001);
				Assert.Fail();
			} catch (InvalidOperationException) { }
		}

		[Test]
		public void PopTest() {

			// Creating some elements...
			for (int i = 0; i < 1000; i++) {
				stack.Push(i);
			}
			Assert.AreEqual(true, stack.IsFull);
			Assert.AreEqual(false, stack.IsEmpty);

			// Popping all the elements and checking they match with the expected.
			for (int i = 999; i >= 0; i--) {
				Assert.AreEqual(i, stack.Pop());
			}

			// Trying to pop elements with an empty stack.
			try {
				stack.Pop();
				Assert.Fail();
			} catch (InvalidOperationException) { }
		}
	}
}
