
namespace TPP.Concurrency.Threads {

    /// <summary>
    /// Computes the addition of the square values of part of a vector
    /// </summary>
    internal class Worker {

        /// <summary>
        /// The vector whose modulus is going to be computed.
        /// </summary>
        private short[] vector;

        /// <summary>
        /// Indices of the vector indicating the elements to be used in the computation.
        /// Both fromIndex and toIndex are included in the process.
        /// </summary>
        private int fromIndex, toIndex;

        /// <summary>
        /// The result of the computation
        /// </summary>
        private long result;

        internal long Result {
            get { return this.result; }
        }

        internal Worker(short[] vector, int fromIndex, int toIndex) {
            this.vector = vector;
            this.fromIndex = fromIndex;
            this.toIndex = toIndex;
        }

        /// <summary>
        /// Method that computes the addition of the squares
        /// </summary>
        internal void Compute() {
            this.result = 0;
            for(int i= this.fromIndex; i<=this.toIndex; i++)
                this.result += this.vector[i] * this.vector[i];
        }

    }

}
