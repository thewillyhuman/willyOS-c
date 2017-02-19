using System;

namespace willyOS {

	public class NSNode<T> {

		public T NodeContent { set; get; }
		public NSNode<T> Next { set; get; }

	}
}
