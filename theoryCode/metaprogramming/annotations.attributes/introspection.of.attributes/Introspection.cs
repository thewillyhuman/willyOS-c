using System;
using System.Reflection;

namespace TPP.ObjectOrientation.AnnotationsAttributes {

    class Introspector {
        static void Main(string[] args) {
            Assembly assembly = Assembly.Load("application.with.attributes");
            Type[] types = assembly.GetTypes();
            foreach (Type type in types) {
                Console.WriteLine("Information of the {0} class:", type);
                foreach(Object attribute in type.GetCustomAttributes(typeof(AuthorAttribute), inherit: false))
                    Console.WriteLine("\t{0}.", attribute);            
            }
        }
    }

}
