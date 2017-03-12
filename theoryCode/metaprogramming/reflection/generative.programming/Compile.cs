using System;
using System.CodeDom.Compiler;
using System.IO;
using Microsoft.CSharp;
using System.Reflection;

namespace TPP.ObjectOrientation.Reflection {

    public static class Compiler {

        /// <summary>
        /// Compiles a C# code into a library
        /// </summary>
        public static CompilerResults Compile(string code) {
            CompilerParameters CompilerParams = new CompilerParameters();
            string outputDirectory = Directory.GetCurrentDirectory();

            CompilerParams.GenerateInMemory = true;
            CompilerParams.TreatWarningsAsErrors = false;
            CompilerParams.GenerateExecutable = false;
            CompilerParams.CompilerOptions = "/optimize";

            string[] references = { "System.dll" };
            CompilerParams.ReferencedAssemblies.AddRange(references);

            CSharpCodeProvider provider = new CSharpCodeProvider();
            CompilerResults compile = provider.CompileAssemblyFromSource(CompilerParams, new string[] {code});

            if (compile.Errors.HasErrors) {
                string text = "Compile error: ";
                foreach (CompilerError ce in compile.Errors) {
                    text += "rn" + ce.ToString();
                }
                throw new Exception(text);
            }

            return compile;
        }


        /// <summary>
        /// Loads a method of a class in the compiled code
        /// </summary>
        public static MethodInfo LoadFunction(CompilerResults compileResults, string className, string functionName) {
            Module module = compileResults.CompiledAssembly.GetModules()[0];
            Type mt = null;
            MethodInfo methInfo = null;

            if (module != null) {
                mt = module.GetType(className);
            }

            if (mt != null) {
                methInfo = mt.GetMethod(functionName);
            }

            return methInfo;
        }

    }
}