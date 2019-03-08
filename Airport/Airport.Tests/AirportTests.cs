using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Airport.Tests
{
    class AirportTests
    {
        SystemManager testManager = new SystemManager();
        [global::Microsoft.VisualStudio.TestTools.UnitTesting.TestMethod]
        public void Create_Airport_Name_Not_Three_Letters_Fails()
        {
            string result = testManager.CreateAirport("BANG");

            Assert.AreEqual("Error: Could not create Airport, name: BANG must be exactly 3 letters!", result);
        }

        [global::Microsoft.VisualStudio.TestTools.UnitTesting.TestMethod]
        public void Create_Airport_Name_Success()
        {
            string result = testManager.CreateAirport("BOB");

            Assert.AreEqual("Success: Airport BOB Created!", result);
        }

        [global::Microsoft.VisualStudio.TestTools.UnitTesting.TestMethod]
        public void Create_Airport_Name_Already_Exists_Failure()
        {
            string result = testManager.CreateAirport("BOB");

            Assert.AreEqual("Error: Airport name: BOB already exists!", result);
        }
    }
}
