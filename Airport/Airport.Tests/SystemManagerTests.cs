using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Airport.Tests
{
    [TestClass]
    public class SystemManagerTests
    {
        [TestMethod]
        public void Create_Airport_Three_Letters_Success()
        {
            SystemManager testManager = new SystemManager();
            testManager.CreateAirport("DEN");
        }
    }
}
