using System.Web.Mvc;
using FakeItEasy;
using Management.Controllers;
using Management.Library;
using NUnit.Framework;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace Management.Tests.Controllers
{
    [TestFixture()]
    public class HomeControllerTest
    {
        [Test]
        public void Index()
        {
            // Arrange
            var context = A.Fake<IServiceLayer>();
            HomeController controller = new HomeController(context);

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void Index2()
        {
            // Arrange
            var context = A.Fake<IServiceLayer>();
            HomeController controller = new HomeController(context);

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Home Page", result.ViewBag.Title);
        }

        [Test]
        public void About()
        {
            // Arrange
            var context = A.Fake<IServiceLayer>();
            HomeController controller = new HomeController(context);

            // Act
            ViewResult result = controller.About() as ViewResult;

            // Assert
            Assert.AreEqual("Your application description page.", result.ViewBag.Message);
        }

        [Test]
        public void Contact()
        {
            // Arrange
            var context = A.Fake<IServiceLayer>();
            HomeController controller = new HomeController(context);

            // Act
            ViewResult result = controller.Contact() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
