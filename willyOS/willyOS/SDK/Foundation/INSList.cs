using System.Collections.Generic;

namespace Foundation {

	/// <summary>
	/// NSList Interface.
	/// </summary>
	public interface INSList<T> : IList<T>, IEnumerable<T> {

		/// <summary>
		/// Safes the copy to.
		/// </summary>
		/// <param name="array">Array.</param>
		/// <param name="arrayIndex">Array index.</param>
		void SafeCopyTo(ref T[] array, int arrayIndex);
	}
}
