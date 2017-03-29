
using System.Threading;
using CoreServices;

namespace Foundation.Concurrent {

	/// <summary>
	/// Concurrent queue.
	/// </summary>
	public class NSCQueue<T> : CSPrint, INSCQueue<T> {

		volatile NSList<T> _list = new NSList<T>();

		static readonly object _writeLock = new object();
		static readonly object _readLock = new object();

		/// <summary>
		/// Gets the number of elements.
		/// </summary>
		/// <value>The number of elements.</value>
		public int NumberOfElements {
			get {
				lock(_readLock) {
					return _list.Count;
				}
			}
		}

		/// <summary>
		/// Gets a value indicating whether this <see cref="T:Foundation.Concurrent.ConcurrentQueue`1"/> is empty.
		/// </summary>
		/// <value><c>true</c> if is empty; otherwise, <c>false</c>.</value>
		public bool IsEmpty {
			get {
				lock(_readLock) {
					return _list.Count == 0;
				}
			}
		}

		/// <summary>
		/// Enqueue the specified item.
		/// </summary>
		/// <returns>The enqueue.</returns>
		/// <param name="item">Item.</param>
		public void Enqueue(T item) {
			lock(_writeLock) {
				_list.Insert(_list.Count == 0 ? 0 : _list.Count, item);
			}
		}

		/// <summary>
		/// Dequeue this instance.
		/// </summary>
		/// <returns>The dequeue.</returns>
		public T Dequeue() {
			lock(_writeLock){
				var tmp = _list[0];
				_list.RemoveAt(0);
				return tmp;
			}
		}

		/// <summary>
		/// Peek this instance.
		/// </summary>
		/// <returns>The peek.</returns>
		public T Peek() {
			lock(_readLock){
				return _list[0];
			}
		}
	}
}
