using win10Core.Business;
using win10Core.Business.DataAccess;
using win10Core.Business.Model;
using NUnit.Framework;

namespace Integration
{
    [TestFixture]
    public class UnitTest1
    {
        [Test]
        public void TestMethod1()
        {
            //Arrange
            var connection = ConfigHelper.GetSetting("DBConnection");
            var customerClient = new CustomerDataAccess(connection);
            //Act
            var insert = customerClient.Insert(new Customer() {CustomerId = 0, FirstName = "x1", LastName = "x1"});
            //Assert
            Assert.IsTrue(insert);

        }
    }
}
