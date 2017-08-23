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
    [TestFixture]
    public class WhenValidatingCustomerDataAccess
    {
        [Test]
        //Given_When_Then
        public void When_Returning_GetList_is_Valid()
        {
            // Arrange
            var returndata = new List<Customer>()
            {
                new Customer{ CustomerId = 1, FirstName = "A", LastName = "B"},
                new Customer{ CustomerId = 2, FirstName = "A", LastName = "B"}
            };

            var context = A.Fake<IDBContext>();
            var fakeDbSet = Aef.FakeDbSet(returndata);
            A.CallTo(() => context.Customer).Returns(fakeDbSet);

            // Act
            var getCustomerDataAccess = new CustomerDataAccess(context);
            var response = getCustomerDataAccess.Get();

            //Assert
            Assert.IsNotNull(response);
            Assert.That(response.Count >= 0);

        }

        [Test]
        public void When_Returning_GetList_is_Empty()
        {
            // Arrange
            var returndata = new List<Customer>();

            var context = A.Fake<IDBContext>();
            var fakeDbSet = Aef.FakeDbSet(returndata);
            A.CallTo(() => context.Customer).Returns(fakeDbSet);

            // Act
            var getCustomerDataAccess = new CustomerDataAccess(context);
            var response = getCustomerDataAccess.Get();

            //Assert
            Assert.IsNotNull(response);
            Assert.IsEmpty(response);
        }

        [Test]
        public void When_Returning_Get_is_Valid()
        {
            // Arrange
            var returndata = new List<Customer>()
            {
                new Customer{ CustomerId = 1, FirstName = "A", LastName = "B"},
                new Customer{ CustomerId = 2, FirstName = "A", LastName = "B"}
            };

            var context = A.Fake<IDBContext>();
            var fakeDbSet = Aef.FakeDbSet(returndata);
            A.CallTo(() => context.Customer).Returns(fakeDbSet);

            // Act

            var getCustomerDataAccess = new CustomerDataAccess(context);
            var response = getCustomerDataAccess.Get(2);

            //Assert
            Assert.IsNotNull(response);
            Assert.That(response.CustomerId == 2);

        }

        [Test]
        public void When_Get_is_InValid_With_0()
        {
            // Arrange
            var returndata = new List<Customer>()
            {
                new Customer{ CustomerId = 1, FirstName = "A", LastName = "B"},
                new Customer{ CustomerId = 2, FirstName = "A", LastName = "B"}
            };


            var context = A.Fake<IDBContext>();
            var fakeDbSet = Aef.FakeDbSet(returndata);
            A.CallTo(() => context.Customer).Returns(fakeDbSet);

            // Act 
            var getCustomerDataAccess = new CustomerDataAccess(context);

            //Assert
            var ex = Assert.Throws<ArgumentException>(() => getCustomerDataAccess.Get(0));
            Assert.That(ex.Message == "Invalid id Paramter");
        }

        [Test]
        public void When_Get_is_InValid_id()
        {
            // Arrange
            var returndata = new List<Customer>()
            {
                new Customer{ CustomerId = 1, FirstName = "A", LastName = "B"},
                new Customer{ CustomerId = 2, FirstName = "A", LastName = "B"}
            };


            var context = A.Fake<IDBContext>();
            var fakeDbSet = Aef.FakeDbSet(returndata);
            A.CallTo(() => context.Customer).Returns(fakeDbSet);

            // Act
            var getCustomerDataAccess = new CustomerDataAccess(context);

            //Assert
            var ex = Assert.Throws<Exception>(() => getCustomerDataAccess.Get(3));
            Assert.That(ex.Message == "Error getting Customer record.");
        }

        [Test]
        public void When_Inserting_is_Valid()
        {
            // Arrange
            var returndata = new Customer()
            {
                CustomerId = 1,
                FirstName = "A",
                LastName = "B"
            };
            var context = A.Fake<IDBContext>();
            A.CallTo(() => context.Customer.Add(A<Customer>.Ignored)).Returns(returndata);

            // Act
            var insertCustomerDataAccess = new CustomerDataAccess(context);
            insertCustomerDataAccess.Insert(new Customer { FirstName = "A", LastName = "B" });

            //Assert
            A.CallTo(() => context.Customer.Add(A<Customer>.Ignored)).MustHaveHappened(Repeated.Exactly.Once);

        }

        [Test]
        public void When_Updating_is_Valid()
        {
            // Arrange
            var customer = new Customer()
            {
                CustomerId = 2,
                FirstName = "A",
                LastName = "B"
            };
            var returndata = new List<Customer>()
            {
                new Customer{ CustomerId = 1, FirstName = "A", LastName = "B"},
                new Customer{ CustomerId = 2, FirstName = "A", LastName = "B"}
            };

            var context = A.Fake<IDBContext>();
            var fakeDbSet = Aef.FakeDbSet(returndata);
            A.CallTo(() => context.Customer).Returns(fakeDbSet);

            // Act

            var customerDataAccess = new CustomerDataAccess(context);
            var updateSuccessful = customerDataAccess.Update(customer);

            //Assert
            Assert.That(updateSuccessful);

        }

        [Test]
        public void When_Updating_is_Invalid()
        {
            // Arrange
            var customer = new Customer()
            {
                CustomerId = 2,
                FirstName = "A",
                LastName = "B"
            };

            var returndata = new List<Customer>();

            var context = A.Fake<IDBContext>();
            var fakeDbSet = Aef.FakeDbSet(returndata);
            A.CallTo(() => context.Customer).Returns(fakeDbSet);

            // Act
            var customerDataAccess = new CustomerDataAccess(context);
            var updateSuccessful = customerDataAccess.Update(customer);

            //Assert
            Assert.That(updateSuccessful == false);
        }

        [Test]
        public void When_Deleting_is_Valid()
        {
            // Arrange
            var returndata = new List<Customer>()
            {
                new Customer{ CustomerId = 1, FirstName = "A", LastName = "B"},
                new Customer{ CustomerId = 2, FirstName = "A", LastName = "B"}
            };

            var context = A.Fake<IDBContext>();
            var fakeDbSet = Aef.FakeDbSet(returndata);
            A.CallTo(() => context.Customer).Returns(fakeDbSet);

            // Act

            var deleteCustomer = new CustomerDataAccess(context);
            deleteCustomer.Delete(2);

            //Assert
            //Assert.IsNotNull(response);
            // Assert.That(response.LogErrorId == 2);

        }

        [Test]
        public void When_Deleting_is_InValid()
        {
            // Arrange
            var returndata = new List<Customer>()
            {
                new Customer{ CustomerId = 1, FirstName = "A", LastName = "B"},
                new Customer{ CustomerId = 2, FirstName = "A", LastName = "B"}
            };

            var context = A.Fake<IDBContext>();
            var fakeDbSet = Aef.FakeDbSet(returndata);
            A.CallTo(() => context.Customer).Returns(fakeDbSet);

            // Act
            var deleteCustomerDataAccess = new CustomerDataAccess(context);
            //Assert
            var ex = Assert.Throws<Exception>(() => deleteCustomerDataAccess.Delete(3));
            Assert.That(ex.Message == "Error getting Customer record.");
        }

    }
}
