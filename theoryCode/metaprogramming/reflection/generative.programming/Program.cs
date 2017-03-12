using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.CodeDom.Compiler;
using System.Reflection;

namespace TPP.ObjectOrientation.Reflection {

    static class Program {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            FormFunction formFunction = new FormFunction();
            Application.Run(formFunction);
            MethodInfo function = Compile(formFunction.FunctionBody);
            Application.Run(new FormGenerativeProgramming(function, formFunction.From, formFunction.To, formFunction.Increment));
        }

        static MethodInfo Compile(string functionBody) {
            string code =
                "using System; " +
                "public class Generated {" +
                "  static public double f(double x) {" +
                "           return " + functionBody + ";" +
                "  }" +
                 "}";
            CompilerResults compilerResults = Compiler.Compile(code);
            MethodInfo function = Compiler.LoadFunction(compilerResults, "Generated", "f");
            return function;
        }

    }
}
