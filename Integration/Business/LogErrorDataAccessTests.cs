using Integration.Utilities.win10Core.Business.DataAccess;
using NUnit.Framework;
using win10Core.Business.Model;

namespace Integration.Business
{
    [TestFixture()]
    class LogErrorDataAccessTests
    {
        [Test]
        public void Validate_DBQuery()
        {
            var myresponse = new DBContextHelper();
            var response = myresponse.GetQuery<Customer>("Select CustomerID, FirstName, LastName from Customer");

            Assert.That(response.Count>=0);

        }
    }
}
