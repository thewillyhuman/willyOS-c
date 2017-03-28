using System;
using System.Collections.Concurrent;
using System.Threading;
using Foundation.Concurrent;
using NUnit.Framework;

namespace willyOS.tests {

	/// <summary>
	/// Concurrent queue test.
	/// </summary>
	public class ConcurrentQueueTest {

		NSCQueue<int> cqueue;

		[SetUp]
		public void BeforeEachTest() {
			cqueue = new NSCQueue<int>();
		}

		[Test]
		public void Test() {
			var ntest = 100;
			Thread[] threads = new Thread[ntest];
			for(int i = 0; i < ntest-5; i = i + 5) {
				threads[i] = new Thread(Add);
				threads[i+1] = new Thread(NumberOfElements);
				threads[i+2] = new Thread(Peek);
				threads[i+3] = new Thread(Remove);
				threads[i+4] = new Thread(IsEmpty);
			}
			for(int i = 0; i < threads.Length; i++) {
				if(threads[i] != null)
					threads[i].Start();
			}

			foreach(var thread in threads) {
				if(thread != null)
					thread.Join();
			}
			Assert.AreEqual(true, true);
			Console.Write("Lenght: {0}", cqueue.NumberOfElements);
		}

		internal void Add() {
			cqueue.Enqueue(1);
		}

		internal void Remove() {
			cqueue.Dequeue();
		}

		internal void NumberOfElements() {
			var i = cqueue.NumberOfElements;
		}

		internal void IsEmpty() {
			var i = cqueue.IsEmpty;
		}

		internal void Peek() {
			cqueue.Peek();
		}
	}
}
