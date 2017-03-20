using System;

namespace examples.genetics {

	internal class Worker<T, K> {

		private T[] _vector;

		private int _fromIndex, _toIndex;

		private double _result;

		private Func<T[], double> _f;

		internal double Result {
			get {
				return _result;
			}
		}

		internal Worker(T[] vector, int fromIndex, int toIndex, Func<T[], double> f) {
			_vector = vector;
			_fromIndex = fromIndex; //(fromIndex == 0) ? fromIndex: fromIndex - 2;
			_toIndex = toIndex; //(toIndex == vector.Length-1) ? toIndex: toIndex+2;
			int length = _toIndex - _fromIndex + 1;
			_vector = new T[length];
			_f = f;
			for(int i = _fromIndex; i < length; i++) {
				_vector[i] = vector[i];
			}
		}

		/*
			A B G T A -> 1 ocurrence.
			AB G T A
			ABG T A
			A BG TA
			A BGT A
			A B GT A
			A B GTA
			A B G TA
			A B G T A
		*/
		internal void Compute() {
			_result = _f(_vector);
		}
	}

}
