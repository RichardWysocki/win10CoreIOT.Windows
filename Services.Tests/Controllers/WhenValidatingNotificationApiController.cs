using System;
using System.Collections.Generic;
using System.Linq;
using FakeItEasy;
using NUnit.Framework;
using ServiceContracts.Contracts;
using Services.ControllersApi;
using win10Core.Business.DataAccess.Interfaces;
using win10Core.Business.Engine;
using Assert = NUnit.Framework.Assert;

namespace Services.Tests.Controllers
{
    [TestFixture()]
    public class WhenValidatingNotificationApiController
    {
        [Test]
        public void NewRegisteredGifts_CallsGetNewRegisteredGifts_ReturnGifts()
        {
            // 
            var emailEngine = A.Fake<IEmailEngine>();
            var giftDataAccess = A.Fake<IGiftDataAccess>();
            var familyDataAccess = A.Fake<IFamilyDataAccess>();
            var kidDataAccess = A.Fake<IKidDataAccess>();
            NotificationApiController controller = new NotificationApiController(emailEngine, giftDataAccess, familyDataAccess, kidDataAccess);

            var returndata = new List<win10Core.Business.Model.Gift>()
            {
                new win10Core.Business.Model.Gift {GiftId = 1, GiftName = "A"},
                new win10Core.Business.Model.Gift {GiftId = 2, GiftName = "B"}

            };

            A.CallTo(() => giftDataAccess.GetEmailList(A<bool>.Ignored)).Returns(returndata);

            // Act
            var result = controller.GetNewRegisteredGifts("true");

            // Assert
            Assert.IsNotNull(result, "Result should not be null");
            Assert.IsInstanceOf(typeof(IEnumerable<Gift>), result, "Type should be the same");
            Assert.That(result.Count()==2, "Result count should be 2");
        }

        [Test]
        public void NoNewRegisteredGifts_CallsGetNewRegisteredGifts_ReturnNoGifts()
        {
            // 
            var emailEngine = A.Fake<IEmailEngine>();
            var giftDataAccess = A.Fake<IGiftDataAccess>();
            var familyDataAccess = A.Fake<IFamilyDataAccess>();
            var kidDataAccess = A.Fake<IKidDataAccess>();
            NotificationApiController controller = new NotificationApiController(emailEngine, giftDataAccess, familyDataAccess, kidDataAccess);

            // ReSharper disable once CollectionNeverUpdated.Local
            var returndata = new List<win10Core.Business.Model.Gift>();

            A.CallTo(() => giftDataAccess.GetEmailList(A<bool>.Ignored)).Returns(returndata);

            // Act
            var result = controller.GetNewRegisteredGifts("true");

            // Assert
            Assert.IsNotNull(result, "Result should not be null");
            Assert.IsInstanceOf(typeof(IEnumerable<Gift>), result, "Type should be the same");
            Assert.That(!result.Any(), "Result count should be 0");

        }

        [Test]
        public void Calling_NofityParentsofNewGift_withNoGift_ThrowException()
        {
            // 
            var emailEngine = A.Fake<IEmailEngine>();
            var giftDataAccess = A.Fake<IGiftDataAccess>();
            var familyDataAccess = A.Fake<IFamilyDataAccess>();
            var kidDataAccess = A.Fake<IKidDataAccess>();
            NotificationApiController controller = new NotificationApiController(emailEngine, giftDataAccess, familyDataAccess, kidDataAccess);

            //var returndata = new List<win10Core.Business.Model.Gift>()
            //{
            //    new win10Core.Business.Model.Gift {GiftId = 1, GiftName = "A"},
            //    new win10Core.Business.Model.Gift {GiftId = 2, GiftName = "B"}

            //};

            //A.CallTo(() => giftDataAccess.GetEmailList(A<bool>.Ignored)).Returns(returndata);

            // Act 
            // Assert
            var ex = Assert.Throws<Exception>(() => controller.NotifyParentsofNewGift(new Gift()));
            Assert.That(ex.Message == "Invalid Gift to Update.");
            //Assert.That(result == false, "Result should false if Gift ");
            //Assert.IsInstanceOf(typeof(IEnumerable<Gift>), result, "Type should be the same");
            //Assert.That(result, "Result count should be 2");
        }

