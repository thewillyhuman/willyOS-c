using System;
using System.Reflection;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Soap;
using System.Runtime.InteropServices;

namespace TPP.ObjectOrientation.AnnotationsAttributes {

    class UseOfAttributes {

        /// <summary>
        /// Attribute obsolete is considered by Visual Studio to show warnings.
        /// </summary>
        [Obsolete("Use m_v2 instead (m is obsolete).")]
        public static void m() {
        }
        public static void m_v2() {
        }

        /// <summary>
        /// DllImport attribute is used to acces native DLLs.
        /// </summary>
        [DllImport("kernel32.dll")]
        public static extern bool Beep(int frequency, int duration);

        public static void Main() {
            // * Obsolete
            m();
            // * Serializable
            Person pepe = new Person(19123456, "John", "Doe", 23);
            Stream stream = File.Open("data.xml", FileMode.Create);
            SoapFormatter formatter = new SoapFormatter();
            formatter.Serialize(stream, pepe);
            stream.Close();
            // * DllImport
            Beep(1000, 200);
        }
    }


    /// <summary>
    /// Tells that the following class can be serialized
    /// </summary>
    [Serializable()]
    public class Person {

        public uint IDNumber;
        public string firstName;
        public string surname;

        /// <summary>
        /// The following field should not be serialized
        /// </summary>
        [NonSerialized()]
        public byte age;

        public Person(uint idNumber, string firstName, string surname, byte age) {
            this.IDNumber = idNumber;
            this.surname = surname;
            this.firstName = firstName;
            this.age = age;
        }
    }



}