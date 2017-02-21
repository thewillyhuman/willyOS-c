using System;
using System.Collections;
using System.Collections.Generic;

namespace Foundation {

	/// <summary>
	/// Next Step List. By using a linked list it works exactly as a normal generic list.
	/// </summary>
	public class NSList<T> : INSList<T> {

		/// <summary>
		/// The head of the list.
		/// </summary>
		private NSLinkedListNode<T> Head;

		/// <summary>
		/// The current node, used to avoid adding nodes before the head
		/// </summary>
		private NSLinkedListNode<T> Current;

		/// <summary>
		/// The size.
		/// </summary>
		private int size = 0;

		/// <summary>
		/// Gets or sets the <see cref="T:willyOS.WList`1"/> at the specified index.
		/// </summary>
		/// <param name="index">Index.</param>
		public T this[int index] {
			get {
				var pointer = Head;
				IndexInRangeCheck(index);
				while (index > 0) {
					pointer = pointer.Next;
					index--;
				}
				return pointer.Value;
			}

			set {
				var pointer = Head;
				IndexInRangeCheck(index);
				while (index > 0) {
					pointer = pointer.Next;
					index--;
				}
				pointer.Value = value;
			}
		}

		/// <summary>
		/// Gets the count.
		/// </summary>
		/// <value>The count.</value>
		public int Count {
			get {
				return size;
			}
		}

		/// <summary>
		/// Gets a value indicating whether this <see cref="T:willyOS.NSList"/> is read only.
		/// </summary>
		/// <value><c>true</c> if is read only; otherwise, <c>false</c>.</value>
		public bool IsReadOnly {
			get {
				return false;
			}
		}

		public NSList() {
			Head = null;
		}

		/// <summary>
		/// Add a new Node to the list.
		/// </summary>
		public void Add(T item) {

			// This is a more verbose implementation to avoid adding nodes to the head of the list
			var node = new NSLinkedListNode<T>() {
				Value = item
			};

			if (Head == null) {
				// This is the first node. Make it the head
				Head = node;
			} else {
				// This is not the head. Make it current's next node.
				Current.Next = node;
			}

			// Makes newly added node the current node
			Current = node;

			size++;

			// This implementation is simpler but adds nodes in reverse order. It adds nodes to the head of the list
		}

		/// <summary>
		/// Clear this instance.
		/// </summary>
		public void Clear() {
			Head = null;
			size = 0;
		}

		/// <summary>
		/// Contains the specified item.
		/// </summary>
		/// <returns>The contains.</returns>
		/// <param name="item">Item.</param>
		public bool Contains(T item) {
			if (Count == 0) {
				return false;
			}

			var iterator = Head;

			while (iterator != null) {
				if (iterator.Value.Equals(item)) {
					return true;
				}
				iterator = iterator.Next;
			}

			return false;
		}

		/// <summary>
		/// Copies to.
		/// </summary>
		/// <param name="array">Array.</param>
		/// <param name="arrayIndex">Array index.</param>
		public void CopyTo(T[] array, int arrayIndex = 0) {
			foreach (T i in this) {
				if (arrayIndex < array.Length) {
					array.SetValue(i, arrayIndex);
					arrayIndex++;
				}
			}
		}

		/// <summary>
		/// Safes the copy to.
		/// </summary>
		/// <param name="array">Array.</param>
		/// <param name="arrayIndex">Array index.</param>
		public void SafeCopyTo(ref T[] array, int arrayIndex = 0) {
			if (array == null) {
				throw new ArgumentNullException();
			}
			if (arrayIndex < 0) {
				throw new ArgumentOutOfRangeException();
			}

			if ((array.Length - arrayIndex) < Count) {
				Array.Resize(ref array, array.Length + (Count - (array.Length - arrayIndex)));
			}

			foreach (T i in this) {
				array.SetValue(i, arrayIndex);
				arrayIndex++;
			}
		}

		public IEnumerator<T> GetEnumerator() {
			for (int i = 0; i < Count; i++) {
				yield return this[i];
			}
		}

		/// <summary>
		/// Indexs the of.
		/// </summary>
		/// <returns>The of.</returns>
		/// <param name="item">Item.</param>
		public int IndexOf(T item) {
			if (Count == 0) {
				return -1;
			}
			int index = 0;

			var iterator = Head;

			while (iterator != null) {
				if (iterator.Value.Equals(item)) {
					return index;
				}
				iterator = iterator.Next;
				index++;
			}

			return -1;
		}

		/// <summary>
		/// Insert the specified index and item.
		/// </summary>
		/// <returns>The insert.</returns>
		/// <param name="index">Index.</param>
		/// <param name="item">Item.</param>
		public void Insert(int index, T item) {
			IndexInRangeCheck(index);

			var newNode = new NSLinkedListNode<T>();
			newNode.Value = item;
			if (index == 0) {
				newNode.Next = Head;
				Head = newNode;
			} else {
				var aux = Head;
				while (index > 1) //for(int i = 0; i < posicion; i++) {nodoAux = nodoAux.Siguiente;}
				{
					aux = newNode.Next;
					index--;
				}
				newNode.Next = aux.Next;
				aux.Next = newNode;
			}
			size++;
		}

		/// <summary>
		/// Remove the specified item.
		/// </summary>
		/// <returns>The remove.</returns>
		/// <param name="item">Item.</param>
		public bool Remove(T item) {
			RemoveAt(IndexOf(item));
			return true;
		}

		/// <summary>
		/// Removes at index.
		/// </summary>
		/// <param name="index">Index.</param>
		public void RemoveAt(int index) {
			IndexInRangeCheck(index);

			if (index == 0) {
				// removing the first element must be handled specially
				Head = Head.Next;
			} else {
				// removing some element further down in the list;
				// traverse to the node before the one we want to remove
				var pointer = Head;
				for (int i = 0; i < index - 1; i++) {
					pointer = pointer.Next;
				}

				// change its next pointer to skip past the offending node
				pointer.Next = pointer.Next.Next;
			}
			size--;
		}

		/// <summary>
		/// System.s the collections. IE numerable. get enumerator.
		/// </summary>
		/// <returns>The collections. IE numerable. get enumerator.</returns>
		IEnumerator IEnumerable.GetEnumerator() {
			return GetEnumerator();
		}

		/// <summary>
		/// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:willyOS.NSList`1"/>.
		/// </summary>
		/// <returns>A <see cref="T:System.String"/> that represents the current <see cref="T:willyOS.NSList`1"/>.</returns>
		public override string ToString() {
			var pointer = Head;
			string aux = "List -> ";

			while (pointer != null) {
				aux = aux + "[" + pointer.Value + "] -> ";
				pointer = pointer.Next;
			}
			return aux;
		}

		/// <summary>
		/// Indexs the in range check.
		/// </summary>
		/// <param name="index">Index.</param>
		public void IndexInRangeCheck(int index) {
			if (index > Count || index < 0) {
				throw new IndexOutOfRangeException();
			}
		}
	}
}
