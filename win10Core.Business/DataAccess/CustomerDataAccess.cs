using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using AutoMapper;
using win10Core.Business.Model;

namespace win10Core.Business.DataAccess
{
    public class CustomerDataAccess : ICustomerDataAccess
    {
        readonly string _constr;

        public CustomerDataAccess(string connectionstring)
        {
            _constr = connectionstring;
        }

        public bool Insert(Customer customer)
        {
            bool insertSuccessful;

            if (customer == null) // || !kid.IsValidNew())
                throw new ArgumentException();


            using (var connection = new SqlConnection(_constr))
            using (var cmd = new SqlCommand("Customer_Insert", connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                connection.Open();
                // Start a local transaction.
                var transaction = cmd.Connection.BeginTransaction(IsolationLevel.ReadCommitted, "Customer_Insert");
                cmd.Transaction = transaction;

                try
                {
                    cmd.Parameters.Add("@FirstName", SqlDbType.Text, 50);
                    cmd.Parameters.Add("@LastName", SqlDbType.Text, 150);
                    cmd.Parameters["@FirstName"].Value = customer.FirstName;
                    cmd.Parameters["@LastName"].Value = customer.LastName;

                    int returnValue = cmd.ExecuteNonQuery();
                    transaction.Commit();
                    if (returnValue < 0)
                    {
                        throw new Exception("Error Text Added to the Database: " + returnValue.ToString());
                    }
                    insertSuccessful = true;
                }
                catch (Exception e)
                {
                    try
                    {
                        transaction.Rollback();
                    }
                    catch (SqlException ex)
                    {
                        if (transaction.Connection != null)
                        {
                            Console.WriteLine("An exception of type " + ex.GetType() +
                                              " was encountered while attempting to roll back the transaction.");
                        }
                    }

                    Console.WriteLine("An exception of type " + e.GetType() +
                                      " was encountered while inserting the data.");
                    Console.WriteLine("Neither record was written to database.");
                    insertSuccessful = false;
                }
            }

            return insertSuccessful;
        }


        public bool Update(Customer updateCustomer)
        {
            bool updateSuccessful;

            if (updateCustomer == null) // || !updateKid.IsValidUpdate())
                throw new ArgumentException();
            using (var connection = new SqlConnection(_constr))
            using (var cmd = new SqlCommand("Customer_Update", connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                connection.Open();
                // Start a local transaction.
                var transaction = cmd.Connection.BeginTransaction(IsolationLevel.ReadCommitted, "Customer_Update");
                cmd.Transaction = transaction;

                try
                {
                    cmd.Parameters.Add("@CustomerId", SqlDbType.Int);
                    cmd.Parameters.Add("@FirstName", SqlDbType.Text, 50);
                    cmd.Parameters.Add("@LastName", SqlDbType.Text, 150);
                    cmd.Parameters["@CustomerId"].Value = updateCustomer.CustomerId;
                    cmd.Parameters["@FirstName"].Value = updateCustomer.FirstName;
                    cmd.Parameters["@LastName"].Value = updateCustomer.LastName;

                    int returnValue = cmd.ExecuteNonQuery();
                    transaction.Commit();

                    if (returnValue < 0)
                    {
                        throw new Exception("Error Text Added to the Database: " + returnValue.ToString());
                    }
                    else
                    {
                        updateSuccessful = true;
                    }
                }
                catch (Exception e)
                {
                    try
                    {
                        transaction.Rollback();
                    }
                    catch (SqlException ex)
                    {
                        if (transaction.Connection != null)
                        {
                            Console.WriteLine("An exception of type " + ex.GetType() +
                                              " was encountered while attempting to roll back the transaction.");
                        }
                    }

                    Console.WriteLine("An exception of type " + e.GetType() +
                                      " was encountered while inserting the data.");
                    Console.WriteLine("Neither record was written to database.");
                    updateSuccessful = false;
                }
            }
            return updateSuccessful;
        }

        public bool Delete(int deleteId)
        {
            if (deleteId == 0)
                throw new ArgumentException();

            using (var connection = new SqlConnection(_constr))
            using (var cmd = new SqlCommand("Customer_Delete", connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                connection.Open();
                // Start a local transaction.
                var transaction = cmd.Connection.BeginTransaction(IsolationLevel.ReadCommitted, "Customer_Delete");
                cmd.Transaction = transaction;
                try
                {
                    cmd.Parameters.Add("@CustomerId", SqlDbType.Int, 50);
                    cmd.Parameters["@CustomerId"].Value = deleteId;

                    int returnValue = cmd.ExecuteNonQuery();
                    transaction.Commit();

                    if (returnValue < 1)
                    {
                        throw new Exception("Error Text Added to the Database: " + returnValue.ToString());
                    }
                    //System.Web.HttpContext.Current.Cache.Remove("PLUList");
                }
                catch (Exception e)
                {
                    Console.WriteLine("An exception of type " + e.GetType() +
                                      " was encountered while attempting to delete the transaction.");
                    throw;
                }
            }
            return true;
        }


        public IList<T> ReadData<T>(string storedProcedure)
        {


            IList<T> members = new List<T>();
            using (var connection = new SqlConnection(_constr))
            using (var command = new SqlCommand(storedProcedure, connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                connection.Open();
                using (var reader = command.ExecuteReader())
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            members.Add(Mapper.Map<IDataReader, T>(reader));
                        }
                    }
            }
            return members;
        }
    }
}