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
    public class WhenValidatingLogErrorDataAccess
    {
        [Test]
        //Given_When_Then
        public void When_Returning_GetList_is_Valid()
        {
            // Arrange
            var returndata = new List<LogError>()
            {
                new LogError{ LogErrorId = 1, LogErrorMessage = "A", LogErrorMethod = "B", LogErrorSource = "C"},
                new LogError{ LogErrorId = 2, LogErrorMessage = "A", LogErrorMethod = "B", LogErrorSource = "C"}
            };

            var context = A.Fake<IDBContext>();
            var fakeDbSet = Aef.FakeDbSet(returndata);
            A.CallTo(() => context.LogError).Returns(fakeDbSet);

            // Act
            var getErrorLog  = new LogErrorDataAccess(context);
            var response = getErrorLog.Get();

            //Assert
            Assert.IsNotNull(response);
            Assert.That(response.Count >= 0);

        }

        [Test]
        //Given_When_Then
        public void When_Returning_GetList_is_Empty()
        {
            // Arrange
            var returndata = new List<LogError>();

            var context = A.Fake<IDBContext>();
            var fakeDbSet = Aef.FakeDbSet(returndata);
            A.CallTo(() => context.LogError).Returns(fakeDbSet);

            // Act
            var getErrorLog = new LogErrorDataAccess(context);
            var response = getErrorLog.Get();

            //Assert
            Assert.IsNotNull(response);
            Assert.IsEmpty(response);

        }

        [Test]
        public void When_Returning_Get_is_Valid()
        {
            // Arrange
            var returndata = new List<LogError>()
            {
                new LogError{ LogErrorId = 1, LogErrorMessage = "A", LogErrorMethod = "B", LogErrorSource = "C"},
                new LogError{ LogErrorId = 2, LogErrorMessage = "A", LogErrorMethod = "B", LogErrorSource = "C"}
            };

            var context = A.Fake<IDBContext>();
            var fakeDbSet = Aef.FakeDbSet(returndata);
            A.CallTo(() => context.LogError).Returns(fakeDbSet);

            // Act

            var getErrorLog = new LogErrorDataAccess(context);
            var response = getErrorLog.Get(2);

            //Assert
            Assert.IsNotNull(response);
            Assert.That(response.LogErrorId ==2 );

        }

        [Test]
        public void When_Get_is_InValid_With_0()
        {
            // Arrange
            var returndata = new List<LogError>()
            {
                new LogError{ LogErrorId = 1, LogErrorMessage = "A", LogErrorMethod = "B", LogErrorSource = "C"},
                new LogError{ LogErrorId = 2, LogErrorMessage = "A", LogErrorMethod = "B", LogErrorSource = "C"}
            };

            var context = A.Fake<IDBContext>();
            var fakeDbSet = Aef.FakeDbSet(returndata);
            A.CallTo(() => context.LogError).Returns(fakeDbSet);

            // Act

            var getErrorLog = new LogErrorDataAccess(context);

            var ex = Assert.Throws<ArgumentException>(() => getErrorLog.Get(0));
            Assert.That(ex.Message == "Invalid id Paramter");

            //Assert
        }

        [Test]
        public void When_Get_is_InValid_id()
        {
            // Arrange
            var returndata = new List<LogError>()
            {
                new LogError{ LogErrorId = 1, LogErrorMessage = "A", LogErrorMethod = "B", LogErrorSource = "C"},
                new LogError{ LogErrorId = 2, LogErrorMessage = "A", LogErrorMethod = "B", LogErrorSource = "C"}
            };

            var context = A.Fake<IDBContext>();
            var fakeDbSet = Aef.FakeDbSet(returndata);
            A.CallTo(() => context.LogError).Returns(fakeDbSet);

            // Act
            var getErrorLog = new LogErrorDataAccess(context);

            //Assert
            var ex = Assert.Throws<Exception>(() => getErrorLog.Get(3));
            Assert.That(ex.Message == "Error getting LogError record.");
        }

        [Test]
        public void When_Inserting_is_Valid()
        {
            // Arrange
            var returndata = new LogError
            {
                LogErrorId = 1,
                LogErrorMessage = "A",
                LogErrorMethod = "B",
                LogErrorSource = "C"
            };
            var context = A.Fake<IDBContext>();
            A.CallTo(() => context.LogError.Add(A<LogError>.Ignored)).Returns(returndata);


            // Act
            var x = new LogErrorDataAccess(context);
            x.Insert(new LogError { LogErrorMessage = "A", LogErrorMethod = "B", LogErrorSource = "C" });

            //Assert
            A.CallTo(() => context.LogError.Add(A<LogError>.Ignored)).MustHaveHappened(Repeated.Exactly.Once);
            // Assert.IsNotNull(response);
            // Assert.That(response.Count >= 0);

        }

        [Test]
        public void When_Updating_is_Valid()
        {
            // Arrange
            var logError = new LogError
            {
                LogErrorId = 2,
                LogErrorMessage = "A",
                LogErrorMethod = "B",
                LogErrorSource = "C"
            };

            var returndata = new List<LogError>()
            {
                new LogError{ LogErrorId = 1, LogErrorMessage = "D", LogErrorMethod = "E", LogErrorSource = "F"},
                new LogError{ LogErrorId = 2, LogErrorMessage = "D", LogErrorMethod = "E", LogErrorSource = "F"}
            };

            var context = A.Fake<IDBContext>();
            var fakeDbSet = Aef.FakeDbSet(returndata);
            A.CallTo(() => context.LogError).Returns(fakeDbSet);

            // Act

            var logErrorDataAccess = new LogErrorDataAccess(context);
            var updateSuccessful = logErrorDataAccess.Update(logError);

            //Assert
            Assert.That(updateSuccessful);

        }

        [Test]
        public void When_Updating_is_Invalid()
        {
            // Arrange
            var logError = new LogError
            {
                LogErrorId = 2,
                LogErrorMessage = "A",
                LogErrorMethod = "B",
                LogErrorSource = "C"
            };

            var returndata = new List<LogError>();

            var context = A.Fake<IDBContext>();
            var fakeDbSet = Aef.FakeDbSet(returndata);
            A.CallTo(() => context.LogError).Returns(fakeDbSet);

            // Act

            var logErrorDa = new LogErrorDataAccess(context);
            var updateSuccessful = logErrorDa.Update(logError);

            //Assert
            Assert.That(updateSuccessful == false);

        }

        [Test]
        public void When_Deleting_is_Valid()
        {
            // Arrange
            var returndata = new List<LogError>()
            {
                new LogError{ LogErrorId = 1, LogErrorMessage = "A", LogErrorMethod = "B", LogErrorSource = "C"},
                new LogError{ LogErrorId = 2, LogErrorMessage = "A", LogErrorMethod = "B", LogErrorSource = "C"}
            };
            var context = A.Fake<IDBContext>();
            var fakeDbSet = Aef.FakeDbSet(returndata);
            A.CallTo(() => context.LogError).Returns(fakeDbSet);

            // Act

            var x = new LogErrorDataAccess(context);
            x.Delete(2);

            //Assert
            //Assert.IsNotNull(response);
           // Assert.That(response.LogErrorId == 2);

        }

        [Test]
        public void When_Deleting_is_InValid()
        {
            // Arrange
            var returndata = new List<LogError>()
            {
                new LogError{ LogErrorId = 1, LogErrorMessage = "A", LogErrorMethod = "B", LogErrorSource = "C"},
                new LogError{ LogErrorId = 2, LogErrorMessage = "A", LogErrorMethod = "B", LogErrorSource = "C"}
            };
            var context = A.Fake<IDBContext>();
            var fakeDbSet = Aef.FakeDbSet(returndata);
            A.CallTo(() => context.LogError).Returns(fakeDbSet);

            // Act

            var deletelogError = new LogErrorDataAccess(context);
            var ex = Assert.Throws<Exception>(() => deletelogError.Delete(3));
            Assert.That(ex.Message == "Error getting LogError record.");
            //Assert
            //Assert.IsNotNull(response);
            // Assert.That(response.LogErrorId == 2);

        }

    }
}
