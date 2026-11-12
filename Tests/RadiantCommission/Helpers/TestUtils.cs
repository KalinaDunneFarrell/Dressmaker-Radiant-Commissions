using RadiantCommission.Helpers;

namespace Tests.RadiantCommission.Helpers
{
    [TestClass]
    public sealed class TestUtils
    {
        // Testing the 10 method - I don't crae about negatives atm because its only internal

        [TestMethod]
        public void TestRandom10_10to20_Returns10or20()
        {
            int num = Utils.GenerateRandom10Number(10, 20);
            bool pass = (num == 10 || num == 20);
            Assert.IsTrue(pass);
        }

        [TestMethod]
        public void TestRandom10_10to70_ReturnsFactorOf10()
        {
            int num = Utils.GenerateRandom10Number(10, 70);
            float remainder = num % 10;
            Assert.AreEqual(0, remainder);
        }
    }
}
