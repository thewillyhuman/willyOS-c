
using System;

namespace examples.genetics {

	/// <summary>
	/// Gen Super Class.
	/// </summary>
	public class Gene {

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
			var tmp = new string(arr);
			//Console.WriteLine("Chunk [ {0} ] | Name {1} :: {2}", tmp, name, name == tmp);
			return name == tmp;
		}

		/// <summary>
		/// The aaa gene.
		/// </summary>
		public readonly static Gene AAA_GENE = new AAAGene();

		/// <summary>
		/// The ab gene.
		/// </summary>
		public readonly static Gene AB_GENE = new ABGene();

		/// <summary>
		/// The gt gene.
		/// </summary>
		public readonly static Gene GT_GENE = new GTGene();

		/// <summary>
		/// The genes.
		/// </summary>
		public readonly static Gene[] GENES = { AAA_GENE, AB_GENE, AB_GENE};
	}
}
