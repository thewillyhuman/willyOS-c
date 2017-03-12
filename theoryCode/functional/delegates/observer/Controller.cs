using System;

namespace TPP.Functional.Delegates {

    /// <summary>
    /// A class that will be registered to the Button's click event
    /// </summary>
    class Controller {

        /// <summary>
        /// The method that will be called when the event is triggered.
        /// </summary>
        public void OnClick() {
            Console.WriteLine("The controller responds to the click event, accessing the model.");
        }

    }


}
