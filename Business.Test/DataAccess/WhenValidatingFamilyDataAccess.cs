using System;
using System.Collections.Generic;
using EntityFramework.FakeItEasy;
using FakeItEasy;
using NUnit.Framework;
using win10Core.Business.DataAccess;
using win10Core.Business.Model;

namespace Business.Test.DataAccess
{
    [TestFixture]
    public class WhenValidatingFamilyDataAccess
    {
        [Test]
        //Given_When_Then
        public void When_Returning_GetList_is_Valid()
        {
            // Arrange
            var returndata = new List<Family>()
            {
                new Family{ FamilyId = 1, FamilyName = "Familys 1", FamilyEmail = "FamilyFamilyEmail1@Test.com"},
                new Family{ FamilyId = 2, FamilyName = "Familys 2", FamilyEmail = "FamilyFamilyEmail2@Test.com"}
            };

            var context = A.Fake<IDBContext>();
            var fakeDbSet = Aef.FakeDbSet(returndata);
            A.CallTo(() => context.Family).Returns(fakeDbSet);

            // Act
            var getFamilyDataAccess = new FamilyDataAccess(context);
            var response = getFamilyDataAccess.Get();

            //Assert
            Assert.IsNotNull(response);
            Assert.That(response.Count >= 0);

        }

        [Test]
        public void When_Returning_GetList_is_Empty()
        {
            // Arrange
            var returndata = new List<Family>();

            var context = A.Fake<IDBContext>();
            var fakeDbSet = Aef.FakeDbSet(returndata);
            A.CallTo(() => context.Family).Returns(fakeDbSet);

            // Act
            var getFamilyDataAccess = new FamilyDataAccess(context);
            var response = getFamilyDataAccess.Get();

            //Assert
            Assert.IsNotNull(response);
            Assert.IsEmpty(response);
        }

        [Test]
        public void When_Returning_Get_is_Valid()
        {
            // Arrange
            var returndata = new List<Family>()
            {
                new Family{ FamilyId = 1, FamilyName = "Familys 1", FamilyEmail = "FamilyFamilyEmail1@Test.com"},
                new Family{ FamilyId = 2, FamilyName = "Familys 2", FamilyEmail = "FamilyFamilyEmail2@Test.com"}
            };

            var context = A.Fake<IDBContext>();
            var fakeDbSet = Aef.FakeDbSet(returndata);
            A.CallTo(() => context.Family).Returns(fakeDbSet);

            // Act
            var getFamilyDataAccess = new FamilyDataAccess(context);
            var response = getFamilyDataAccess.Get(2);

            //Assert
            Assert.IsNotNull(response);
            Assert.That(response.FamilyId == 2);

        }

        [Test]
        public void When_Get_is_InValid_With_0()
        {
            // Arrange
            var returndata = new List<Family>()
            {
                new Family{ FamilyId = 1, FamilyName = "Familys 1", FamilyEmail = "FamilyFamilyEmail1@Test.com"},
                new Family{ FamilyId = 2, FamilyName = "Familys 2", FamilyEmail = "FamilyFamilyEmail2@Test.com"}
            };

            var context = A.Fake<IDBContext>();
            var fakeDbSet = Aef.FakeDbSet(returndata);
            A.CallTo(() => context.Family).Returns(fakeDbSet);

            // Act 
            var getFamilyDataAccess = new FamilyDataAccess(context);

            //Assert
            var ex = Assert.Throws<ArgumentException>(() => getFamilyDataAccess.Get(0));
            Assert.That(ex.Message == "Invalid id Paramter");
        }

        [Test]
        public void When_Get_is_InValid_id()
        {
            // Arrange
            var returndata = new List<Family>()
            {
                new Family{ FamilyId = 1, FamilyName = "Familys 1", FamilyEmail = "FamilyFamilyEmail1@Test.com"},
                new Family{ FamilyId = 2, FamilyName = "Familys 2", FamilyEmail = "FamilyFamilyEmail2@Test.com"}
            };


            var context = A.Fake<IDBContext>();
            var fakeDbSet = Aef.FakeDbSet(returndata);
            A.CallTo(() => context.Family).Returns(fakeDbSet);

            // Act
            var getFamilyDataAccess = new FamilyDataAccess(context);

            //Assert
            var ex = Assert.Throws<Exception>(() => getFamilyDataAccess.Get(3));
            Assert.That(ex.Message == "Error getting Family record.");
        }

