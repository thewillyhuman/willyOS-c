
namespace RWKit {

	public class RWOffice {

		public RWOffice(string number, string building) {
			Number = number;
			Building = building;
		}

		public string Number { get; private set; }
		public string Building { get; private set; }

		public override string ToString() {
			return string.Format("[Office: {0}\\{1}]", Number, Building);
		}
	}
}
