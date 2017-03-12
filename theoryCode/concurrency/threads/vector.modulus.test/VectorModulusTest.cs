using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TPP.Concurrency.Threads {

    [TestClass]
    public class VectorModulusTest {

        /// <summary>
        /// The vector used to test the implementation
        /// </summary>
        private short[] vector;

        [TestInitialize]
        public void Initialize() {
            this.vector = VectorModulusProgram.CreateRandomVector(10000, -10, 10);
        }

        /// <summary>
        /// Computes the vector modulus sequentially to compare the result later on
        /// </summary>
        private double ComputeModulus() {
            long result = 0;
            foreach (short element in this.vector)
                result += element*element;
            return Math.Sqrt(result);
        }

        private const int DECIMAL_PRECISION = 1000;

        [TestMethod]
        public void SingleThreadTest() {
            Master master = new Master(this.vector, 1);
            Assert.AreEqual((long)(master.ComputeModulus() * DECIMAL_PRECISION), (long)(this.ComputeModulus() * DECIMAL_PRECISION));
        }

        [TestMethod]
        public void TenThreadTest() {
            Master master = new Master(this.vector, 10);
            Assert.AreEqual((long)(master.ComputeModulus() * DECIMAL_PRECISION), (long)(this.ComputeModulus() * DECIMAL_PRECISION));
        }

        [TestMethod]
        public void MaxNumberOfThreadsTest() {
            Master master = new Master(this.vector, this.vector.Length);
            Assert.AreEqual((long)(master.ComputeModulus() * DECIMAL_PRECISION), (long)(this.ComputeModulus() * DECIMAL_PRECISION));
        }

    }
}
