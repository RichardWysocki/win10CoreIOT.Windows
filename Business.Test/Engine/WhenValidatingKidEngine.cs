using System;
using FakeItEasy;
using NUnit.Framework;
using win10Core.Business.DataAccess.Interfaces;
using win10Core.Business.Engine;
using win10Core.Business.Model;

namespace Business.Test.Engine
{
    [TestFixture]
    public class WhenValidatingKidEngine
    {

        [Test]
        public void Given_InvalidKidId_When_Insert_Then_ThrowError()
        {
            //Arrange
            var fakeKidDataAccess = A.Fake<IKidDataAccess>();
            var fakeFamilyDataAccess = A.Fake<IFamilyDataAccess>();

            var kidEngine = new KidEngine(fakeFamilyDataAccess, fakeKidDataAccess);
            A.CallTo(() => fakeFamilyDataAccess.Get(A<int>.Ignored)).Throws(new Exception("Invalid id Paramter"));
 
            // Act & Assert
            var ex = Assert.Throws<Exception>(() => kidEngine.InsertKid(new Kid()));
            Assert.That(ex.Message == "Invalid id Paramter");

            //Assert
            //A.CallTo(() => kidEngine.InsertKid(A<Kid>.Ignored)).MustHaveHappened(Repeated.Exactly.Once);

        }
        [Test]
        public void Given_ValidKidId_When_Insert_Then_ThrowError()
        {
            //Arrange
            var fakeKidDataAccess = A.Fake<IKidDataAccess>();
            var fakeFamilyDataAccess = A.Fake<IFamilyDataAccess>();

            var kidEngine = new KidEngine(fakeFamilyDataAccess, fakeKidDataAccess);
            A.CallTo(() => fakeFamilyDataAccess.Get(A<int>.Ignored)).Returns(new Family());
            A.CallTo(() => fakeKidDataAccess.Insert(A<Kid>.Ignored)).Returns(new Kid());

            // Act 
            var insertKid = kidEngine.InsertKid(new Kid());

            //Assert
            Assert.IsNotNull(insertKid);

        }

        [Test]
        public void Given_InvalidKidId_When_Update_Then_ThrowError()
        {
            //Arrange
            var fakeKidDataAccess = A.Fake<IKidDataAccess>();
            var fakeFamilyDataAccess = A.Fake<IFamilyDataAccess>();

            var kidEngine = new KidEngine(fakeFamilyDataAccess, fakeKidDataAccess);
            A.CallTo(() => fakeFamilyDataAccess.Get(A<int>.Ignored)).Throws(new Exception("Invalid id Paramter"));

            //Act & Assert
            var ex = Assert.Throws<Exception>(() => kidEngine.UpdateKid(new Kid()));
            Assert.That(ex.Message == "Invalid id Paramter");
        }
        [Test]
        public void Given_ValidKidId_When_Update_Then_ThrowError()
        {
            //Arrange
            var fakeKidDataAccess = A.Fake<IKidDataAccess>();
            var fakeFamilyDataAccess = A.Fake<IFamilyDataAccess>();

            var kidEngine = new KidEngine(fakeFamilyDataAccess, fakeKidDataAccess);
            A.CallTo(() => fakeFamilyDataAccess.Get(A<int>.Ignored)).Returns(new Family());
            A.CallTo(() => fakeKidDataAccess.Insert(A<Kid>.Ignored)).Returns(new Kid());

            // Act 
            kidEngine.UpdateKid(new Kid());

            //Assert
            A.CallTo(() => fakeFamilyDataAccess.Get(A<int>.Ignored)).MustHaveHappened(Repeated.Exactly.Once);
        }
        [Test]
        public void Given_InvalidKidId_When_Delete_Then_ThrowError()
        {
            //Arrange
            var fakeKidDataAccess = A.Fake<IKidDataAccess>();
            var fakeFamilyDataAccess = A.Fake<IFamilyDataAccess>();

            var kidEngine = new KidEngine(fakeFamilyDataAccess, fakeKidDataAccess);
            A.CallTo(() => fakeKidDataAccess.Get(A<int>.Ignored)).Throws(new Exception("Invalid id Paramter"));

            //Act & Assert
            var ex = Assert.Throws<Exception>(() => kidEngine.DeleteKid(0));
            Assert.That(ex.Message == "Invalid id Paramter");


        }

        [Test]
        public void Given_ValidKidId_When_Delete_Then_ThrowError()
        {
            //Arrange
            var fakeKidDataAccess = A.Fake<IKidDataAccess>();
            var fakeFamilyDataAccess = A.Fake<IFamilyDataAccess>();

            var kidEngine = new KidEngine(fakeFamilyDataAccess, fakeKidDataAccess);
            A.CallTo(() => fakeFamilyDataAccess.Get(A<int>.Ignored)).Returns(new Family());
            A.CallTo(() => fakeKidDataAccess.Insert(A<Kid>.Ignored)).Returns(new Kid());
           
            // Act 
            kidEngine.DeleteKid(1);;

            //Assert
            A.CallTo(() => fakeKidDataAccess.Get(A<int>.Ignored)).MustHaveHappened(Repeated.Exactly.Once);


        }
    }
}
