using System;

namespace TPP.Concurrency.Synchronization {

    public class Color {

        private ConsoleColor color;

        public Color(ConsoleColor color) {
            this.color = color;
        }

        virtual public void Show() {
            ConsoleColor previousColor = Console.ForegroundColor;
            Console.ForegroundColor = this.color;
            Console.Write("{0}\t", this.color);
            Console.ForegroundColor = previousColor;
        }

    }
}
