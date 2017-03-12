using System;

namespace ClasesObjetos {
    /// <summary>
    /// Ejemplo de clase que ofrece primitivas de ángulos
    /// </summary>
    public class Angulo {

        /// <summary>
        /// Radianes del ángulo
        /// </summary>
        private double Radianes;

        /// <summary>
        /// Método publico para devolver los radianes de un ángulo
        /// </summary>
        public double GetRadianes() {
            return this.Radianes;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="radianes">Ángulo en radianes</param>
        public Angulo(double radianes) {
            this.Radianes = radianes;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="grados">Grados sexasegimales</param>
        public Angulo(int grados) {
            Radianes = grados / 180.0 * Math.PI;
        }

        /// <summary>
        /// Prueba de un destructor
        /// </summary>
        ~Angulo() {
            Console.WriteLine("Ejecutando el destructor de un ángulo de {0} radianes.", Radianes);
        }

        /// <summary>
        /// Calcula el seno de un ángulo
        /// </summary>
        /// <returns>El seno del objeto implícito</returns>
        public double Seno() {
            return Math.Sin(Radianes);
        }

        /// <summary>
        /// Calcula el coseno de un ángulo
        /// </summary>
        /// <returns>El coseno del ángulo</returns>
        public double Coseno() {
            return Math.Cos(Radianes);
        }

        /// <summary>
        /// Calcula la tangente de un ángulo
        /// </summary>
        /// <returns>La tangente del objeto implícito</returns>
        public double Tangente() {
            return Seno() / Coseno();
        }


        /// <summary>
        /// Prueba de la clase
        /// </summary>
        static void Main() {
            Angulo angulo1 = new Angulo(180), // * Grados
                    angulo2 = new Angulo(Math.PI); // * Radianes
            Console.WriteLine("Seno:     {0,6:F} {1,6:F}", angulo1.Seno(), angulo2.Seno());
            Console.WriteLine("Coseno:   {0,6:F} {1,6:F}", angulo1.Coseno(), angulo2.Coseno());
            Console.WriteLine("Tangente: {0,6:F} {1,6:F}", angulo1.Tangente(), angulo2.Tangente());
        }
    }
}
