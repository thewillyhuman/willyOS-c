
namespace examples.genetics {

	/// <summary>
	/// Gen Super Class.
	/// </summary>
	public class Gen {

		/// <summary>
		/// The name of the gen.
		/// </summary>
		public string name;

		/// <summary>
		/// Check if the given array matches with the gen code.
		/// </summary>
		/// <returns>The is.</returns>
		/// <param name="arr">Arr.</param>
		public bool Is(char[] arr) {
			var tmp = name.ToCharArray();
			for(int i = 0; i < arr.Length; i++) {
				if(!arr[i].Equals(tmp[i]))
					return false;
			}
			return true;
		}
	}
}
