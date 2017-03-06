using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace willyOS.tests.examples {

	class Query {

		private Model model = new Model();

		private static void Show<T>(IEnumerable<T> collection) {
			foreach (var item in collection) {
				Console.WriteLine(item);
			}
			Console.WriteLine("Number of items in the collection: {0}.", collection.Count());
		}

		static void Main(string[] args) {
			Query query = new Query();
			query.Query1();
		}

		[Test]
		public void Query1() {
			// Modify this query to show the names of the employees older than 50 years
			var employees = model.Employees;
			Console.WriteLine("Employees:");
			Show(employees);
		}

		private void Query2() {
			// Show the name and email of the employees who work in Asturias
		}

		// Notice: from now on, check out http://msdn.microsoft.com/en-us/library/9eekhta0.aspx

		private void Query3() {
			// Show the names of the departments with more than one employee 18 years old and beyond; 
			// the department should also have any office number starting with "2.1"
		}

		private void Query4() {
			// Show the phone calls of each employee. 
			// Each line should show the name of the employee and the phone call duration in seconds.
		}

		private void Query5() {
			// Show, grouped by each province, the name of the employees 
			// (both province and employees must be shown lexicographically ordered)
		}

		/************ Homework **********************************/

		private void Homework1() {
			// Show, ordered by age, the names of the employees in the Computer Science department, 
			// who have an office in the Faculty of Science, 
			// and who have done phone calls longer than one minute
		}

		private void Homework2() {
			// Show the summation, in seconds, of the phone calls done by the employees of the Computer Science department
		}

		private void Homework3() {
			// Show the phone calls done by each department, ordered by department names. 
			// Each line must show “Department = <Name>, Duration = <Seconds>”
		}

		private void Homework4() {
			// Show the departments with the youngest employee, 
			// together with the name of the youngest employee and his/her age 
			// (more than one youngest employee may exist)
		}

		private void Homework5() {
			// Show the greatest summation of phone call durations, in seconds, 
			// of the employees in the same department, together with the name of the department 
			// (it can be assumed that there is only one department fulfilling that condition)
		}


	}

}
