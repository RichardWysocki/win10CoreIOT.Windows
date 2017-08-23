using FakeItEasy;
using NUnit.Framework;
using win10Core.Business.DataAccess.Interfaces;
using win10Core.Business.Engine;
using win10Core.Business.Model;

namespace Business.Test.Engine
{
    [TestFixture()]
    public class WhenValidatingLogEngine
    {
        [Test]
        public void When_Using_LogInfo()
        {
            //Arange
                var logInfo = A.Fake<ILogInfoDataAccess>();
                var errorData = A.Fake<ILogErrorDataAccess>();
             A.CallTo(() => logInfo.Insert(A<LogInfo>.Ignored)).Returns(null);

            //Act
            var logEngine = new LogEngine(logInfo, errorData);
                logEngine.LogInfo("Method Name", "Message...");

            //Assert
            A.CallTo(() => logInfo.Insert(A<LogInfo>.Ignored)).MustHaveHappened(Repeated.Exactly.Once);

        }

        [Test]
        public void When_Using_LogError()
        {
            //Arange
            var logInfo = A.Fake<ILogInfoDataAccess>();
            var errorData = A.Fake<ILogErrorDataAccess>();

            //Act
            var logEngine = new LogEngine(logInfo, errorData);
            logEngine.LogError("Source", "Method Name", "Message...");

            //Assert
            A.CallTo(() => errorData.Insert(A<LogError>.Ignored)).MustHaveHappened(Repeated.Exactly.Once);

        }
    }
}
