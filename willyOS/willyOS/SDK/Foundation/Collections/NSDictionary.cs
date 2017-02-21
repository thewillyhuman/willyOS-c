using System.Collections.Generic;

namespace Foundation {

	/// <summary>
	/// Next Step Dictionary. At that time given that we just need to operate over a dictionary and not to implement
	/// our custom one we will be working with an internal dicctionary. So this class behaves like a façade.
	/// </summary>
	public class NSDictionary<TKey, TValue> : Dictionary<TKey, TValue> /*, INSDictionary<TValue, TKey>*/ {

		/*/// <summary>
		/// The table.
		/// </summary>
		private Dictionary<TKey, TValue> table = new Dictionary<TKey, TValue>();

		/// <summary>
		/// Gets or sets the <see cref="T:willyOS.NSDictionary`2"/> with the specified key.
		/// </summary>
		/// <param name="key">Key.</param>
		public TValue this[TKey key] {
			get {
				return table[key];
			}

			set {
				table[key] = value;
			}
		}

		/// <summary>
		/// Gets the count.
		/// </summary>
		/// <value>The count.</value>
		public int Count {
			get {
				return table.Count;
			}
		}

		/// <summary>
		/// Gets a value indicating whether this <see cref="T:willyOS.NSDictionary`2"/> is read only.
		/// </summary>
		/// <value><c>true</c> if is read only; otherwise, <c>false</c>.</value>
		public bool IsReadOnly {
			get {
				return false;
			}
		}

		/// <summary>
		/// Gets the keys.
		/// </summary>
		/// <value>The keys.</value>
		public ICollection<TKey> Keys {
			get {
				return table.Keys;
			}
		}

		/// <summary>
		/// Gets the values.
		/// </summary>
		/// <value>The values.</value>
		public ICollection<TValue> Values {
			get {
				return table.Values;
			}
		}

		/// <summary>
		/// Add the specified item.
		/// </summary>
		/// <returns>The add.</returns>
		/// <param name="item">Item.</param>
		public void Add(KeyValuePair<TKey, TValue> item) {
			Add(item.Key, item.Value);
		}

		/// <summary>
		/// Add the specified key and value.
		/// </summary>
		/// <returns>The add.</returns>
		/// <param name="key">Key.</param>
		/// <param name="value">Value.</param>
		public void Add(TKey key, TValue value) {
			table.Add(key, value);
		}

		/// <summary>
		/// Clear this instance.
		/// </summary>
		public void Clear() {
			table.Clear();
		}

		/// <summary>
		/// Contains the specified item.
		/// </summary>
		/// <returns>The contains.</returns>
		/// <param name="item">Item.</param>
		public bool Contains(KeyValuePair<TKey, TValue> item) {
			return ContainsKey(item.Key);
		}

		/// <summary>
		/// Containses the key.
		/// </summary>
		/// <returns><c>true</c>, if key was containsed, <c>false</c> otherwise.</returns>
		/// <param name="key">Key.</param>
		public bool ContainsKey(TKey key) {
			return table.ContainsKey(key);
		}

		/// <summary>
		/// Copies to.
		/// </summary>
		/// <param name="array">Array.</param>
		/// <param name="arrayIndex">Array index.</param>
		public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex) {
			throw new NotImplementedException();
		}

		/// <summary>
		/// Gets the enumerator.
		/// </summary>
		/// <returns>The enumerator.</returns>
		public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator() {
			return table.GetEnumerator();
		}

		/// <summary>
		/// Remove the specified item.
		/// </summary>
		/// <returns>The remove.</returns>
		/// <param name="item">Item.</param>
		public bool Remove(KeyValuePair<TKey, TValue> item) {
			return Remove(item.Key);
		}

		/// <summary>
		/// Remove the specified key.
		/// </summary>
		/// <returns>The remove.</returns>
		/// <param name="key">Key.</param>
		public bool Remove(TKey key) {
			return table.Remove(key);
		}

		/// <summary>
		/// Tries the get value.
		/// </summary>
		/// <returns><c>true</c>, if get value was tryed, <c>false</c> otherwise.</returns>
		/// <param name="key">Key.</param>
		/// <param name="value">Value.</param>
		public bool TryGetValue(TKey key, out TValue value) {
			return table.TryGetValue(key, out value);
		}

		/// <summary>
		/// System.s the collections. IE numerable. get enumerator.
		/// </summary>
		/// <returns>The collections. IE numerable. get enumerator.</returns>
		IEnumerator IEnumerable.GetEnumerator() {
			return table.GetEnumerator();
		}*/
	}
}
