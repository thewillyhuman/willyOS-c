using System;

namespace TPP.Concurrency.Synchronization {

    public class SynchronizedColor: Color {

        public SynchronizedColor(ConsoleColor color): base(color) {
        }

        override public void Show() {
            
            lock (Console.Out) {
                base.Show();
            }
        }

    }

}
 