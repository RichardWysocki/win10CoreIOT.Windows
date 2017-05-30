using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using AutoMapper;

namespace ClassLibrary
{
    public class DataAccess : IDataAccess
    {
        readonly string _constr = ""; //"Data Source=DESKTOP-726BCQD;Initial Catalog=RichExample;Integrated Security=True;MultipleActiveResultSets=True";

        public DataAccess(string connectionstring)
        {
            _constr = connectionstring;
        }
        public IList<T> ReadData<T>(string storedProcedure)
        {
            IList<T> members = new List<T>();
            //string constr = "Data Source=DESKTOP-726BCQD;Initial Catalog=RichExample;Integrated Security=True;MultipleActiveResultSets=True";
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
