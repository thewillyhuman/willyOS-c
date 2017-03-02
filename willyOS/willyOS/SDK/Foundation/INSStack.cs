
namespace Foundation {

	/// <summary>
	/// Next Step Stack.
	/// </summary>
	public interface INSStack<T> {

		/// <summary>
		/// Push the specified element.
		/// </summary>
		/// <returns>The push.</returns>
		/// <param name="element">Element.</param>
		void Push(T element);

		/// <summary>
		/// Pop this instance.
		/// </summary>
		/// <returns>The pop.</returns>
		T Pop();
	}
}
