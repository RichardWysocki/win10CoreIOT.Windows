using System;
using System.Collections.Generic;
using EntityFramework.FakeItEasy;
using FakeItEasy;
using NUnit.Framework;
using win10Core.Business.DataAccess;
using win10Core.Business.Model;

namespace Business.Test.DataAccess
{
    [TestFixture()]
    public class WhenValidatingGiftDataAccess
    {
        [Test]
        //Given_When_Then
        public void When_Returning_GetList_is_Valid()
        {
            // Arrange
            var returndata = new List<Gift>()
            {
                new Gift{ GiftId = 1, KidId = 1, GiftName = "Gifts 1", WebUrl = "GiftEmail1@Test.com", Priority = 1},
                new Gift{ GiftId = 2, KidId = 2, GiftName = "Gifts 2", WebUrl = "GiftEmail2@Test.com", Priority = 1}
            };

            var context = A.Fake<IDBContext>();
            var fakeDbSet = Aef.FakeDbSet(returndata);
            A.CallTo(() => context.Gift).Returns(fakeDbSet);

            // Act
            var getGiftDataAccess = new GiftDataAccess(context);
            var response = getGiftDataAccess.Get();

            //Assert
            Assert.IsNotNull(response);
            Assert.That(response.Count >= 0);

        }

        [Test]
        public void When_Returning_GetList_is_Empty()
        {
            // Arrange
            var returndata = new List<Gift>();

            var context = A.Fake<IDBContext>();
            var fakeDbSet = Aef.FakeDbSet(returndata);
            A.CallTo(() => context.Gift).Returns(fakeDbSet);

            // Act
            var getGiftDataAccess = new GiftDataAccess(context);
            var response = getGiftDataAccess.Get();

            //Assert
            Assert.IsNotNull(response);
            Assert.IsEmpty(response);
        }

        [Test]
        public void When_Returning_Get_is_Valid()
        {
            // Arrange
            var returndata = new List<Gift>()
            {
                new Gift{ GiftId = 1, KidId = 1, GiftName = "Gifts 1", WebUrl = "GiftEmail1@Test.com", Priority = 1},
                new Gift{ GiftId = 2, KidId = 2, GiftName = "Gifts 2", WebUrl = "GiftEmail2@Test.com", Priority = 1}
            };

            var context = A.Fake<IDBContext>();
            var fakeDbSet = Aef.FakeDbSet(returndata);
            A.CallTo(() => context.Gift).Returns(fakeDbSet);

            // Act
            var getGiftDataAccess = new GiftDataAccess(context);
            var response = getGiftDataAccess.Get(2);

            //Assert
            Assert.IsNotNull(response);
            Assert.That(response.GiftId == 2);

        }

        [Test]
        public void When_Get_is_InValid_With_0()
        {
            // Arrange
            var returndata = new List<Gift>()
            {
                new Gift{ GiftId = 1, KidId = 1, GiftName = "Gifts 1", WebUrl = "GiftEmail1@Test.com", Priority = 1},
                new Gift{ GiftId = 2, KidId = 2, GiftName = "Gifts 2", WebUrl = "GiftEmail2@Test.com", Priority = 1}
            };

            var context = A.Fake<IDBContext>();
            var fakeDbSet = Aef.FakeDbSet(returndata);
            A.CallTo(() => context.Gift).Returns(fakeDbSet);

            // Act 
            var getGiftDataAccess = new GiftDataAccess(context);

            //Assert
            var ex = Assert.Throws<ArgumentException>(() => getGiftDataAccess.Get(0));
            Assert.That(ex.Message == "Invalid id Paramter");
        }

        [Test]
        public void When_Get_is_InValid_id()
        {
            // Arrange
            var returndata = new List<Gift>()
            {
                new Gift{ GiftId = 1, KidId = 1, GiftName = "Gifts 1", WebUrl = "GiftEmail1@Test.com", Priority = 1},
                new Gift{ GiftId = 2, KidId = 2, GiftName = "Gifts 2", WebUrl = "GiftEmail2@Test.com", Priority = 1}
            };


            var context = A.Fake<IDBContext>();
            var fakeDbSet = Aef.FakeDbSet(returndata);
            A.CallTo(() => context.Gift).Returns(fakeDbSet);

            // Act
            var getGiftDataAccess = new GiftDataAccess(context);

            //Assert
            var ex = Assert.Throws<Exception>(() => getGiftDataAccess.Get(3));
            Assert.That(ex.Message == "Error getting Gift record.");
        }

