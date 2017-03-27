using System;
using System.Threading;
using Foundation;

namespace examples.genetics {

	/// <summary>
	/// Processor.
	/// </summary>
	public class Processor {

		/// <summary>
		/// The vector.
		/// </summary>
		private char[] _vector;

		/// <summary>
		/// The workers.
		/// </summary>
		private Worker<char, double>[] _workers;

		/// <summary>
		/// The processes.
		/// </summary>
		private Thread[] _threads;

		/// <summary>
		/// The gene.
		/// </summary>
		private Gene _gene;

		/// <summary>
		/// Initializes a new instance of the <see cref="T:examples.genetics.Processor"/> class.
		/// </summary>
		/// <param name="vector">Vector.</param>
		/// <param name="gene">Gene.</param>
		public Processor(char[] vector, Gene gene) {
			_vector = vector;
			_gene = gene;
		}

		/// <summary>
		/// Run this instance.
		/// </summary>
		/// <returns>The run.</returns>
		public double Run() {

			var chuncks = SearchFunction.ToChunks((_vector));
			_threads = new Thread[chuncks.Count];
			_workers = new Worker<char, double>[chuncks.Count];

			for(int i = 0; i < chuncks.Count; i++) {

				Console.Write("Process for possible gene [{0}] :: ", chuncks[i]);

				var worker = new Worker<char, double>(chuncks[i].ToCharArray(), 0, 0, SearchFunction.SearchChunk, _gene);
				_workers[i] = worker;
				_threads[i] = new Thread(worker.Compute);
				_threads[i].Start();

				Console.WriteLine("Started");
			}

			JoinAll();
			return Result();
		}

		/// <summary>
		/// Joins all.
		/// </summary>
		private void JoinAll() {
			foreach(var thread in _threads) {
				thread.Join();
			}
		}

		/// <summary>
		/// Result this instance.
		/// </summary>
		/// <returns>The result.</returns>
		private double Result() {
			double result = 0.0;
			foreach(Worker<char, double> worker in _workers) {
				result = result + worker.Result;
			}
			return result;
		}
	}
}