        [Test]
        public void Calling_NofityParentsofNewGift_withGiftNotAssignedToKid_ThrowException()
        {
            // 
            var emailEngine = A.Fake<IEmailEngine>();
            var giftDataAccess = A.Fake<IGiftDataAccess>();
            var familyDataAccess = A.Fake<IFamilyDataAccess>();
            var kidDataAccess = A.Fake<IKidDataAccess>();
            NotificationApiController controller = new NotificationApiController(emailEngine, giftDataAccess, familyDataAccess, kidDataAccess);

            var returndata = new win10Core.Business.Model.Kid();
            //var returndata = new List<win10Core.Business.Model.Kid>();
            //{
            //    new win10Core.Business.Model.Gift {GiftId = 1, GiftName = "A"},
            //    new win10Core.Business.Model.Gift {GiftId = 2, GiftName = "B"}

            //};

            A.CallTo(() => kidDataAccess.Get(A<int>.Ignored)).Throws(new Exception("Error getting Kid record."));

            // Act 
            // Assert
            var ex = Assert.Throws<Exception>(() => controller.NotifyParentsofNewGift(new Gift{GiftId = 1}));
            Assert.That(ex.Message == "Invalid Gift to Update.");
            //Assert.That(result == false, "Result should false if Gift ");
            //Assert.IsInstanceOf(typeof(IEnumerable<Gift>), result, "Type should be the same");
            //Assert.That(result, "Result count should be 2");
        }
        [Test]
        public void Calling_NofityParentsofNewGift_withGiftNotAssignedToFamily_ThrowException()
        {
            // 
            var emailEngine = A.Fake<IEmailEngine>();
            var giftDataAccess = A.Fake<IGiftDataAccess>();
            var familyDataAccess = A.Fake<IFamilyDataAccess>();
            var kidDataAccess = A.Fake<IKidDataAccess>();
            NotificationApiController controller = new NotificationApiController(emailEngine, giftDataAccess, familyDataAccess, kidDataAccess);

            var returndata = new win10Core.Business.Model.Kid();
            //var returndata = new List<win10Core.Business.Model.Kid>();
            //{
            //    new win10Core.Business.Model.Gift {GiftId = 1, GiftName = "A"},
            //    new win10Core.Business.Model.Gift {GiftId = 2, GiftName = "B"}

            //};

            A.CallTo(() => kidDataAccess.Get(A<int>.Ignored)).Returns(returndata);
            A.CallTo(() => familyDataAccess.Get(A<int>.Ignored)).Throws(new Exception("Error getting Kid record."));
            // Act 
            // Assert
            var ex = Assert.Throws<Exception>(() => controller.NotifyParentsofNewGift(new Gift { GiftId = 1 }));
            Assert.That(ex.Message == "Invalid Gift to Update.");
            //Assert.That(result == false, "Result should false if Gift ");
            //Assert.IsInstanceOf(typeof(IEnumerable<Gift>), result, "Type should be the same");
            //Assert.That(result, "Result count should be 2");
        }
        [Test]
        public void Calling_NofityParentsofNewGift_withGiftNotAssignedToFamily_ReturnsTrue()
        {
            // 
            var emailEngine = A.Fake<IEmailEngine>();
            var giftDataAccess = A.Fake<IGiftDataAccess>();
            var familyDataAccess = A.Fake<IFamilyDataAccess>();
            var kidDataAccess = A.Fake<IKidDataAccess>();
            NotificationApiController controller = new NotificationApiController(emailEngine, giftDataAccess, familyDataAccess, kidDataAccess);

            var returnkKid = new win10Core.Business.Model.Kid();
            var returnfamily = new win10Core.Business.Model.Family();
            //var returndata = new List<win10Core.Business.Model.Kid>();
            //{
            //    new win10Core.Business.Model.Gift {GiftId = 1, GiftName = "A"},
            //    new win10Core.Business.Model.Gift {GiftId = 2, GiftName = "B"}

            //};

            A.CallTo(() => kidDataAccess.Get(A<int>.Ignored)).Returns(returnkKid);
            A.CallTo(() => familyDataAccess.Get(A<int>.Ignored)).Returns(returnfamily);
            A.CallTo(() => giftDataAccess.Update(A<win10Core.Business.Model.Gift>.Ignored)).Returns(true);
            // Act 
            // Assert
            var result = controller.NotifyParentsofNewGift(new Gift { GiftId = 1 });
            //Assert.That(ex.Message == "Invalid Gift to Update.");
            Assert.That(result == true, "Result should be true");
            //Assert.IsInstanceOf(typeof(IEnumerable<Gift>), result, "Type should be the same");
            //Assert.That(result, "Result count should be 2");
        }
        //[Test, Ignore()]
        //public void SendEmail_UpdateGifts()
        //{
        //    // 
        //    var emailEngine = A.Fake<IEmailEngine>();
        //    var giftDataAccess = A.Fake<IGiftDataAccess>();
        //    var familyDataAccess = A.Fake<IFamilyDataAccess>();
        //    var kidDataAccess = A.Fake<IKidDataAccess>();
        //    NotificationApiController controller = new NotificationApiController(emailEngine, giftDataAccess, familyDataAccess, kidDataAccess);

