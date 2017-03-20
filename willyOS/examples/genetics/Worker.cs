
namespace TPP.Laboratory.Concurrency.Lab09 {

    internal class Worker {

        private short[] vector;

        private int fromIndex, toIndex;

        private long result;

        internal long Result {
            get { return result; }
        }

        internal Worker(short[] vector, int fromIndex, int toIndex) {
            this.vector = vector;
            this.fromIndex = fromIndex;
            this.toIndex = toIndex;
        }

        internal void Compute() {
            result = 0;
            for(int i= fromIndex; i<=toIndex; i++)
                result += vector[i] * vector[i];
        }

    }

}
