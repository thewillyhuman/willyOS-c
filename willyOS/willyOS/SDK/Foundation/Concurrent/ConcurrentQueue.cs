
namespace Foundation.Concurrent {

	/// <summary>
	/// Concurrent queue.
	/// </summary>
	public class ConcurrentQueue<T> {

		/// <summary>
		/// The list.
		/// </summary>
		NSList<T> _list;

		/// <summary>
		/// Initializes a new instance of the <see cref="T:Foundation.Concurrent.ConcurrentQueue`1"/> class.
		/// </summary>
		public ConcurrentQueue() {
			_list = new NSList<T>();
		}

		/// <summary>
		/// Gets the number of elements.
		/// </summary>
		/// <value>The number of elements.</value>
		public int NumberOfElements {
			get {
				lock(this)
					return _list.Count;
			}
		}

		/// <summary>
		/// Gets a value indicating whether this <see cref="T:Foundation.Concurrent.ConcurrentQueue`1"/> is empty.
		/// </summary>
		/// <value><c>true</c> if is empty; otherwise, <c>false</c>.</value>
		public bool IsEmpty {
			get {
				lock(this)
					return _list.Count == 0;
			}
		}

		/// <summary>
		/// Enqueue the specified item.
		/// </summary>
		/// <returns>The enqueue.</returns>
		/// <param name="item">Item.</param>
		public void Enqueue(T item) {
			lock(this)
				_list.Insert(index: _list.Count-1, item: item);
		}

		/// <summary>
		/// Dequeue this instance.
		/// </summary>
		/// <returns>The dequeue.</returns>
		public T Dequeue() {
			lock(this) {
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
			lock(this)
				return _list[0];
		}
	}
}
