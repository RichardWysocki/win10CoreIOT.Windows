using System;
using FakeItEasy;
using NUnit.Framework;
using win10Core.Business.DataAccess.Interfaces;
using win10Core.Business.Engine;
using win10Core.Business.Model;

namespace Business.Test.Engine
{
    [TestFixture] 
    public class WhenValidatingFamilyEngine
    {
        [Test]
        public void Given_InvalidFamilyId_When_Insert_Then_ThrowError()
        {
            //Arrange
            var fakeFamilyDataAccess = A.Fake<IFamilyDataAccess>();

            var familyEngine = new FamilyEngine(fakeFamilyDataAccess);
            A.CallTo(() => fakeFamilyDataAccess.Get(A<int>.Ignored)).Throws(new Exception("Invalid id Paramter"));
 
            // Act & Assert
            var ex = Assert.Throws<Exception>(() => familyEngine.InsertFamily(new Family()));
            Assert.That(ex.Message == "Invalid id Paramter");

            //Assert
            //A.CallTo(() => FamilyEngine.InsertFamily(A<Family>.Ignored)).MustHaveHappened(Repeated.Exactly.Once);

        }
        [Test]
        public void Given_ValidFamilyId_When_Insert_Then_InsertMustHaveHappened()
        {
            //Arrange
            var fakeFamilyDataAccess = A.Fake<IFamilyDataAccess>();

            var familyEngine = new FamilyEngine(fakeFamilyDataAccess);
            A.CallTo(() => fakeFamilyDataAccess.Get(A<int>.Ignored)).Returns(new Family());
            A.CallTo(() => fakeFamilyDataAccess.Insert(A<Family>.Ignored)).Returns(new Family());

            // Act 
            var insertFamily = familyEngine.InsertFamily(new Family());

            //Assert

            A.CallTo(() => fakeFamilyDataAccess.Insert(A<Family>.Ignored)).MustHaveHappened(Repeated.Exactly.Once);
            Assert.IsNotNull(insertFamily);

        }

        [Test]
        public void Given_InvalidFamilyId_When_Update_Then_ThrowError()
        {
            //Arrange
            var fakeFamilyDataAccess = A.Fake<IFamilyDataAccess>();

            var familyEngine = new FamilyEngine(fakeFamilyDataAccess);
            A.CallTo(() => fakeFamilyDataAccess.Get(A<int>.Ignored)).Throws(new Exception("Invalid id Paramter"));

            //Act & Assert
            var ex = Assert.Throws<Exception>(() => familyEngine.UpdateFamily(new Family()));
            Assert.That(ex.Message == "Invalid id Paramter");
        }
        [Test]
        public void Given_ValidFamilyId_When_Update_Then_UpdateMustHaveHappened()
        {
            //Arrange
            var fakeFamilyDataAccess = A.Fake<IFamilyDataAccess>();

            var familyEngine = new FamilyEngine(fakeFamilyDataAccess);
            A.CallTo(() => fakeFamilyDataAccess.Get(A<int>.Ignored)).Returns(new Family());
            A.CallTo(() => fakeFamilyDataAccess.Insert(A<Family>.Ignored)).Returns(new Family());

            // Act 
            familyEngine.UpdateFamily(new Family());

            //Assert
            A.CallTo(() => fakeFamilyDataAccess.Get(A<int>.Ignored)).MustHaveHappened(Repeated.Exactly.Once);
            A.CallTo(() => fakeFamilyDataAccess.Update(A<Family>.Ignored)).MustHaveHappened(Repeated.Exactly.Once);
        }

        [Test]
        public void Given_InvalidFamilyId_When_Delete_Then_ThrowError()
        {
            //Arrange
            var fakeFamilyDataAccess = A.Fake<IFamilyDataAccess>();

            var familyEngine = new FamilyEngine(fakeFamilyDataAccess);
            A.CallTo(() => fakeFamilyDataAccess.Get(A<int>.Ignored)).Throws(new Exception("Invalid id Paramter"));

            //Act & Assert
            var ex = Assert.Throws<Exception>(() => familyEngine.DeleteFamily(0));
            Assert.That(ex.Message == "Invalid id Paramter");


        }
        [Test]
        public void Given_ValidFamilyId_When_Delete_Then_DeleteMustHaveHappned()
        {
            //Arrange
            var fakeFamilyDataAccess = A.Fake<IFamilyDataAccess>();

            var familyEngine = new FamilyEngine(fakeFamilyDataAccess);
            A.CallTo(() => fakeFamilyDataAccess.Get(A<int>.Ignored)).Returns(new Family());
           
            // Act 
            familyEngine.DeleteFamily(1);

            //Assert
            A.CallTo(() => fakeFamilyDataAccess.Get(A<int>.Ignored)).MustHaveHappened(Repeated.Exactly.Once);
            A.CallTo(() => fakeFamilyDataAccess.Delete(1)).MustHaveHappened(Repeated.Exactly.Once);

        }
    }
}
