using System;

namespace TPP.Functional.Delegates {

    /// <summary>
    /// Example application that uses delegates as an implementation of the Observer design pattern.
    /// </summary>
    class Program {
        static void Main() {
            Button button = new Button();

            // * The following two objects will be interested in being called
            //   when the button is clicked
            Integer integer = new Integer(3);
            Controller controller = new Controller();

            // * The two objects are registered in the button.
            Console.WriteLine("Two delegates are registered...");
            // * Old syntax using new...
            button.AddMethod(new Button.ButtonClick(integer.Show));
            // * ... New syntax without new
            button.AddMethod(controller.OnClick);

            // * The event is triggered
            button.Click();

            // * One delegate is unregistered
            Console.WriteLine("The integer object is unregistered...");
            button.RemoveMethod(integer.Show);

            // * The event is triggered once again
            button.Click();
        }
    }

}
