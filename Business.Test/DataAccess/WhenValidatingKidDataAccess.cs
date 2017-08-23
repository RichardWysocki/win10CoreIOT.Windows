using System;
using System.Collections.Generic;
using EntityFramework.FakeItEasy;
using FakeItEasy;
using NUnit.Framework;
using win10Core.Business.DataAccess;
using win10Core.Business.DataAccess.Interfaces;
using win10Core.Business.Model;

namespace Business.Test.DataAccess
{
    [TestFixture()]
    public class WhenValidatingKidDataAccess
    {
        [Test]
        //Given_When_Then
        public void When_Returning_GetList_is_Valid()
        {
            // Arrange
            var returndata = new List<Kid>()
            {
                new Kid{ KidId = 1, Name = "Kids 1", Email = "KidEmail1@Test.com", FamilyId = 1},
                new Kid{ KidId = 2, Name = "Kids 2", Email = "KidEmail2@Test.com", FamilyId = 1}
            };

            var context = A.Fake<IDBContext>();
            var fakeDbSet = Aef.FakeDbSet(returndata);
            A.CallTo(() => context.Kid).Returns(fakeDbSet);

            // Act
            var getKidDataAccess = new KidDataAccess(context);
            var response = getKidDataAccess.Get();

            //Assert
            Assert.IsNotNull(response);
            Assert.That(response.Count >= 0);

        }

        [Test]
        public void When_Returning_GetList_is_Empty()
        {
            // Arrange
            var returndata = new List<Kid>();

            var context = A.Fake<IDBContext>();
            var fakeDbSet = Aef.FakeDbSet(returndata);
            A.CallTo(() => context.Kid).Returns(fakeDbSet);

            // Act
            var getKidDataAccess = new KidDataAccess(context);
            var response = getKidDataAccess.Get();

            //Assert
            Assert.IsNotNull(response);
            Assert.IsEmpty(response);
        }

        [Test]
        public void When_Returning_Get_is_Valid()
        {
            // Arrange
            var returndata = new List<Kid>()
            {
                new Kid{ KidId = 1, Name = "Kids 1", Email = "KidEmail1@Test.com", FamilyId = 1},
                new Kid{ KidId = 2, Name = "Kids 2", Email = "KidEmail2@Test.com", FamilyId = 1}
            };

            var context = A.Fake<IDBContext>();
            var fakeDbSet = Aef.FakeDbSet(returndata);
            A.CallTo(() => context.Kid).Returns(fakeDbSet);

            // Act
            var getKidDataAccess = new KidDataAccess(context);
            var response = getKidDataAccess.Get(2);

            //Assert
            Assert.IsNotNull(response);
            Assert.That(response.KidId == 2);

        }

        [Test]
        public void When_Get_is_InValid_With_0()
        {
            // Arrange
            var returndata = new List<Kid>()
            {
                new Kid{ KidId = 1, Name = "Kids 1", Email = "KidEmail1@Test.com", FamilyId = 1},
                new Kid{ KidId = 2, Name = "Kids 2", Email = "KidEmail2@Test.com", FamilyId = 1}
            };

            var context = A.Fake<IDBContext>();
            var fakeDbSet = Aef.FakeDbSet(returndata);
            A.CallTo(() => context.Kid).Returns(fakeDbSet);

            // Act 
            var getKidDataAccess = new KidDataAccess(context);

            //Assert
            var ex = Assert.Throws<ArgumentException>(() => getKidDataAccess.Get(0));
            Assert.That(ex.Message == "Invalid id Paramter");
        }

        [Test]
        public void When_Get_is_InValid_id()
        {
            // Arrange
            var returndata = new List<Kid>()
            {
                new Kid{ KidId = 1, Name = "Kids 1", Email = "KidEmail1@Test.com", FamilyId = 1},
                new Kid{ KidId = 2, Name = "Kids 2", Email = "KidEmail2@Test.com", FamilyId = 1}
            };


            var context = A.Fake<IDBContext>();
            var fakeDbSet = Aef.FakeDbSet(returndata);
            A.CallTo(() => context.Kid).Returns(fakeDbSet);

            // Act
            var getKidDataAccess = new KidDataAccess(context);

            //Assert
            var ex = Assert.Throws<Exception>(() => getKidDataAccess.Get(3));
            Assert.That(ex.Message == "Error getting Kid record.");
        }

