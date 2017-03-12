using System;

namespace TPP.Functional.Delegates {

    /// <summary>
    /// Class that registers a collection of methods to be invoked when an event is triggered.
    /// </summary>
    class Button {
        /// <summary>
        /// A new delegate type than receives no parameter and returns no value.
        /// </summary>
        public delegate void ButtonClick();

        /// <summary>
        /// A delegate instance that collects the methods to be invoked when the even its triggered.
        /// </summary>
        private ButtonClick methodsToBeCalled;

        /// <summary>
        /// Adds a new method to the methods to be called when the event is triggered.
        /// </summary>
        /// <param name="method">The method to be added</param>
        public void AddMethod(ButtonClick method) {
            methodsToBeCalled += method;
        }

        /// <summary>
        /// Removes a method from the methods to be called when the even its triggered.
        /// </summary>
        /// <param name="method">The method to be removed</param>
        public void RemoveMethod(ButtonClick method) {
            methodsToBeCalled -= method;
        }

        /// <summary>
        /// Simulates an event. When this method is called, the event is triggered.
        /// It calls all the registered methods.
        /// </summary>
        public void Click() {
            methodsToBeCalled();
        }
    }



}
