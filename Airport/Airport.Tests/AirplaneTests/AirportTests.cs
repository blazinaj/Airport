using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Airport.Tests
{
    [TestClass]
    public class AirportTests
    {
        SystemManager testManager = new SystemManager();

        [TestMethod]
        public void Create_Airport_Success()
        {
            string result = testManager.CreatePort("airport", "DEN");

            Assert.AreEqual("Success: airport DEN Created!", result);
        }

        [TestMethod]
        public void Create_Airport_Name_Less_Than_Three_Letters_Fails()
        {
            string result = testManager.CreatePort("airport", "DENG");

            Assert.AreEqual("Error: Could not create airport, name: DENG must be exactly 3 letters!", result);
        }

        [TestMethod]
        public void Create_Airport_Name_Greater_Than_Three_Letters_Fails()
        {
            string result = testManager.CreatePort("airport", "DENG");

            Assert.AreEqual("Error: Could not create airport, name: DENG must be exactly 3 letters!", result);
        }

        [TestMethod]
        public void Create_Airport_Name_Is_Empty_String_Fails()
        {
            string result = testManager.CreatePort("airport", "");

            Assert.AreEqual("Error: Could not create airport, name:  must be exactly 3 letters!", result);
        }

        [TestMethod]
        public void Create_Airport_Name_Contains_Spaces_Fails()
        {
            string result = testManager.CreatePort("airport", "B A");

            Assert.AreEqual("Error: Could not create airport, name: B A cannot contain spaces!", result);
        }
    }
}
