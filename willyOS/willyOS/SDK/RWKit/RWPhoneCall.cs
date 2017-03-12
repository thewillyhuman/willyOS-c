using System;

namespace RWKit {

	public class RWPhoneCall {

		public DateTime Date { get; set; }

		public string SourceNumber { get; set; }

		public string DestinationNumber { get; set; }

		public int Seconds { get; set; }

		public override string ToString() {
			return string.Format("[Phone call: from {0} to {1}]", SourceNumber, DestinationNumber);
		}
	}
}
