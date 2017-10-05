using System;
using System.Collections.Generic;
using System.Web.Mvc;
using FakeItEasy;
using Management.Controllers;
using Management.Library;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;

namespace Services.Tests.Controllers
{
    [TestFixture()]
    public class WhenValidatingFamilyController
    {
        [Test]
        public void Index()
        {
            // Arrange
            var context = A.Fake<IServiceLayer>();
            FamilyController controller = new FamilyController(context);

            A.CallTo(() => context.GetData<ServiceContracts.Family>(A<string>.Ignored)).Returns(new List<ServiceContracts.Family>
            {
                new ServiceContracts.Family {FamilyId = 1, FamilyName = "A", FamilyEmail = "A@A.com"},
                new ServiceContracts.Family {FamilyId = 2, FamilyName = "B", FamilyEmail = "B@B.com"}
            });


            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Model);
            var responseModelCount = (List<ServiceContracts.Family>)result.Model;
            Assert.That(responseModelCount.Count == 2, $"Model Response was {responseModelCount.Count}.");
        }
        [Test]
        public void Create()
        {
            // Arrange
            var context = A.Fake<IServiceLayer>();
            FamilyController controller = new FamilyController(context);
            //controller.ModelState.Clear();
            //controller.ModelState.AddModelError("Error1", new Exception("Error Message"));
            var createFamily = new ServiceContracts.Family {FamilyId = 1, FamilyName = "B", FamilyEmail = "B@B.com"};

            A.CallTo(() => context.SendData<ServiceContracts.Family>(A<string>.Ignored, A<ServiceContracts.Family>.Ignored)); //Returns(null);


            // Act
            ActionResult result = controller.Create(createFamily) as ActionResult;

            // Assert
            Assert.IsNotNull(result);
            //Assert.IsNotNull(result.Model);
           // var responseModelCount = (List<ServiceContracts.Family>)result.Model;
            //Assert.That(responseModelCount.Count == 2, $"Model Response was {responseModelCount.Count}.");
        }

        [Test]
        public void Create_With_modelError()
        {
            // Arrange
            var context = A.Fake<IServiceLayer>();
            FamilyController controller = new FamilyController(context);
            controller.ModelState.Clear();
            controller.ModelState.AddModelError("Error1", new Exception("Error Message"));
            var createFamily = new ServiceContracts.Family { FamilyId = 1, FamilyName = "B", FamilyEmail = "B@B.com" };

            A.CallTo(() => context.SendData<ServiceContracts.Family>(A<string>.Ignored, A<ServiceContracts.Family>.Ignored)); //Returns(null);


            // Act
            ActionResult result = controller.Create(createFamily) as ActionResult;

            // Assert
            Assert.IsNotNull(result);
            //Assert.IsNotNull(result.Model);
            // var responseModelCount = (List<ServiceContracts.Family>)result.Model;
            //Assert.That(responseModelCount.Count == 2, $"Model Response was {responseModelCount.Count}.");
        }
    }
}
