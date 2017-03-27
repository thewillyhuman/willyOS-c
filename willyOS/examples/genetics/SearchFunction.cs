using System;
using System.Collections.Generic;
using CoreServices;
using Foundation;

namespace examples.genetics {

	/// <summary>
	/// Search function.
	/// </summary>
	public class SearchFunction {

		/// <summary>
		/// Search the specified array.
		/// </summary>
		/// <returns>The search.</returns>
		/// <param name="array">Array.</param>
		public static double Search(char[] array, Gene gene) {

			// The number of appearances of genes.
			var result = 0;

			int i = 0;
			int _ChunkSize = 2;

			while(!(i == array.Length - 2 && _ChunkSize == 3)) {

				//Console.WriteLine(1);

				var _Chunk = array.SubArray(i, _ChunkSize);

				//Console.WriteLine(2);

				if(gene.Is(_Chunk)) {
					result++;
				}

				//Console.WriteLine(3);

				if(_ChunkSize == 2) {
					_ChunkSize = 3;
				} else {
					_ChunkSize = 2;
					i++;
				}

				//Console.WriteLine(4);
			}
			
			return result;
		}

		public static double SearchChunk(char[] array, Gene gene) {
			if(gene.Is(array))
				return 1;
			return 0;
		}

		/// <summary>
		/// Tos the chunks.
		/// </summary>
		/// <returns>The chunks.</returns>
		/// <param name="array">Array.</param>
		public static NSList<string> ToChunks(char[] array) {
			int i = 0;
			int _ChunkSize = 2;
			var tmp = new NSList<string>();


			while(!(i == array.Length-2 && _ChunkSize == 3)) {
				//Console.WriteLine("Index: {0}, Length: {1}", i, _ChunkSize);
				var _Chunk = array.SubArray(i, _ChunkSize);

				tmp.Add(new string(_Chunk));

				if(_ChunkSize == 2) {
					_ChunkSize = 3;
				} else {
					_ChunkSize = 2;
					i++;
				}
			}

			return tmp;
		}
	}
}