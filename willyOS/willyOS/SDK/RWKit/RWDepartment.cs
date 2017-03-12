using System.Collections.Generic;

namespace RWKit {

	public class RWDepartment {

		public RWDepartment(string name, IEnumerable<RWEmployee> employees) {
			Name = name;
			Employees = employees;
		}

		public string Name { get; private set; }

		public IEnumerable<RWEmployee> Employees { get; private set; }

		public override string ToString() {
			return string.Format("[Department: {0}]", Name);
		}
	}
}
