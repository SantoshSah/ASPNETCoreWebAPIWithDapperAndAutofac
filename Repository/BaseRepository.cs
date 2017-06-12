using System;
using System.Data;

namespace Repository
{
	public class BaseRepository : IDisposable
	{
		protected IDbConnection con;
		public BaseRepository()
		{
			string connectionString = "server=138.197.126.189;database=dbname;uid=dbusername;pwd=password;port=3306;";
			con = new MySql.Data.MySqlClient.MySqlConnection(connectionString);
		}

		public void Dispose()
		{
			//throw new NotImplementedException();
		}
	}
}
