using System;
using System.Linq;
using AutoMapper;
using NUnit.Framework;
using win10Core.Business;
using win10Core.Business.DataAccess;
using win10Core.Business.Model;
using System.Data;

namespace Integration.Business
{
    [TestFixture]
    public class CustomerDataAccessTests
    {
        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<IDataRecord, Customer>()
                    .ForMember(source => source.CustomerId, source => source.MapFrom(s => s.GetValue(s.GetOrdinal("CustomerID"))))
                    .ForMember(dest => dest.FirstName, source => source.MapFrom(s => s.GetValue(s.GetOrdinal("FirstName"))))
                    .ForMember(dest => dest.LastName, source => source.MapFrom(s => s.GetValue(s.GetOrdinal("LastName"))));

                cfg.CreateMap<Customer, Client>();

                //cfg.CreateMap<IDataRecord, Client>();


            });
            Mapper.AssertConfigurationIsValid();
        }
        [Test]
        public void When_Inserting_ValidCustomer_Return_Successful()
        {
            //Arrange
            var connection = ConfigHelper.GetSetting("DBConnection");
            var customerClient = new CustomerDataAccess_Remove(connection);
            //Act
            var insert = customerClient.Insert(new Customer() {FirstName = "x1", LastName = "x1"});
            //Assert
            Assert.IsTrue(insert);

        }

        [Test]
        public void When_Deleting_ValidCustomer_Return_Successful()
        {
            //Arrange
            var connection = ConfigHelper.GetSetting("DBConnection");
            var customerClient = new CustomerDataAccess_Remove(connection);

            var read = customerClient.ReadData<Customer>("Customer_List");
            var deleteCustomer = read.OrderByDescending(c => c.CustomerId).First();

            //Act
            var delete = customerClient.Delete(deleteCustomer.CustomerId);
            //Assert
            Assert.IsTrue(delete);

        }
        [Test]
        public void When_Update_Customer_Return_Successful()
        {
            //Arrange
            var connection = ConfigHelper.GetSetting("DBConnection");
            var customerClient = new CustomerDataAccess_Remove(connection);
            var read = customerClient.ReadData<Customer>("Customer_List");
            var updateRecord = read.OrderByDescending(c => c.CustomerId).First();
            updateRecord.FirstName = "First " + new Random().Next();
            updateRecord.LastName = "Last " + new Random().Next();
            //Act
            var update = customerClient.Update(updateRecord);
            //Assert
            Assert.IsTrue(update);

        }
        [Test]
        public void When_Reading_Customer_Return_Successful()
        {

            //Arrange
            var connection = ConfigHelper.GetSetting("DBConnection");
            var customerClient = new CustomerDataAccess_Remove(connection);
            //Act
            var read = customerClient.ReadData<Customer>("Customer_List");
            //Assert
            Assert.IsTrue(read.Count>0);

        }
    }
}
