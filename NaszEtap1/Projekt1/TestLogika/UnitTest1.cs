using Logika;

namespace TestLogika
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestLogikaApiKonstruktor()
        {
            Assert.IsNotNull(LogikaAbstractApi.CreateApi());
        }

        [TestMethod]
        public void TestTworzKuleIleKulek()
        {
            LogikaAbstractApi api = LogikaAbstractApi.CreateApi();
            Assert.AreEqual(0, api.ileKulek());
            api.tworzKule();
            Assert.AreEqual(1, api.ileKulek());
        }

        [TestMethod]
        public void TestPoruszaj()
        {
            LogikaAbstractApi api = LogikaAbstractApi.CreateApi();
            api.tworzKule();
            int wspX = api.zwrocXkulki(0);
            int wspY = api.zwrocYkulki(0);
            api.poruszajKulkami();
            Assert.AreNotEqual(wspX, api.zwrocXkulki(0));
            Assert.AreNotEqual(wspY, api.zwrocYkulki(0));
        }
    }
}