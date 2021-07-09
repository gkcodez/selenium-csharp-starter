using System.Data;
using System.Data.SqlClient;
using System.Runtime.InteropServices;
using Automation.Base;

namespace Automation.Helpers
{
	public class DBHelper
	{
		private static SqlConnection connection = null;

		public static void ConnectDB()
		{
			connection = new SqlConnection(Config.ConnectionString);
			connection.Open();
		}

		public static DataTable ExecuteQuery(string query)
		{
			DataTable table = new DataTable();
			using (SqlCommand command = new SqlCommand(query, connection))
			using (SqlDataAdapter adapter = new SqlDataAdapter(command))
			{
				adapter.Fill(table);
			}

			return table;
		}

		public static DataTable ExecuteStoredProcedure(string procedureName, [Optional] params object[] parameters)
		{
			DataTable table = new DataTable();
			using (SqlCommand command = new SqlCommand(procedureName, connection))
			{
				foreach (var parameter in parameters)
				{
					var parameterdata = parameter.ToString().Split('|');
					command.Parameters.AddWithValue(parameterdata[0].Trim(), parameterdata[1].Trim());
				}
				command.CommandType = CommandType.StoredProcedure;
				using (SqlDataAdapter adapter = new SqlDataAdapter(command))
				{
					adapter.Fill(table);
				}
			}
			return table;
		}

		public static void CloseDB()
		{
			connection.Close();
			connection.Dispose();
		}
	}
}