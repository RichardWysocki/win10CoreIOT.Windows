using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.CodeAnalysis;
using AutoMapper;
using win10Core.Business.Standard.Model;

namespace win10Core.Business.Standard.DataAccess
{
    [ExcludeFromCodeCoverage]

    public class ClientDataAccess
    {
        readonly string _constr; 

        public ClientDataAccess(string connectionstring)
        {
            _constr = connectionstring;
        }

        public bool Insert(Client client)
        {
            bool insertSuccessful;

            if (client == null) // || !kid.IsValidNew())
                throw new ArgumentException();


            using (var connection = new SqlConnection(_constr))
            using (var cmd = new SqlCommand("Client_Insert", connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                connection.Open();
                // Start a local transaction.
                var transaction = cmd.Connection.BeginTransaction(IsolationLevel.ReadCommitted, "Client_Insert");
                cmd.Transaction = transaction;

                try
                {
                    cmd.Parameters.Add("@ClientName", SqlDbType.Text, 50);
                    cmd.Parameters.Add("@Email", SqlDbType.Text, 150);
                    cmd.Parameters["@ClientName"].Value = client.FirstName;
                    cmd.Parameters["@Email"].Value = client.LastName;

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
                            Console.WriteLine("An exception of type " + ex.GetType() + " was encountered while attempting to roll back the transaction.");
                        }
                    }

                    Console.WriteLine("An exception of type " + e.GetType() + " was encountered while inserting the data.");
                    Console.WriteLine("Neither record was written to database.");
                    insertSuccessful = false;
                }



            }

            return insertSuccessful;

        }

        //public bool Insert(Client client)
        //{
        //    bool insertSuccessful;

        //    if (client == null) // || !kid.IsValidNew())
        //        throw new ArgumentException();


        //    //using (var connection = new SqlConnection(_constr))
        //    //using (var cmd = new SqlCommand("Client_Insert", connection))
        //    //{
        //    //    cmd.CommandType = CommandType.StoredProcedure;
        //    //    connection.Open();
        //    //    using (var reader = command.ExecuteReader())

        //    //}

        //    var cmd = DbUtility.SqlCommand(_constr, "Client_Insert");
        //    // Start a local transaction.
        //    var transaction = cmd.Connection.BeginTransaction(IsolationLevel.ReadCommitted, "Client_Insert");
        //    cmd.Transaction = transaction;

        //    try
        //    {
        //        cmd.Parameters.Add("@ClientName", SqlDbType.Text, 50);
        //        cmd.Parameters.Add("@Email", SqlDbType.Text, 150);
        //        cmd.Parameters["@ClientName"].Value = client.FirstName;
        //        cmd.Parameters["@Email"].Value = client.LastName;

        //        int returnValue = cmd.ExecuteNonQuery();
        //        transaction.Commit();
        //        if (returnValue < 0)
        //        {
        //            throw new Exception("Error Text Added to the Database: " + returnValue.ToString());
        //        }
        //        insertSuccessful = true;
        //    }
        //    catch (Exception e)
        //    {
        //        try
        //        {
        //            transaction.Rollback();
        //        }
        //        catch (SqlException ex)
        //        {
        //            if (transaction.Connection != null)
        //            {
        //                Console.WriteLine("An exception of type " + ex.GetType() + " was encountered while attempting to roll back the transaction.");
        //            }
        //        }

        //        Console.WriteLine("An exception of type " + e.GetType() + " was encountered while inserting the data.");
        //        Console.WriteLine("Neither record was written to database.");
        //        insertSuccessful = false;
        //    }
        //    return insertSuccessful;

        //}

        public bool Update(Client updateKid)
        {
            bool updateSuccessful;

            if (updateKid == null) // || !updateKid.IsValidUpdate())
                throw new ArgumentException();

            var cmd = DbUtility.SqlCommand(_constr, "Client_Update");
            SqlTransaction transaction;
            // Start a local transaction.
            transaction = cmd.Connection.BeginTransaction(IsolationLevel.ReadCommitted, "Client_Update");
            cmd.Transaction = transaction;
            try
            {
                cmd.Parameters.Add("@KidID", SqlDbType.Int);
                cmd.Parameters.Add("@Name", SqlDbType.Text, 50);
                cmd.Parameters.Add("@Email", SqlDbType.Text, 150);
                cmd.Parameters["@KidID"].Value = updateKid.CustomerID;
                cmd.Parameters["@Name"].Value = updateKid.FirstName;
                cmd.Parameters["@Email"].Value = updateKid.LastName;

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
            return updateSuccessful;
        }

        public bool Delete(int deleteId)
        {
            if (deleteId == 0)
                throw new ArgumentException();

            var cmd = DbUtility.SqlCommand(_constr, "Client_Delete");

            SqlTransaction transaction;
            // Start a local transaction.
            transaction = cmd.Connection.BeginTransaction(IsolationLevel.ReadCommitted, "Client_Delete");
            cmd.Transaction = transaction;
            try
            {
                cmd.Parameters.Add("@ClientID", SqlDbType.Int, 50);
                cmd.Parameters["@ClientID"].Value = deleteId;

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
                Console.WriteLine("An exception of type " + e.GetType() + " was encountered while attempting to delete the transaction.");
                throw;
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
