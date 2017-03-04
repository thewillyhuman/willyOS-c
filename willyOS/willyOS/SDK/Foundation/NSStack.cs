using System;

namespace Foundation {

	/// <summary>
	/// NSS tack.
	/// </summary>
	public class NSStack<T> : INSStack<T> {

		/// <summary>
		/// The list.
		/// </summary>
		NSList<T> _list;

		/// <summary>
		/// The max number of elements.
		/// </summary>
		uint _maxNumberOfElements = 0;

		/// <summary>
		/// Gets a value indicating whether this <see cref="T:willyOS.NSStack"/> is empty.
		/// </summary>
		/// <value><c>true</c> if is empty; otherwise, <c>false</c>.</value>
		public bool IsEmpty {
			get {
				return _list.Count == 0;
			}
		}

		/// <summary>
		/// Gets a value indicating whether this <see cref="T:willyOS.NSStack"/> is full.
		/// </summary>
		/// <value><c>true</c> if is full; otherwise, <c>false</c>.</value>
		public bool IsFull {
			get {
				return _list.Count == _maxNumberOfElements;
			}
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="T:willyOS.NSStack"/> class.
		/// </summary>
		/// <param name="MaxNumberOfElements">Max number of elements.</param>
		public NSStack(uint MaxNumberOfElements = 10) {
			_maxNumberOfElements = MaxNumberOfElements;
			_list = new NSList<T>();
		}

		/// <summary>
		/// Push the specified element.
		/// </summary>
		/// <returns>The push.</returns>
		/// <param name="element">Element.</param>
		public void Push(T element) {
			if (IsFull) {
				throw new InvalidOperationException("The stack is full");
			}

			_list.Insert(index: 0, item: element);
		}

		/// <summary>
		/// Pop this instance.
		/// </summary>
		/// <returns>The pop.</returns>
		public T Pop() {
			if (IsEmpty) {
				throw new InvalidOperationException("The stack is empty");
			}
			var aux = _list[0];
			_list.RemoveAt(0);
			return aux;
		}
	}
}