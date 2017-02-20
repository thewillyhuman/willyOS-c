using System.Collections.Generic;

namespace willyOS {

	/// <summary>
	/// NSList Interface.
	/// </summary>
	public interface INSList<T> : IList<T>, IEnumerable<T> {

		/// <summary>
		/// Indexs the in range check.
		/// </summary>
		/// <param name="index">Index.</param>
		void IndexInRangeCheck(int index);

		/// <summary>
		/// Safes the copy to.
		/// </summary>
		/// <param name="array">Array.</param>
		/// <param name="arrayIndex">Array index.</param>
		void SafeCopyTo(ref T[] array, int arrayIndex);
	}
}
