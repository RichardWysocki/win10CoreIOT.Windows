using System.Data;
using System.Data.SqlClient;

namespace win10Core.Business.Standard
{
    public class DbUtility
    {
        public static SqlCommand SqlCommand(string connection, string storedProcedure)
        {
            SqlCommand cmd = DbCmd;
            cmd.Parameters.Clear();
            cmd.CommandText = storedProcedure;
            cmd.CommandType = CommandType.StoredProcedure;

            return cmd;
        }
        private static SqlCommand _dbCmd;
        public static SqlCommand DbCmd
        {
            get
            {
                if (_dbCmd == null)
                {
                    _dbCmd = new SqlCommand()
                    {
                        Connection = DbConn
                    };
                }
                return _dbCmd;
            }
        }
        private static SqlConnection _dbConn;
        public static SqlConnection DbConn
        {
            get
            {
                if ((_dbConn == null) || (_dbConn.State != ConnectionState.Open))
                {
                    _dbConn = new SqlConnection(DbConnection);
                    _dbConn.Open();
                }

                return _dbConn;
            }
        }

        public static string DbConnection
        {
            get
            {
                return "Data Source=DESKTOP-726BCQD;Initial Catalog=RichExample;Integrated Security=True;MultipleActiveResultSets=True"; //ConfigurationManager.AppSettings["connectionString"];
            }
        }
    }
}
