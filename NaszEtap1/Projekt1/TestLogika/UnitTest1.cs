using Logika;
using Dane;

namespace TestLogika
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestLogikaApiKonstruktor()
        {
            Assert.IsNotNull(LogikaAbstractApi.CreateApi(DaneAbstractApi.CreateApi()));
        }

        [TestMethod]
        public void TestTworzKule()
        {
            LogikaAbstractApi api = LogikaAbstractApi.CreateApi(DaneAbstractApi.CreateApi());
            api.TworzKole(1,20, 100, 3.0f, 5.0f, 30, 2);
            Assert.AreEqual(100, api.PodajXKulki(0));
            Assert.AreEqual(20, api.PodajYKulki(0));
        }
    }
}