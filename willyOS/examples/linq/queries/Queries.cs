using System;
using System.Collections.Generic;
using System.Linq;
using examples.linq;
using Foundation;

namespace emxamples.linq {

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
			query.Homework5();
		}

		public void Query1() {
			// Modify this query to show the names of the employees older than 50 years
			var employees = model.Employees;
			var employeesWith50 = model.Employees.Where(e => e.Age > 50);
			var names = employeesWith50.Select(e => e.Name);

			Console.WriteLine("Employees:");
			Show(names);
		}

		public void Query2() {
			// Show the name and email of the employees who work in Asturias
			/* var employees = model.Employees.Where(e => e.Province.Equals("Asturias")).Select(e => new NameAndEmail { Name = e.Name
                 , Email = e.Email });*/

			var employees = model.Employees.Where(e => e.Province.Equals("Asturias")).Select(e => new {
				Name = e.Name,
				Email = e.Email,
				Age = e.Age
			});

			Console.WriteLine("Employees:");
			Show(employees);
		}

		// Notice: from now on, check out http://msdn.microsoft.com/en-us/library/9eekhta0.aspx
		public void Query3() {
			// Show the names of the departments with more than one employee 18 years old and beyond; 
			// the department should also have any office number starting with "2.1"

			// Count(Predicate): Counts the number of elements that fulfills a predicate.
			// Any(Predicate): Tells if any of the elements fulfills a given predicate.

			var employees = model.Departments.Where(
				d => d.Employees.Count(
					e => e.Age > 18
					) > 1
					).Where(
				d => d.Employees.Any(
					e => e.Office.Number.StartsWith("2.1", StringComparison.Ordinal))).Count();

			Console.WriteLine("Employees:" + employees);
			//Show(employees);
		}

		private void Query4() {
			// Show the phone calls of each employee. 
			// Each line should show the name of the employee and the phone call duration in seconds.

			var result = model.PhoneCalls.Where(
				call => model.Employees.Any(
					e => e.TelephoneNumber.Equals(call.SourceNumber)));

			var result2 = result.Select(
				call => new {
					Duration = call.Seconds,
					Name = model.Employees.First(e => e.TelephoneNumber.Equals(call.SourceNumber))
				});

			Show(result2);
		}

		private void Query4b() {
			// Show the phone calls of each employee. 
			// Each line should show the name of the employee and the phone call duration in seconds.

			var result = model.PhoneCalls.Join(
				model.Employees,
				call => call.SourceNumber,
				emp => emp.TelephoneNumber,
				(call, emp) => new {
					Name = emp.Name,
					Duration = call.Seconds
				});

			Show(result);
		}

		private void Query5() {
			// Show, grouped by each province, the name of the employees 
			// (both province and employees must be shown lexicographically ordered)

			var groups = model.Employees.GroupBy(e => e.Province);
			var ordered = groups.OrderBy(g => g.Key);

			foreach (var group in ordered) {
				Console.WriteLine(group.Key);
				var orderedEmployees = group.OrderBy(e => e.Name);
				foreach (var emp in orderedEmployees) {
					Console.WriteLine("\t" + emp.Name);
				}
			}

			// Show(ordered);
		}

		/************ Homework **********************************/

		private void Homework1() {
			// Show, ordered by age, the names of the employees in the Computer Science department, 
			// who have an office in the Faculty of Science, 
			// and who have done phone calls longer than one minute

			var result = model.Employees.Where(
				d => d.Office.Building.Equals("Faculty of Science") &&
				d.Department.Name.Equals("Computer Science")
			);

			var calls = model.PhoneCalls.Where(call => call.Seconds > 60);

			var result2 = calls.Join(
				result,
				call => call.SourceNumber,
				emp => emp.TelephoneNumber,
				(call, emp) => new {
					Name = emp.Name,
					Age = emp.Age
				});

			result2.OrderBy(emp => emp.Age);

			Show(result2);
		}

		private void Homework2() {
			// Show the summation, in seconds, of the phone calls done by the employees of the Computer Science department

			var freaks = model.Employees.Where(e => e.Department.Name.Equals("Computer Science"));
			Show(freaks);
			var callsByFreak = model.PhoneCalls.Join(
				freaks,
				call => call.SourceNumber,
				emp => emp.TelephoneNumber,
				(call, freak) => new {
					Name = freak.Name,
					Duration = call.Seconds
				}
			);
			Show(callsByFreak);
			var totalDuration = callsByFreak.Sum(call => call.Duration);

			Console.WriteLine(totalDuration);
		}

		private void Homework3() {
			// Show the phone calls done by each department, ordered by department names. 
			// Each line must show “Department = <Name>, Duration = <Seconds>”

			var phonecallsAndPeople = model.PhoneCalls.Join(
				model.Employees,
				call => call.SourceNumber,
				emp => emp.TelephoneNumber,
				(call, freak) => new {
					Freak = freak,
					Call = call
				}
			);

			var result = phonecallsAndPeople.GroupBy(dep => dep.Freak.Department.Name);

			foreach (var dep in result) {
				Console.WriteLine(dep.Key);
				var sum = dep.Sum(s => s.Call.Seconds);
				Console.WriteLine("\t" + sum);
			}
		}

		private void Homework4() {
			// Show the departments with the youngest employee, 
			// together with the name of the youngest employee and his/her age 
			// (more than one youngest employee may exist)
			var youngest = model.Employees.Where(e => e.Age.Equals(model.Employees.Min().Age));
			foreach (var p in youngest) {
				Console.WriteLine(p.Department + " : " + p.Name + "  " + p.Age);
			}
		}

		private void Homework5() {
			// Show the greatest summation of phone call durations, in seconds, 
			// of the employees in the same department, together with the name of the department 
			// (it can be assumed that there is only one department fulfilling that condition)

			var phonecallsAndPeople = model.PhoneCalls.Join(
				model.Employees,
				call => call.SourceNumber,
				emp => emp.TelephoneNumber,
				(call, freak) => new {
					Freak = freak,
					Call = call
				}
			);

			var result = phonecallsAndPeople.GroupBy(dep => dep.Freak.Department.Name);

			NSDictionary<string, int> calls = new NSDictionary<string, int>();

			foreach (var dep in result) {
				calls.Add(dep.Key, dep.Sum(s => s.Call.Seconds));
			}
			var ordered = calls.OrderByDescending(c => c.Value);
			Console.WriteLine(ordered.First().Key + " : " + ordered.First().Value);
		}


	}

}
