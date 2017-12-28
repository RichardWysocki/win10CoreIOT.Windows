using System;
using FakeItEasy;
using NUnit.Framework;
using win10Core.Business.DataAccess.Interfaces;
using win10Core.Business.Engine;
using win10Core.Business.Model;

namespace Business.Test.Engine
{
    [TestFixture] 
    public class WhenValidatingGiftEngine
    {

        [Test]
        public void Given_InvalidGiftId_When_Insert_Then_ThrowError()
        {
            //Arrange
            var fakeGiftDataAccess = A.Fake<IGiftDataAccess>();
            var fakeKidDataAccess = A.Fake<IKidDataAccess>();

            var GiftEngine = new GiftEngine(fakeGiftDataAccess, fakeKidDataAccess);
            A.CallTo(() => fakeKidDataAccess.Get(A<int>.Ignored)).Throws(new Exception("Invalid id Paramter"));
 
            // Act & Assert
            var ex = Assert.Throws<Exception>(() => GiftEngine.InsertGift(new Gift()));
            Assert.That(ex.Message == "Invalid id Paramter");

            //Assert
            //A.CallTo(() => GiftEngine.InsertGift(A<Gift>.Ignored)).MustHaveHappened(Repeated.Exactly.Once);

        }
        [Test]
        public void Given_ValidGiftId_When_Insert_Then_ThrowError()
        {
            //Arrange
            var fakeGiftDataAccess = A.Fake<IGiftDataAccess>();
            var fakeKidDataAccess = A.Fake<IKidDataAccess>();

            var GiftEngine = new GiftEngine(fakeGiftDataAccess, fakeKidDataAccess);
            A.CallTo(() => fakeKidDataAccess.Get(A<int>.Ignored)).Returns(new Kid());
            A.CallTo(() => fakeGiftDataAccess.Insert(A<Gift>.Ignored)).Returns(new Gift());

            // Act 
            var insertGift = GiftEngine.InsertGift(new Gift());

            //Assert
            Assert.IsNotNull(insertGift);

        }

        [Test]
        public void Given_InvalidGiftId_When_Update_Then_ThrowError()
        {
            //Arrange
            var fakeGiftDataAccess = A.Fake<IGiftDataAccess>();
            var fakeKidDataAccess = A.Fake<IKidDataAccess>();

            var GiftEngine = new GiftEngine(fakeGiftDataAccess, fakeKidDataAccess);
            A.CallTo(() => fakeKidDataAccess.Get(A<int>.Ignored)).Throws(new Exception("Invalid id Paramter"));

            //Act & Assert
            var ex = Assert.Throws<Exception>(() => GiftEngine.UpdateGift(new Gift()));
            Assert.That(ex.Message == "Invalid id Paramter");
        }
        [Test]
        public void Given_ValidGiftId_When_Update_Then_ThrowError()
        {
            //Arrange
            var fakeGiftDataAccess = A.Fake<IGiftDataAccess>();
            var fakeKidDataAccess = A.Fake<IKidDataAccess>();

            var GiftEngine = new GiftEngine(fakeGiftDataAccess, fakeKidDataAccess);
            A.CallTo(() => fakeKidDataAccess.Get(A<int>.Ignored)).Returns(new Kid());
            A.CallTo(() => fakeGiftDataAccess.Insert(A<Gift>.Ignored)).Returns(new Gift());

            // Act 
            GiftEngine.UpdateGift(new Gift());

            //Assert
            A.CallTo(() => fakeKidDataAccess.Get(A<int>.Ignored)).MustHaveHappened(Repeated.Exactly.Once);
        }
        [Test]
        public void Given_InvalidGiftId_When_Delete_Then_ThrowError()
        {
            //Arrange
            var fakeGiftDataAccess = A.Fake<IGiftDataAccess>();
            var fakeKidDataAccess = A.Fake<IKidDataAccess>();

            var GiftEngine = new GiftEngine(fakeGiftDataAccess, fakeKidDataAccess);
            A.CallTo(() => fakeGiftDataAccess.Get(A<int>.Ignored)).Throws(new Exception("Invalid id Paramter"));

            //Act & Assert
            var ex = Assert.Throws<Exception>(() => GiftEngine.DeleteGift(0));
            Assert.That(ex.Message == "Invalid id Paramter");


        }

        [Test]
        public void Given_ValidGiftId_When_Delete_Then_ThrowError()
        {
            //Arrange
            var fakeGiftDataAccess = A.Fake<IGiftDataAccess>();
            var fakeKidDataAccess = A.Fake<IKidDataAccess>();

            var GiftEngine = new GiftEngine(fakeGiftDataAccess, fakeKidDataAccess);
            A.CallTo(() => fakeKidDataAccess.Get(A<int>.Ignored)).Returns(new Kid());
            A.CallTo(() => fakeGiftDataAccess.Insert(A<Gift>.Ignored)).Returns(new Gift());
           
            // Act 
            GiftEngine.DeleteGift(1);;

            //Assert
            A.CallTo(() => fakeGiftDataAccess.Get(A<int>.Ignored)).MustHaveHappened(Repeated.Exactly.Once);


        }
    }
}
