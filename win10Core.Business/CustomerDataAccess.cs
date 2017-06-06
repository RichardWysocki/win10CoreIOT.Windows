using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using AutoMapper;

namespace ClassLibrary
{
    public class CustomerDataAccess : DataAccess, IDataAccess
    {

        public CustomerDataAccess(string connectionstring) : base(connectionstring)
        {



        }

   
    }
}
