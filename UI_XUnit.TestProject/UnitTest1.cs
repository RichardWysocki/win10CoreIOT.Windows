using OpenQA.Selenium.Chrome;
using System;
using Xunit;

namespace UI_XUnit.TestProject
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var driver = new ChromeDriver(System.Environment.CurrentDirectory);

            var response = ConfigurationSettingBuilder.GetSetting("PageURL");


            try
            {
                driver.Url = "http://www.google.com/";
                driver.FindElementByName("q").SendKeys("Testing");
                driver.FindElementByName("RichardTEST").SendKeys("Testing");
            }
            catch (Exception e)
            {
                Assert.True(1==2, e.Message);
            }
            finally
            {
                driver.Close();
            }


            

            

        }
    }
}
