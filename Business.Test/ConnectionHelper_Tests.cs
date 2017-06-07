﻿using System;
using NUnit.Framework;
using win10Core.Business;

namespace Business.Test
{
    [TestFixture]
    public class ConnectionHelperTests
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