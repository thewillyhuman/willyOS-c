using System;

namespace Foundation.Concurrent {

	/// <summary>
	/// Interface for the Next Step Concurrent Sate Queue.
	/// </summary>
	public interface INSCQueue<T> {

		/// <summary>
		/// Gets or sets the number of elements.
		/// </summary>
		/// <value>The number of elements.</value>
		int NumberOfElements { get; }

		/// <summary>
		/// Ises the empty.
		/// </summary>
		/// <returns><c>true</c>, if empty was ised, <c>false</c> otherwise.</returns>
		bool IsEmpty { get; }

		/// <summary>
		/// Enqueue the specified item.
		/// </summary>
		/// <returns>The enqueue.</returns>
		/// <param name="item">Item.</param>
		void Enqueue(T item);

		/// <summary>
		/// Dequeue this instance.
		/// </summary>
		/// <returns>The dequeue.</returns>
		T Dequeue();

		/// <summary>
		/// Peek this instance.
		/// </summary>
		/// <returns>The peek.</returns>
		T Peek();
	}
}
