using ProjektEtap0;
namespace TestProjektEtap0
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestAddMethod()
        {
            Calculator calculator = new Calculator();
            Assert.AreEqual(5, calculator.add(3, 2));
        }

        [TestMethod]
        public void TestSubstractMethod() 
        {
            Calculator calculator = new Calculator();
            Assert.AreEqual(6, calculator.subtract(11, 5));
        }

        [TestMethod]
        public void TestMultiplyMethod() 
        {
            Calculator calculator = new Calculator();
            Assert.AreEqual(24, calculator.multiply(6, 4));
        }

        [TestMethod]
        public void TestDivideMethod()
        {
            Calculator calculator = new Calculator();
            Assert.AreEqual(2, calculator.divide(10, 5));
        }

        [TestMethod]
        public void TestDivideByZeroExceptionMethod()
        {
            Calculator calculator = new Calculator();
            Assert.ThrowsException<DivideByZeroException>(() => calculator.divide(10, 0));
        }
    }
}