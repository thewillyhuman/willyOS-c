using System;

namespace TPP.ObjectOrientation.Generics {

    /// <summary>
    /// Generic wrapper class
    /// </summary>
    /// <typeparam name="T">The type of the object to be wrapped</typeparam>
    class GenericClass<T> {
        private T field;

        public GenericClass(T field) {
            this.field = field;
        }

        public T get() {
            return field;
        }

        public void set(T field) {
            this.field = field;
        }

    }

    class Run {
        public static void Main() {
            GenericClass<int> myInteger = new GenericClass<int>(3);
            Console.WriteLine(myInteger.get());
            GenericClass<string> myString = new GenericClass<string>("hello");
            Console.WriteLine(myString.get());
        }
    }

}