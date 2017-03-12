using System;
using System.Reflection;
using System.Dynamic;
using System.Collections.Generic;
using System.IO;
using System.Diagnostics;

namespace TPP.ObjectOrientation.Reflection {

    class Program {

        static void Main() {
            dynamic person = new ExpandoObject();
            person.FirstName = "John"; // addition of a field
            Console.WriteLine(person.FirstName );

            IDictionary<string, object> dict = GetDictionaryFromFile("../../person.txt");
            AssignProperties(person, dict);
            Console.WriteLine("{0} {1}, born on {2}/{3}/{4}, in {5}.",
                person.FirstName, person.Surname, 
                person.MonthBirth, person.DayBirth, person.YearBirth, 
                person.PlaceBirth);

            Func<int> getAge = () => (int)(DateTime.Now - new DateTime(person.YearBirth, person.MonthBirth, person.DayBirth)).TotalDays / 365;
            person.GetAge = getAge;
            Console.WriteLine("{0} {1} is {2} years old.", person.FirstName, person.Surname, person.GetAge());
        }
        
        private static void AssignProperties(dynamic myObj, IDictionary<string, object> dict) {
            foreach (var item in dict)
                ((IDictionary<string, object>)myObj)[item.Key] = item.Value;
        }


        private static IDictionary<string, object> GetDictionaryFromFile(string fileName) {
            IDictionary<string, object> dict = new Dictionary<string, object>();
            TextReader tr = new StreamReader(fileName);
            String line = null;
            while ((line = tr.ReadLine()) != null) {
                string[] words = line.Split(';');
                dict[words[0].Trim()] = ConvertValue(words[1].Trim(), words[2].Trim());
            }
            tr.Close(); 
            return dict;
        }

        private static object ConvertValue(string value, string type) {
            switch (type.ToLower()) {
                case "string": return value;
                case "int": return Convert.ToInt32(value);
                case "double": return Convert.ToDouble(value);
            }
            Debug.Assert(false);
            return null;

        }

    }

}
