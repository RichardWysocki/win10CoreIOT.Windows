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
    public class WhenValidatingLogInfoDataAccess
    {
        [Test]
        //Given_When_Then
        public void When_Returning_GetList_is_Valid()
        {
            // Arrange
            var returndata = new List<LogInfo>()
            {
                new LogInfo{ LogInfoId = 1, Method = "A", Message = "B"},
                new LogInfo{ LogInfoId = 2, Method = "A", Message = "B"}
            };

            var context = A.Fake<IDBContext>();
            var fakeDbSet = Aef.FakeDbSet(returndata);
            A.CallTo(() => context.LogInfo).Returns(fakeDbSet);

            // Act
            var logDataAccess = new LogInfoDataAccess(context);
            var response = logDataAccess.Get();

            // Assert
            Assert.IsNotNull(response);
            Assert.That(response.Count >= 0);
        }

        [Test]
        //Given_When_Then
        public void When_Returning_GetList_is_Empty()
        {
            // Arrange
            var returndata = new List<LogInfo>();
            var context = A.Fake<IDBContext>();
            var fakeDbSet = Aef.FakeDbSet(returndata);
            A.CallTo(() => context.LogInfo).Returns(fakeDbSet);

            // Act
            var logDataAccess = new LogInfoDataAccess(context);
            var response = logDataAccess.Get();

            // Assert
            Assert.IsNotNull(response);
            Assert.IsEmpty(response);
        }

        [Test]
        public void When_Returning_Get_is_Valid()
        {
            // Arrange
            var returndata = new List<LogInfo>()
            {
                new LogInfo{ LogInfoId = 1, Method = "A1", Message = "B1"},
                new LogInfo{ LogInfoId = 2, Method = "A2", Message = "B2"}
            };
            var context = A.Fake<IDBContext>();
            var fakeDbSet = Aef.FakeDbSet(returndata);
            A.CallTo(() => context.LogInfo).Returns(fakeDbSet);

            // Act
            var logDataAccess = new LogInfoDataAccess(context);
            var response = logDataAccess.Get(2);

            // Assert
            Assert.IsNotNull(response);
            Assert.That(response.LogInfoId == 2);
            Assert.That(response.Method == "A2");
            Assert.That(response.Message == "B2");
        }

        [Test]
        public void When_Get_is_InValid_With_0()
        {
            // Arrange
            var returndata = new List<LogInfo>()
            {
                new LogInfo{ LogInfoId = 1, Method = "A", Message = "B"},
                new LogInfo{ LogInfoId = 2, Method = "A", Message = "B"}
            };

            var context = A.Fake<IDBContext>();
            var fakeDbSet = Aef.FakeDbSet(returndata);
            A.CallTo(() => context.LogInfo).Returns(fakeDbSet);

            // Act
            var logDataAccess = new LogInfoDataAccess(context);

            // Assert
            var ex = Assert.Throws<ArgumentException>(() => logDataAccess.Get(0));
            Assert.That(ex.Message == "Invalid id Paramter");
        }

        [Test]
        public void When_Get_is_InValid_id()
        {
            // Arrange
            var returndata = new List<LogInfo>()
            {
                new LogInfo{ LogInfoId = 1, Method = "A", Message = "B"},
                new LogInfo{ LogInfoId = 2, Method = "A", Message = "B"}
            };
            var context = A.Fake<IDBContext>();
            var fakeDbSet = Aef.FakeDbSet(returndata);
            A.CallTo(() => context.LogInfo).Returns(fakeDbSet);

            // Act
            var logDataAccess = new LogInfoDataAccess(context);

            //Assert
            var ex = Assert.Throws<Exception>(() => logDataAccess.Get(3));
            Assert.That(ex.Message == "Error getting LogInfo record.");
        }

        [Test]
        public void When_Inserting_is_Valid()
        {
            // Arrange
            var returndata = new LogInfo
            {
                LogInfoId = 1,
                Method = "A",
                Message = "B"
            };
            var context = A.Fake<IDBContext>();
            A.CallTo(() => context.LogInfo.Add(A<LogInfo>.Ignored)).Returns(returndata);

            // Act
            var logDataAccess = new LogInfoDataAccess(context);
            logDataAccess.Insert(new LogInfo { Method = "A", Message = "B" });

            //Assert
            A.CallTo(() => context.LogInfo.Add(A<LogInfo>.Ignored)).MustHaveHappened(Repeated.Exactly.Once);

        }

    }
}
