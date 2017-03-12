using System;
using System.Diagnostics;

namespace TPP.Concurrency.ProcessesThreads {

    /// <summary>
    /// Example use of the Process class
    /// </summary>
    class ProcessWrapper {
        /// <summary>
        /// The process being wrapped
        /// </summary>
        private Process process;

        /// <summary>
        /// Name of the process
        /// </summary>
        public string Name {
            get { return this.process.ProcessName; }
        }

        /// <summary>
        /// Threads in the process
        /// </summary>
        public ProcessThreadCollection Threads {
            get { return this.process.Threads; }
        }

        /// <summary>
        /// Starts a new process
        /// </summary>
        /// <returns>Whether the process was successfully started</returns>
        public bool Start(string nameOfExecutable, string parameter) {
            try {
                this.process = Process.Start(nameOfExecutable, parameter);
            }
            catch (Exception) {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Kills the running process
        /// </summary>
        /// <returns>Whether the process was killed</returns>
        public bool Kill() {
            if (this.process == null)
                return false;
            try {
                this.process.Kill();
            }
            catch (InvalidOperationException) {
                return false;
            }
            return true;
        }


    }

}
