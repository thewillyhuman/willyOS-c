using System;
using System.Text;

namespace ClasesObjetos {

    /// <summary>
    /// Demostración de uso de strings y StringBuilder
    /// </summary>
    class Program {

        static void Main(string[] args) {
            // * Tipo string
            string s1 = "hola";
            // * Clase String
            System.String s2 = " mundo";
            // * s3 es una nueva cadena, concatenación de s1 y s2
            String s3 = s1 + s2;
            // * s1 y s2 no se modifican
            Console.WriteLine("{0}\n{1}\n{2}\n", s1, s2, s3);

            // * Algunos métodos y propiedades de String
            Console.WriteLine("Longitud: {0}", s3.Length);
            Console.WriteLine("En minúsculas: {0}", s3.ToLower());
            Console.WriteLine("Subcadena de 2 a 4 caracteres: {0}", s3.Substring(2, 2));
            Console.WriteLine("¿Es nula o está vacía?: {0}", String.IsNullOrEmpty(s3));
            string s4 = String.Format("S1: \"{0}\" + S2: \"{1}\" = S3: \"{2}\"\n", s1, s2, s3);
            Console.WriteLine(s4);

            // * Las cadenas que empiezan con @ permiten definir cadenas de más de una línea
            string párrafo =  @"
        Si la misión del W3C es guiar la Web hacia su máximo potencial, 
        la nuestra es formar a los profesionales e investigadores 
        capaces de llevarlo a cabo, 
        integrando aplicaciones de Internet, 
        construyendo arquitecturas orientadas a servicios, 
        administrando servidores de información y creando sitios web usables, 
        accesibles y que cumplan con los estándares.
        ";
            Console.WriteLine(párrafo);

            // * Cadenas mutables: StringBuilder
            StringBuilder sb = new StringBuilder();
            sb.Append(s1);
            sb.AppendFormat(" más s2: {0}", s2);
            sb.AppendLine(s3);
            Console.WriteLine(sb);
        }
    }


}
