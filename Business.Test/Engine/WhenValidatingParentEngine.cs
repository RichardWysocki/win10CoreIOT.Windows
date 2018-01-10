using System;
using FakeItEasy;
using NUnit.Framework;
using win10Core.Business.DataAccess.Interfaces;
using win10Core.Business.Engine;
using win10Core.Business.Model;

namespace Business.Test.Engine
{
    [TestFixture] 
    public class WhenValidatingParentEngine
    {

        [Test]
        public void Given_InvalidParentId_When_Insert_Then_ThrowError()
        {
            //Arrange
            var fakeParentDataAccess = A.Fake<IParentDataAccess>();
            var fakeFamilyDataAccess = A.Fake<IFamilyDataAccess>();

            var parentEngine = new ParentEngine(fakeParentDataAccess, fakeFamilyDataAccess);
            A.CallTo(() => fakeFamilyDataAccess.Get(A<int>.Ignored)).Throws(new Exception("Invalid id Paramter"));
 
            // Act & Assert
            var ex = Assert.Throws<Exception>(() => parentEngine.InsertParent(new Parent()));
            Assert.That(ex.Message == "Invalid id Paramter");

            //Assert
            //A.CallTo(() => ParentEngine.InsertParent(A<Parent>.Ignored)).MustHaveHappened(Repeated.Exactly.Once);

        }
        [Test]
        public void Given_ValidParentId_When_Insert_Then_ThrowError()
        {
            //Arrange
            var fakeParentDataAccess = A.Fake<IParentDataAccess>();
            var fakeFamilyDataAccess = A.Fake<IFamilyDataAccess>();

            var parentEngine = new ParentEngine(fakeParentDataAccess, fakeFamilyDataAccess);
            A.CallTo(() => fakeFamilyDataAccess.Get(A<int>.Ignored)).Returns(new Family());
            A.CallTo(() => fakeParentDataAccess.Insert(A<Parent>.Ignored)).Returns(new Parent());

            // Act 
            var insertParent = parentEngine.InsertParent(new Parent());

            //Assert
            Assert.IsNotNull(insertParent);

        }

        [Test]
        public void Given_InvalidParentId_When_Update_Then_ThrowError()
        {
            //Arrange
            var fakeParentDataAccess = A.Fake<IParentDataAccess>();
            var fakeFamilyDataAccess = A.Fake<IFamilyDataAccess>();

            var parentEngine = new ParentEngine(fakeParentDataAccess, fakeFamilyDataAccess);
            A.CallTo(() => fakeFamilyDataAccess.Get(A<int>.Ignored)).Throws(new Exception("Invalid id Paramter"));

            //Act & Assert
            var ex = Assert.Throws<Exception>(() => parentEngine.UpdateParent(new Parent()));
            Assert.That(ex.Message == "Invalid id Paramter");
        }
        [Test]
        public void Given_ValidParentId_When_Update_Then_ThrowError()
        {
            //Arrange
            var fakeParentDataAccess = A.Fake<IParentDataAccess>();
            var fakeFamilyDataAccess = A.Fake<IFamilyDataAccess>();

            var parentEngine = new ParentEngine(fakeParentDataAccess, fakeFamilyDataAccess);
            A.CallTo(() => fakeFamilyDataAccess.Get(A<int>.Ignored)).Returns(new Family());
            A.CallTo(() => fakeParentDataAccess.Insert(A<Parent>.Ignored)).Returns(new Parent());

            // Act 
            parentEngine.UpdateParent(new Parent());

            //Assert
            A.CallTo(() => fakeFamilyDataAccess.Get(A<int>.Ignored)).MustHaveHappened(Repeated.Exactly.Once);
        }
        [Test]
        public void Given_InvalidParentId_When_Delete_Then_ThrowError()
        {
            //Arrange
            var fakeParentDataAccess = A.Fake<IParentDataAccess>();
            var fakeFamilyDataAccess = A.Fake<IFamilyDataAccess>();

            var parentEngine = new ParentEngine(fakeParentDataAccess, fakeFamilyDataAccess);
            A.CallTo(() => fakeParentDataAccess.Get(A<int>.Ignored)).Throws(new Exception("Invalid id Paramter"));

            //Act & Assert
            var ex = Assert.Throws<Exception>(() => parentEngine.DeleteParent(0));
            Assert.That(ex.Message == "Invalid id Paramter");


        }

        [Test]
        public void Given_ValidParentId_When_Delete_Then_ThrowError()
        {
            //Arrange
            var fakeParentDataAccess = A.Fake<IParentDataAccess>();
            var fakeFamilyDataAccess = A.Fake<IFamilyDataAccess>();

            var parentEngine = new ParentEngine(fakeParentDataAccess, fakeFamilyDataAccess);
            A.CallTo(() => fakeFamilyDataAccess.Get(A<int>.Ignored)).Returns(new Family());
            A.CallTo(() => fakeParentDataAccess.Insert(A<Parent>.Ignored)).Returns(new Parent());
           
            // Act 
            parentEngine.DeleteParent(1);

            //Assert
            A.CallTo(() => fakeParentDataAccess.Get(A<int>.Ignored)).MustHaveHappened(Repeated.Exactly.Once);


        }
    }
}