        [Test]
        public void When_Inserting_is_Valid()
        {
            // Arrange
            var returndata = new Kid()
            {
                Name = "InsertedName",
                Email = "InsertedName@Test.com",
                FamilyId = 1
            };
            var context = A.Fake<IDBContext>();
            A.CallTo(() => context.Kid.Add(A<Kid>.Ignored)).Returns(returndata);

            // Act
            var insertKidDataAccess = new KidDataAccess(context);
            insertKidDataAccess.Insert(new Kid { Name = "InsertedName", Email = "InsertedName@Test.com", FamilyId = 1});

            //Assert
            A.CallTo(() => context.Kid.Add(A<Kid>.Ignored)).MustHaveHappened(Repeated.Exactly.Once);

        }

        [Test]
        public void When_Updating_is_Valid()
        {
            // Arrange
            var kid = new Kid
            {
                KidId = 2,
                Name = "Kids 2",
                Email = "KidEmail2@Test.com",
                FamilyId = 1
            };
            var returndata = new List<Kid>()
            {
                new Kid{ KidId = 1, Name = "Kids 1", Email = "KidEmail1@Test.com", FamilyId = 1},
                new Kid{ KidId = 2, Name = "Kids 2", Email = "KidEmail2@Test.com", FamilyId = 1}
            };

            var context = A.Fake<IDBContext>();
            var fakeDbSet = Aef.FakeDbSet(returndata);
            A.CallTo(() => context.Kid).Returns(fakeDbSet);

            // Act

            var kidDataAccess = new KidDataAccess(context);
            var updateSuccessful = kidDataAccess.Update(kid);

            //Assert
            Assert.That(updateSuccessful);

        }

        [Test]
        public void When_Updating_is_Invalid()
        {
            // Arrange
            var kid = new Kid
            {
                KidId = 2,
                Name = "Kids 2",
                Email = "KidEmail2@Test.com",
                FamilyId = 1
            };

            var returndata = new List<Kid>();

            var context = A.Fake<IDBContext>();
            var fakeDbSet = Aef.FakeDbSet(returndata);
            A.CallTo(() => context.Kid).Returns(fakeDbSet);

            // Act
            var kidDataAccess = new KidDataAccess(context);
            var updateSuccessful = kidDataAccess.Update(kid);

            //Assert
            Assert.That(updateSuccessful == false);
        }

        [Test]
        public void When_Deleting_is_Valid()
        {
            // Arrange
            var returndata = new List<Kid>()
            {
                new Kid{ KidId = 1, Name = "Kids 1", Email = "KidEmail1@Test.com", FamilyId = 1},
                new Kid{ KidId = 2, Name = "Kids 2", Email = "KidEmail2@Test.com", FamilyId = 1}
            };

            var context = A.Fake<IDBContext>();
            var fakeDbSet = Aef.FakeDbSet(returndata);
            A.CallTo(() => context.Kid).Returns(fakeDbSet);

            // Act

            var deleteKid = new KidDataAccess(context);
            deleteKid.Delete(2);

            //Assert
            A.CallTo(() => context.Kid.Remove(A<Kid>.Ignored)).MustHaveHappened(Repeated.Exactly.Once);

        }

        [Test]
        public void When_Deleting_is_InValid()
        {
            // Arrange
            var returndata = new List<Kid>()
            {
                new Kid{ KidId = 1, Name = "Kids 1", Email = "KidEmail1@Test.com", FamilyId = 1},
                new Kid{ KidId = 2, Name = "Kids 2", Email = "KidEmail2@Test.com", FamilyId = 1}
            };

            var context = A.Fake<IDBContext>();
            var fakeDbSet = Aef.FakeDbSet(returndata);
            A.CallTo(() => context.Kid).Returns(fakeDbSet);

            // Act
            var deleteKidDataAccess = new KidDataAccess(context);
            //Assert
            var ex = Assert.Throws<Exception>(() => deleteKidDataAccess.Delete(3));
            Assert.That(ex.Message == "Error getting Kid record.");
        }


    }
}
