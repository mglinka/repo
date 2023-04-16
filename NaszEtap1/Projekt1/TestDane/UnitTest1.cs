using TestDane;

namespace TestDane
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            //Testowanie Dane Api
            Assert.IsNotNull(DaneAbstractApi.CreateApi());
        }
    }


}