
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace JustDo.DAL
{
	public class DALBase
	{
        private readonly IConfiguration _config;
        public DALBase(IConfiguration config)
		{
            _config = config;
            connectionString = _config.GetConnectionString("justDoDb");
        }
        public SqlConnection Connection
        {
            get
            {
                if(_connection == null)
                    _connection = new SqlConnection(connectionString);
                
                return _connection;
            }
        }


        string connectionString = "";
        private SqlConnection _connection;

        protected void OpenConnection()
        {
			switch (_connection.State)
			{
				case ConnectionState.Closed:
					_connection.Open();
					break;
				case ConnectionState.Broken:
					_connection.Close();
					_connection.Open();
					break;
			}
		}


        protected virtual void CloseConnection()
        {
			switch (_connection.State)
			{
				case ConnectionState.Open:
					_connection.Close();
					break;
				case ConnectionState.Broken:
					_connection.Close();
					break;
			}
		}

        protected SqlParameter newParam(string name, object paramvalue, SqlDbType otype)
        {
            var par = new SqlParameter(name, otype);
            par.Value = paramvalue;
            return par;
        }
    }
}
