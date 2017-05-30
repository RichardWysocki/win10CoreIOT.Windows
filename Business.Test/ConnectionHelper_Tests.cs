using System;
using ClassLibrary;
using NUnit.Framework;

namespace WebApplication.Tests.Business
{
    [TestFixture]
    public class ConnectionHelper_Tests
    {
        [Test]
        [TestCase("InValidKey")]
        public void Given_No_Configuration_ThrowFaultException(string configKey)
        {
            //Arrange


            //var test = ConfigHelper.GetSetting("InValidKey");
            //Act

            var ex = Assert.Throws<Exception>(() => ConfigHelper.GetSetting(configKey));
            Assert.That(ex.Message == $"InValid Configuration for {configKey}");
        }

        [Test]
        [TestCase("ValidKey", "KeyValue")]
        public void Given_Valid_Configuration_Return_Confirmation(string configKey, string keyValue)
        {
            //Arrange
            
            //Act
            var response = ConfigHelper.GetSetting(configKey);

            //Assert
            Assert.That(response == keyValue);
        }
    }
}