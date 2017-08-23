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
    public class WhenValidatingParentDataAccess
    {
        [Test]
        //Given_When_Then
        public void When_Returning_GetList_is_Valid()
        {
            // Arrange
            var returndata = new List<Parent>()
            {
                new Parent{ ParentId = 1, Name = "Parents 1", Email = "ParentEmail1@Test.com", FamilyId = 1},
                new Parent{ ParentId = 2, Name = "Parents 2", Email = "ParentEmail2@Test.com", FamilyId = 1}
            };

            var context = A.Fake<IDBContext>();
            var fakeDbSet = Aef.FakeDbSet(returndata);
            A.CallTo(() => context.Parent).Returns(fakeDbSet);

            // Act
            var getParentDataAccess = new ParentDataAccess(context);
            var response = getParentDataAccess.Get();

            //Assert
            Assert.IsNotNull(response);
            Assert.That(response.Count >= 0);

        }

        [Test]
        public void When_Returning_GetList_is_Empty()
        {
            // Arrange
            var returndata = new List<Parent>();

            var context = A.Fake<IDBContext>();
            var fakeDbSet = Aef.FakeDbSet(returndata);
            A.CallTo(() => context.Parent).Returns(fakeDbSet);

            // Act
            var getParentDataAccess = new ParentDataAccess(context);
            var response = getParentDataAccess.Get();

            //Assert
            Assert.IsNotNull(response);
            Assert.IsEmpty(response);
        }

        [Test]
        public void When_Returning_Get_is_Valid()
        {
            // Arrange
            var returndata = new List<Parent>()
            {
                new Parent{ ParentId = 1, Name = "Parents 1", Email = "ParentEmail1@Test.com", FamilyId = 1},
                new Parent{ ParentId = 2, Name = "Parents 2", Email = "ParentEmail2@Test.com", FamilyId = 1}
            };

            var context = A.Fake<IDBContext>();
            var fakeDbSet = Aef.FakeDbSet(returndata);
            A.CallTo(() => context.Parent).Returns(fakeDbSet);

            // Act
            var getParentDataAccess = new ParentDataAccess(context);
            var response = getParentDataAccess.Get(2);

            //Assert
            Assert.IsNotNull(response);
            Assert.That(response.ParentId == 2);

        }

        [Test]
        public void When_Get_is_InValid_With_0()
        {
            // Arrange
            var returndata = new List<Parent>()
            {
                new Parent{ ParentId = 1, Name = "Parents 1", Email = "ParentEmail1@Test.com", FamilyId = 1},
                new Parent{ ParentId = 2, Name = "Parents 2", Email = "ParentEmail2@Test.com", FamilyId = 1}
            };

            var context = A.Fake<IDBContext>();
            var fakeDbSet = Aef.FakeDbSet(returndata);
            A.CallTo(() => context.Parent).Returns(fakeDbSet);

            // Act 
            var getParentDataAccess = new ParentDataAccess(context);

            //Assert
            var ex = Assert.Throws<ArgumentException>(() => getParentDataAccess.Get(0));
            Assert.That(ex.Message == "Invalid id Paramter");
        }

        [Test]
        public void When_Get_is_InValid_id()
        {
            // Arrange
            var returndata = new List<Parent>()
            {
                new Parent{ ParentId = 1, Name = "Parents 1", Email = "ParentEmail1@Test.com", FamilyId = 1},
                new Parent{ ParentId = 2, Name = "Parents 2", Email = "ParentEmail2@Test.com", FamilyId = 1}
            };


            var context = A.Fake<IDBContext>();
            var fakeDbSet = Aef.FakeDbSet(returndata);
            A.CallTo(() => context.Parent).Returns(fakeDbSet);

            // Act
            var getParentDataAccess = new ParentDataAccess(context);

            //Assert
            var ex = Assert.Throws<Exception>(() => getParentDataAccess.Get(3));
            Assert.That(ex.Message == "Error getting Parent record.");
        }

        [Test]
        public void When_Inserting_is_Valid()
        {
            // Arrange
            var returndata = new Parent()
            {
                ParentId = 1,
                Name = "InsertedName",
                Email = "InsertedName@Test.com",
                FamilyId = 1
            };
            var context = A.Fake<IDBContext>();
            A.CallTo(() => context.Parent.Add(A<Parent>.Ignored)).Returns(returndata);

            // Act
            var insertParentDataAccess = new ParentDataAccess(context);
            insertParentDataAccess.Insert(new Parent { ParentId = 1, Name = "InsertedName", Email = "InsertedName@Test.com", FamilyId = 1});

            //Assert
            A.CallTo(() => context.Parent.Add(A<Parent>.Ignored)).MustHaveHappened(Repeated.Exactly.Once);

        }

        [Test]
        public void When_Updating_is_Valid()
        {
            // Arrange
            var parent = new Parent
            {
                ParentId = 2, 
                Name = "Parents 2",
                Email = "ParentEmail2@Test.com",
                FamilyId = 1
            };
            var returndata = new List<Parent>()
            {
                new Parent{ ParentId = 1, Name = "Parents 1", Email = "ParentEmail1@Test.com", FamilyId = 1},
                new Parent{ ParentId = 2, Name = "Parents 2", Email = "ParentEmail2@Test.com", FamilyId = 1}
            };

            var context = A.Fake<IDBContext>();
            var fakeDbSet = Aef.FakeDbSet(returndata);
            A.CallTo(() => context.Parent).Returns(fakeDbSet);

            // Act

            var parentDataAccess = new ParentDataAccess(context);
            var updateSuccessful = parentDataAccess.Update(parent);

            //Assert
            Assert.That(updateSuccessful);

        }

        [Test]
        public void When_Updating_is_Invalid()
        {
            // Arrange
            var parent = new Parent
            {
                ParentId = 1,
                Name = "Parents 2",
                Email = "ParentEmail2@Test.com",
                FamilyId = 1
            };

            var returndata = new List<Parent>();

            var context = A.Fake<IDBContext>();
            var fakeDbSet = Aef.FakeDbSet(returndata);
            A.CallTo(() => context.Parent).Returns(fakeDbSet);

            // Act
            var parentDataAccess = new ParentDataAccess(context);
            var updateSuccessful = parentDataAccess.Update(parent);

            //Assert
            Assert.That(updateSuccessful == false);
        }

        [Test]
        public void When_Deleting_is_Valid()
        {
            // Arrange
            var returndata = new List<Parent>()
            {
                new Parent{ ParentId = 1, Name = "Parents 1", Email = "ParentEmail1@Test.com", FamilyId = 1},
                new Parent{ ParentId = 2, Name = "Parents 2", Email = "ParentEmail2@Test.com", FamilyId = 1}
            };

            var context = A.Fake<IDBContext>();
            var fakeDbSet = Aef.FakeDbSet(returndata);
            A.CallTo(() => context.Parent).Returns(fakeDbSet);

            // Act

            var deleteParent = new ParentDataAccess(context);
            deleteParent.Delete(2);

            //Assert
            A.CallTo(() => context.Parent.Remove(A<Parent>.Ignored)).MustHaveHappened(Repeated.Exactly.Once);

        }

        [Test]
        public void When_Deleting_is_InValid()
        {
            // Arrange
            var returndata = new List<Parent>()
            {
                new Parent{ ParentId = 1, Name = "Parents 1", Email = "ParentEmail1@Test.com", FamilyId = 1},
                new Parent{ ParentId = 2, Name = "Parents 2", Email = "ParentEmail2@Test.com", FamilyId = 1}
            };

            var context = A.Fake<IDBContext>();
            var fakeDbSet = Aef.FakeDbSet(returndata);
            A.CallTo(() => context.Parent).Returns(fakeDbSet);

            // Act
            var deleteParentDataAccess = new ParentDataAccess(context);
            //Assert
            var ex = Assert.Throws<Exception>(() => deleteParentDataAccess.Delete(3));
            Assert.That(ex.Message == "Error getting Parent record.");
        }


    }
}
