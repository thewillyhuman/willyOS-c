
namespace Foundation {

	public interface INSStack {

		/// <summary>
		/// Push the specified element.
		/// </summary>
		/// <returns>The push.</returns>
		/// <param name="element">Element.</param>
		void Push(object element);

		/// <summary>
		/// Pop this instance.
		/// </summary>
		/// <returns>The pop.</returns>
		object Pop();
	}
}
