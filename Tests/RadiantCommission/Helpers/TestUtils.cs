using RadiantCommission.Helpers;

namespace Tests.RadiantCommission.Helpers
{
    [TestClass]
    public sealed class TestUtils
    {
        // Testing the 10 method - I don't crae about negatives atm because its only internal

        /// <summary>
        /// Test that the value returned by <see cref="Utils.GetRandom10Number(int, int)"/>
        /// is a factor of 10
        /// </summary>
        [TestMethod]
        public void TestRandom10_10to70_ReturnsFactorOf10()
        {
            int num = Utils.GetRandom10Number(10, 70);
            float remainder = num % 10;
            Assert.AreEqual(0, remainder);
        }

        /// <summary>
        /// Test to that <see cref="Utils.GetRandomNumber(int, int)"/> can 
        /// return the value passed as max
        /// </summary>
        /// <remarks>Passing 30 as max, should return 30 at least once</remarks>
        [TestMethod]
        public void TestRandom10_20to30_CanReturnMax()
        {
            int min = 20; int max = 30;
            bool wasMax = false;

            // run a bunch of times to ensure there's a chance for 30
            for (int i = 0; i < 10; i++)
            {
                if (Utils.GetRandom10Number(min, max) == max)
                    wasMax = true;
            }
            Assert.IsTrue(wasMax);
        }

        /// <summary>
        /// Test to that <see cref="Utils.GetRandomNumber(int, int)"/> can 
        /// return the value passed as min
        /// </summary>
        /// <remarks>Passing 20 as min, should return 20 at least once</remarks>
        [TestMethod]
        public void TestRandom10_20to30_CanReturnMin()
        {
            int min = 20; int max = 30;
            bool wasMin = false;

            // run a bunch of times to ensure there's a chance for 20
            for (int i = 0; i < 10; i++)
            {
                if (Utils.GetRandom10Number(min, max) == min)
                    wasMin = true;
            }
            Assert.IsTrue(wasMin);
        }

        /// <summary>
        /// Test to that <see cref="Utils.GetRandomNumber(int, int)"/> will 
        /// never return a value greater than max
        /// </summary>
        /// <remarks>Passing 30 as min, should never return higher than that</remarks>
        [TestMethod]
        public void TestRandom10_20to30_NeverReturnsOverMax()
        {
            int min = 20; int max = 30;
            bool wasOverMax = false;

            // run a bunch of times
            for (int i = 0; i < 10; i++)
            {
                if (Utils.GetRandom10Number(min, max) > max)
                    wasOverMax = true;
            }
            Assert.IsFalse(wasOverMax);
        }
    }
}
