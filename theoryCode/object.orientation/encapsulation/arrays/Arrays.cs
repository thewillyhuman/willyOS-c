/* 
 * Note: This project makes use of the Angle class defined in the constructor.destructor project
 * To access one assembly from another one, you have to add a reference to it
 * In order to do that, go to the project you want to add the reference; right-click and select "add reference"
 * Then, select the “project” tab and the “constructor.destructor” project
 * Remember that, to access a class from outside its assembly, it must be public (Angle)
 */


/// <summary>
/// Multidimensional array demo
/// </summary>
/// 

using System;

namespace TPP.ObjectOrientation.Encapsulation {

    class ArrayDemo {

        /// <summary>
        /// One dimension
        /// </summary>
        internal static void Run() {
            // * Initialization and declaration

            int[] arrayEnteros; // * Reference declaration
            arrayEnteros = new int[10]; // * Construction (all the integers are 0)

            // * Declaration and initialization
            bool[] logicArray = { true, false };

            // * Array of objects
            // * Fist, the reference is declared
            Angle[] quadrant;
            // * We build the objec (5 references = null)
            quadrant = new Angle[5];
            // * We create each angle
            quadrant[0] = new Angle(0);
            quadrant[1] = new Angle(30);
            quadrant[2] = new Angle(45);
            quadrant[3] = new Angle(60);
            quadrant[4] = new Angle(90);

            // * Everything in a single line
            Angle[] angles ={ new Angle(0),new Angle(90),new Angle(180),
						new Angle(270),new Angle(360) };

            // * We show the array in the console, whatever its size is (using Length)
            for (int i = 0; i < angles.Length; i++) {
                Console.Write("Angle: " + angles[i].GetRadians());
                Console.Write(", sine: " + angles[i].Sine());
                Console.Write(", cosine: " + angles[i].Cosine());
                Console.WriteLine(".");
            }

            // * Let's use foreach
            foreach (Angle angle in angles) {
                Console.WriteLine("Angle: " + angle.GetRadians());
            }

        }

    }
}