using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.CodeAnalysis;
using AutoMapper;
using win10Core.Business.DataAccess.Interfaces;

namespace win10Core.Business.DataAccess
{
    [ExcludeFromCodeCoverage]
    public class DataAccess : IDataAccess
    {
        readonly string _constr;

        public DataAccess(string connectionstring)
        {
            _constr = connectionstring;
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