        //    var returndata = new List<win10Core.Business.Model.Gift>()
        //    {
        //        new win10Core.Business.Model.Gift {GiftId = 1, GiftName = "A"},
        //        new win10Core.Business.Model.Gift {GiftId = 2, GiftName = "B"}

        //    };

        //    A.CallTo(() => giftDataAccess.GetEmailList(A<bool>.Ignored)).Returns(returndata);

        //    // Act
        //    var result = controller.NotifyParentsofNewGift(new Gift());

        //    // Assert
        //    Assert.That(result == false, "Result should false if Gift ");
        //    //Assert.IsInstanceOf(typeof(IEnumerable<Gift>), result, "Type should be the same");
        //    //Assert.That(result, "Result count should be 2");
        //}

        //[Test]
        //public void Create()
        //{
        //    // Arrange
        //    var context = A.Fake<IServiceLayer>();
        //    FamilyController controller = new FamilyController(context);
        //    //controller.ModelState.Clear();
        //    //controller.ModelState.AddModelError("Error1", new Exception("Error Message"));
        //    var createFamily = new ServiceContracts.Family {FamilyId = 1, FamilyName = "B", FamilyEmail = "B@B.com"};

        //    A.CallTo(() => context.SendData<ServiceContracts.Family>(A<string>.Ignored, A<ServiceContracts.Family>.Ignored)); //Returns(null);


        //    // Act
        //    ActionResult result = controller.Create(createFamily) as ActionResult;

        //    // Assert
        //    Assert.IsNotNull(result);
        //    //Assert.IsNotNull(result.Model);
        //   // var responseModelCount = (List<ServiceContracts.Family>)result.Model;
        //    //Assert.That(responseModelCount.Count == 2, $"Model Response was {responseModelCount.Count}.");
        //}

        //[Test]
        //public void Create_With_modelError()
        //{
        //    // Arrange
        //    var context = A.Fake<IServiceLayer>();
        //    FamilyController controller = new FamilyController(context);
        //    controller.ModelState.Clear();
        //    controller.ModelState.AddModelError("Error1", new Exception("Error Message"));
        //    var createFamily = new ServiceContracts.Family { FamilyId = 1, FamilyName = "B", FamilyEmail = "B@B.com" };

        //    A.CallTo(() => context.SendData<ServiceContracts.Family>(A<string>.Ignored, A<ServiceContracts.Family>.Ignored)); //Returns(null);


        //    // Act
        //    ActionResult result = controller.Create(createFamily) as ActionResult;

        //    // Assert
        //    Assert.IsNotNull(result);
        //    //Assert.IsNotNull(result.Model);
        //    // var responseModelCount = (List<ServiceContracts.Family>)result.Model;
        //    //Assert.That(responseModelCount.Count == 2, $"Model Response was {responseModelCount.Count}.");
        //}
    }
}