        [Test]
        public void When_Inserting_is_Valid()
        {
            // Arrange
            var returndata = new Gift()
            {
                KidId = 1,
                GiftName = "InsertedName",
                WebUrl = "InsertedName@Test.com",
                Priority = 1
            };
            var context = A.Fake<IDBContext>();
            A.CallTo(() => context.Gift.Add(A<Gift>.Ignored)).Returns(returndata);

            // Act
            var insertGiftDataAccess = new GiftDataAccess(context);
            insertGiftDataAccess.Insert(new Gift { KidId = 1, GiftName = "InsertedName", WebUrl = "InsertedName@Test.com", Priority = 1});

            //Assert
            A.CallTo(() => context.Gift.Add(A<Gift>.Ignored)).MustHaveHappened(Repeated.Exactly.Once);

        }

        [Test]
        public void When_Updating_is_Valid()
        {
            // Arrange
            var gift = new Gift
            {
                GiftId = 2, 
                KidId = 2,
                GiftName = "Gifts 2",
                WebUrl = "GiftEmail2@Test.com",
                Priority = 1
            };
            var returndata = new List<Gift>()
            {
                new Gift{ GiftId = 1, KidId = 1, GiftName = "Gifts 1", WebUrl = "GiftEmail1@Test.com", Priority = 1},
                new Gift{ GiftId = 2, KidId = 2, GiftName = "Gifts 2", WebUrl = "GiftEmail2@Test.com", Priority = 1}
            };

            var context = A.Fake<IDBContext>();
            var fakeDbSet = Aef.FakeDbSet(returndata);
            A.CallTo(() => context.Gift).Returns(fakeDbSet);

            // Act

            var giftDataAccess = new GiftDataAccess(context);
            var updateSuccessful = giftDataAccess.Update(gift);

            //Assert
            Assert.That(updateSuccessful);

        }

        [Test]
        public void When_Updating_is_Invalid()
        {
            // Arrange
            var gift = new Gift
            {
                GiftId = 1,
                KidId = 2,
                GiftName = "Gifts 2",
                WebUrl = "GiftEmail2@Test.com",
                Priority = 1
            };

            var returndata = new List<Gift>();

            var context = A.Fake<IDBContext>();
            var fakeDbSet = Aef.FakeDbSet(returndata);
            A.CallTo(() => context.Gift).Returns(fakeDbSet);

            // Act
            var giftDataAccess = new GiftDataAccess(context);
            var updateSuccessful = giftDataAccess.Update(gift);

            //Assert
            Assert.That(updateSuccessful == false);
        }

        [Test]
        public void When_Deleting_is_Valid()
        {
            // Arrange
            var returndata = new List<Gift>()
            {
                new Gift{ GiftId = 1, KidId = 1, GiftName = "Gifts 1", WebUrl = "GiftEmail1@Test.com", Priority = 1},
                new Gift{ GiftId = 2, KidId = 2, GiftName = "Gifts 2", WebUrl = "GiftEmail2@Test.com", Priority = 1}
            };

            var context = A.Fake<IDBContext>();
            var fakeDbSet = Aef.FakeDbSet(returndata);
            A.CallTo(() => context.Gift).Returns(fakeDbSet);

            // Act

            var deleteGift = new GiftDataAccess(context);
            deleteGift.Delete(2);

            //Assert
            A.CallTo(() => context.Gift.Remove(A<Gift>.Ignored)).MustHaveHappened(Repeated.Exactly.Once);

        }

        [Test]
        public void When_Deleting_is_InValid()
        {
            // Arrange
            var returndata = new List<Gift>()
            {
                new Gift{ GiftId = 1, KidId = 1, GiftName = "Gifts 1", WebUrl = "GiftEmail1@Test.com", Priority = 1},
                new Gift{ GiftId = 2, KidId = 2, GiftName = "Gifts 2", WebUrl = "GiftEmail2@Test.com", Priority = 1}
            };

            var context = A.Fake<IDBContext>();
            var fakeDbSet = Aef.FakeDbSet(returndata);
            A.CallTo(() => context.Gift).Returns(fakeDbSet);

            // Act
            var deleteGiftDataAccess = new GiftDataAccess(context);
            //Assert
            var ex = Assert.Throws<Exception>(() => deleteGiftDataAccess.Delete(3));
            Assert.That(ex.Message == "Error getting Gift record.");
        }


    }
}
