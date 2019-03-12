using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Airport.Tests.CruiseTests
{
    [TestClass]
    public class CruiseportTests
    {
        SystemManager testManager = new SystemManager();

        [TestMethod]
        public void Create_Cruiseport_Success()
        {
            string result = testManager.CreatePort("cruiseport", "DEN");

            Assert.AreEqual("Success: cruiseport DEN Created!", result);
        }

        [TestMethod]
        public void Create_Cruiseport_Name_Greater_Than_Three_Letters_Fails()
        {
            string result = testManager.CreatePort("cruiseport", "DENG");

            Assert.AreEqual("Error: Could not create cruiseport, name: DENG must be exactly 3 letters!", result);
        }

        [TestMethod]
        public void Create_Cruiseport_Name_Less_Than_Three_Letters_Fails()
        {
            string result = testManager.CreatePort("cruiseport", "DE");

            Assert.AreEqual("Error: Could not create cruiseport, name: DE must be exactly 3 letters!", result);
        }

        [TestMethod]
        public void Create_Cruiseport_Name_Is_Empty_String_Fails()
        {
            string result = testManager.CreatePort("cruiseport", "");

            Assert.AreEqual("Error: Could not create cruiseport, name:  must be exactly 3 letters!", result);
        }

        [TestMethod]
        public void Create_Cruiseport_Name_Contains_Spaces_Fails()
        {
            string result = testManager.CreatePort("cruiseport", "B A");

            Assert.AreEqual("Error: Could not create cruiseport, name: B A cannot contain spaces!", result);
        }
    }
}
