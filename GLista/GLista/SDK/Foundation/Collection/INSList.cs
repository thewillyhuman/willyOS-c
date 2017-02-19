using System;
using System.Collections.Generic;

namespace willyOS {

	public interface INSList<T> : IList<T>, IEnumerable<T> {
		void IndexInRangeCheck(int index);
	}
}