        [Test]
        public void When_Inserting_is_Valid()
        {
            // Arrange
            var returndata = new Family()
            {
                FamilyName = "InsertedFamilyName",
                FamilyEmail = "InsertedFamilyName@Test.com",
                FamilyId = 1
            };
            var context = A.Fake<IDBContext>();
            A.CallTo(() => context.Family.Add(A<Family>.Ignored)).Returns(returndata);

            // Act
            var insertFamilyDataAccess = new FamilyDataAccess(context);
            insertFamilyDataAccess.Insert(new Family { FamilyName = "InsertedFamilyName", FamilyEmail = "InsertedFamilyName@Test.com"});

            //Assert
            A.CallTo(() => context.Family.Add(A<Family>.Ignored)).MustHaveHappened(Repeated.Exactly.Once);

        }

        [Test]
        public void When_Updating_is_Valid()
        {
            // Arrange
            var family = new Family
            {
                FamilyId = 2,
                FamilyName = "Familys 2",
                FamilyEmail = "FamilyFamilyEmail2@Test.com"
            };
            var returndata = new List<Family>()
            {
                new Family{ FamilyId = 1, FamilyName = "Familys 1", FamilyEmail = "FamilyFamilyEmail1@Test.com"},
                new Family{ FamilyId = 2, FamilyName = "Familys 2", FamilyEmail = "FamilyFamilyEmail2@Test.com"}
            };

            var context = A.Fake<IDBContext>();
            var fakeDbSet = Aef.FakeDbSet(returndata);
            A.CallTo(() => context.Family).Returns(fakeDbSet);

            // Act

            var familyDataAccess = new FamilyDataAccess(context);
            var updateSuccessful = familyDataAccess.Update(family);

            //Assert
            Assert.That(updateSuccessful);

        }

        [Test]
        public void When_Updating_is_Invalid()
        {
            // Arrange
            var family = new Family
            {
                FamilyId = 2,
                FamilyName = "Familys 2",
                FamilyEmail = "FamilyFamilyEmail2@Test.com"
            };

            var returndata = new List<Family>();

            var context = A.Fake<IDBContext>();
            var fakeDbSet = Aef.FakeDbSet(returndata);
            A.CallTo(() => context.Family).Returns(fakeDbSet);

            // Act
            var familyDataAccess = new FamilyDataAccess(context);
            var updateSuccessful = familyDataAccess.Update(family);

            //Assert
            Assert.That(updateSuccessful == false);
        }

        [Test]
        public void When_Deleting_is_Valid()
        {
            // Arrange
            var returndata = new List<Family>()
            {
                new Family{ FamilyId = 1, FamilyName = "Familys 1", FamilyEmail = "FamilyFamilyEmail1@Test.com"},
                new Family{ FamilyId = 2, FamilyName = "Familys 2", FamilyEmail = "FamilyFamilyEmail2@Test.com"}
            };

            var context = A.Fake<IDBContext>();
            var fakeDbSet = Aef.FakeDbSet(returndata);
            A.CallTo(() => context.Family).Returns(fakeDbSet);

            // Act

            var deleteFamily = new FamilyDataAccess(context);
            deleteFamily.Delete(2);

            //Assert
            A.CallTo(() => context.Family.Remove(A<Family>.Ignored)).MustHaveHappened(Repeated.Exactly.Once);

        }

        [Test]
        public void When_Deleting_is_InValid()
        {
            // Arrange
            var returndata = new List<Family>()
            {
                new Family{ FamilyId = 1, FamilyName = "Familys 1", FamilyEmail = "FamilyFamilyEmail1@Test.com"},
                new Family{ FamilyId = 2, FamilyName = "Familys 2", FamilyEmail = "FamilyFamilyEmail2@Test.com"}
            };

            var context = A.Fake<IDBContext>();
            var fakeDbSet = Aef.FakeDbSet(returndata);
            A.CallTo(() => context.Family).Returns(fakeDbSet);

            // Act
            var deleteFamilyDataAccess = new FamilyDataAccess(context);
            //Assert
            var ex = Assert.Throws<Exception>(() => deleteFamilyDataAccess.Delete(3));
            Assert.That(ex.Message == "Error getting Family record.");
        }


    }
}
